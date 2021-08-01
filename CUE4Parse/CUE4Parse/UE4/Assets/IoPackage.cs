using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using CUE4Parse.FileProvider;
using CUE4Parse.MappingsProvider;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Readers;
using CUE4Parse.UE4.Assets.Utils;
using CUE4Parse.UE4.Exceptions;
using CUE4Parse.UE4.IO;
using CUE4Parse.UE4.IO.Objects;
using CUE4Parse.UE4.Objects.UObject;
using CUE4Parse.UE4.Readers;
using CUE4Parse.UE4.Versions;
using CUE4Parse.Utils;

namespace CUE4Parse.UE4.Assets
{
    public sealed class IoPackage : AbstractUePackage
    {
        public readonly IoGlobalData GlobalData;

        public override FPackageFileSummary Summary { get; }
        public override FNameEntrySerialized[] NameMap { get; }
        public readonly FPackageObjectIndex[] ImportMap;
        public readonly FExportMapEntry[] ExportMap;

        public readonly Lazy<IoPackage?[]> ImportedPackages;
        public override Lazy<UObject>[] ExportsLazy { get; }

        public IoPackage(
            FArchive uasset, IoGlobalData globalData,
            Lazy<FArchive?>? ubulk = null, Lazy<FArchive?>? uptnl = null,
            IFileProvider? provider = null, TypeMappings? mappings = null) : base(uasset.Name.SubstringBeforeLast('.'), provider, mappings)
        {
            GlobalData = globalData;
            var uassetAr = new FAssetArchive(uasset, this);

            FExportBundleHeader[] exportBundleHeaders;
            FExportBundleEntry[] exportBundleEntries;
            FPackageId[] importedPackageIds;
            int allExportDataOffset;

            if (uassetAr.Game >= EGame.GAME_UE5_0)
            {
                // Summary
                var summary = uassetAr.Read<FPackageSummary5>();
                Summary = new FPackageFileSummary
                {
                    PackageFlags = summary.PackageFlags,
                    TotalHeaderSize = summary.GraphDataOffset + (int) summary.HeaderSize,
                    ExportCount = (summary.ExportBundleEntriesOffset - summary.ExportMapOffset) / Unsafe.SizeOf<FExportMapEntry>(),
                    ImportCount = (summary.ExportMapOffset - summary.ImportMapOffset) / FPackageObjectIndex.Size
                };

                // Name map
                NameMap = FNameEntrySerialized.LoadNameBatch(uassetAr);
                Summary.NameCount = NameMap.Length;
                Name = CreateFNameFromMappedName(summary.Name).Text;

                // Import map
                uassetAr.Position = summary.ImportMapOffset;
                ImportMap = uasset.ReadArray<FPackageObjectIndex>(Summary.ImportCount);

                // Export map
                uassetAr.Position = summary.ExportMapOffset;
                ExportMap = uasset.ReadArray<FExportMapEntry>(Summary.ExportCount);
                ExportsLazy = new Lazy<UObject>[Summary.ExportCount];

                // Export bundle entries
                uassetAr.Position = summary.ExportBundleEntriesOffset;
                exportBundleEntries = uassetAr.ReadArray<FExportBundleEntry>(Summary.ExportCount * 2);

                // Export bundle headers
                uassetAr.Position = summary.GraphDataOffset;
                var exportBundleHeadersCount = 1; // TODO just a placeholder until loading of package store entries are implemented
                exportBundleHeaders = uassetAr.ReadArray<FExportBundleHeader>(exportBundleHeadersCount);
                // We don't read the graph data

                importedPackageIds = Array.Empty<FPackageId>(); // TODO imported packages are now only stored in the package store entry, no longer in the graph data too

                allExportDataOffset = (int) summary.HeaderSize;
            }
            else
            {
                // Summary
                var summary = uassetAr.Read<FPackageSummary>();
                Summary = new FPackageFileSummary
                {
                    PackageFlags = summary.PackageFlags,
                    TotalHeaderSize = summary.GraphDataOffset + summary.GraphDataSize,
                    NameCount = summary.NameMapHashesSize / sizeof(ulong) - 1,
                    ExportCount = (summary.ExportBundlesOffset - summary.ExportMapOffset) / Unsafe.SizeOf<FExportMapEntry>(),
                    ImportCount = (summary.ExportMapOffset - summary.ImportMapOffset) / FPackageObjectIndex.Size
                };

                // Name map
                uassetAr.Position = summary.NameMapNamesOffset;
                NameMap = FNameEntrySerialized.LoadNameBatch(uassetAr, Summary.NameCount);
                Name = CreateFNameFromMappedName(summary.Name).Text;

                // Import map
                uassetAr.Position = summary.ImportMapOffset;
                ImportMap = uasset.ReadArray<FPackageObjectIndex>(Summary.ImportCount);

                // Export map
                uassetAr.Position = summary.ExportMapOffset;
                ExportMap = uasset.ReadArray<FExportMapEntry>(Summary.ExportCount);
                ExportsLazy = new Lazy<UObject>[Summary.ExportCount];

                // Export bundles
                uassetAr.Position = summary.ExportBundlesOffset;
                LoadExportBundles(uassetAr, summary.GraphDataOffset - summary.ExportBundlesOffset, out exportBundleHeaders, out exportBundleEntries);

                // Graph data
                uassetAr.Position = summary.GraphDataOffset;
                importedPackageIds = LoadGraphData(uassetAr);

                allExportDataOffset = summary.GraphDataOffset + summary.GraphDataSize;
            }

            // Preload dependencies
            ImportedPackages = new Lazy<IoPackage?[]>(provider != null ? () =>
            {
                var packages = new IoPackage?[importedPackageIds.Length];
                for (int i = 0; i < importedPackageIds.Length; i++)
                {
                    provider.TryLoadPackage(importedPackageIds[i], out packages[i]);
                }
                return packages;
            } : Array.Empty<IoPackage?>);

            // Attach ubulk and uptnl
            if (ubulk != null) uassetAr.AddPayload(PayloadType.UBULK, Summary.BulkDataStartOffset, ubulk);
            if (uptnl != null) uassetAr.AddPayload(PayloadType.UPTNL, Summary.BulkDataStartOffset, uptnl);

            // Populate lazy exports
            var currentExportDataOffset = allExportDataOffset;
            foreach (var exportBundle in exportBundleHeaders)
            {
                for (var i = 0u; i < exportBundle.EntryCount; i++)
                {
                    var entry = exportBundleEntries[exportBundle.FirstEntryIndex + i];
                    if (entry.CommandType == EExportCommandType.ExportCommandType_Serialize)
                    {
                        var localExportIndex = entry.LocalExportIndex;
                        var export = ExportMap[localExportIndex];
                        var localExportDataOffset = currentExportDataOffset;
                        ExportsLazy[localExportIndex] = new Lazy<UObject>(() =>
                        {
                            // Create
                            var obj = ConstructObject(ResolveObjectIndex(export.ClassIndex)?.Object?.Value as UStruct);
                            obj.Name = CreateFNameFromMappedName(export.ObjectName).Text;
                            obj.Outer = (ResolveObjectIndex(export.OuterIndex) as ResolvedExportObject)?.ExportObject.Value ?? this;
                            obj.Super = ResolveObjectIndex(export.SuperIndex) as ResolvedExportObject;
                            obj.Template = ResolveObjectIndex(export.TemplateIndex) as ResolvedExportObject;
                            obj.Flags |= (EObjectFlags) export.ObjectFlags; // We give loaded objects the RF_WasLoaded flag in ConstructObject, so don't remove it again in here

                            // Serialize
                            uassetAr.AbsoluteOffset = (int) export.CookedSerialOffset - localExportDataOffset;
                            uassetAr.Seek(localExportDataOffset, SeekOrigin.Begin);
                            DeserializeObject(obj, uassetAr, (long) export.CookedSerialSize);
                            // TODO right place ???
                            obj.Flags |= EObjectFlags.RF_LoadCompleted;
                            obj.PostLoad();
                            return obj;
                        });
                        currentExportDataOffset += (int) export.CookedSerialSize;
                    }
                }
            }

            Summary.BulkDataStartOffset = currentExportDataOffset;
        }

        public IoPackage(FArchive uasset, IoGlobalData globalData, FArchive? ubulk = null, FArchive? uptnl = null, IFileProvider? provider = null, TypeMappings? mappings = null)
            : this(uasset, globalData, ubulk != null ? new Lazy<FArchive?>(() => ubulk) : null, uptnl != null ? new Lazy<FArchive?>(() => uptnl) : null, provider, mappings)
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FName CreateFNameFromMappedName(FMappedName mappedName) =>
            new(mappedName, mappedName.IsGlobal ? GlobalData.GlobalNameMap : NameMap);

        private void LoadExportBundles(FArchive Ar, int graphDataSize, out FExportBundleHeader[] bundleHeadersArray, out FExportBundleEntry[] bundleEntriesArray)
        {
            var remainingBundleEntryCount = graphDataSize / (4 + 4);
            var foundBundlesCount = 0;
            var foundBundleHeaders = new List<FExportBundleHeader>();
            while (foundBundlesCount < remainingBundleEntryCount)
            {
                // This location is occupied by header, so it is not a bundle entry
                remainingBundleEntryCount--;
                var bundleHeader = new FExportBundleHeader(Ar);
                foundBundlesCount += (int) bundleHeader.EntryCount;
                foundBundleHeaders.Add(bundleHeader);
            }

            if (foundBundlesCount != remainingBundleEntryCount)
                throw new ParserException(Ar, $"FoundBundlesCount {foundBundlesCount} != RemainingBundleEntryCount {remainingBundleEntryCount}");

            // Load export bundles into arrays
            bundleHeadersArray = foundBundleHeaders.ToArray();
            bundleEntriesArray = Ar.ReadArray<FExportBundleEntry>(foundBundlesCount);
        }

        private FPackageId[] LoadGraphData(FArchive Ar)
        {
            var packageCount = Ar.Read<int>();
            if (packageCount == 0) return Array.Empty<FPackageId>();

            var packageIds = new FPackageId[packageCount];
            for (var packageIndex = 0; packageIndex < packageCount; packageIndex++)
            {
                var packageId = Ar.Read<FPackageId>();
                var bundleCount = Ar.Read<int>();
                Ar.Position += bundleCount * (sizeof(int) + sizeof(int)); // Skip FArcs
                packageIds[packageIndex] = packageId;
            }

            return packageIds;
        }

        public override UObject? GetExportOrNull(string name, StringComparison comparisonType = StringComparison.Ordinal)
        {
            for (var i = 0; i < ExportMap.Length; i++)
            {
                var export = ExportMap[i];
                if (CreateFNameFromMappedName(export.ObjectName).Text.Equals(name, comparisonType))
                {
                    return ExportsLazy[i].Value;
                }
            }

            return null;
        }

        public override ResolvedObject? ResolvePackageIndex(FPackageIndex? index)
        {
            if (index == null || index.IsNull)
                return null;
            if (index.IsImport && -index.Index - 1 < ImportMap.Length)
                return ResolveObjectIndex(ImportMap[-index.Index - 1]);
            if (index.IsExport && index.Index - 1 < ExportMap.Length)
                return new ResolvedExportObject(index.Index - 1, this);
            return null;
        }

        public ResolvedObject? ResolveObjectIndex(FPackageObjectIndex index)
        {
            if (index.IsExport)
            {
                return new ResolvedExportObject((int) index.AsExport, this);
            }

            if (index.IsScriptImport)
            {
                var scriptObjectEntry = GlobalData.FindScriptEntryName(index);
                return scriptObjectEntry != "None" ? new ResolvedScriptObject(scriptObjectEntry, this) : null;
            }

            if (index.IsPackageImport)
            {
                foreach (var pkg in ImportedPackages.Value)
                {
                    if (pkg == null) continue;
                    for (int exportIndex = 0; exportIndex < pkg.ExportMap.Length; ++exportIndex)
                        if (pkg.ExportMap[exportIndex].GlobalImportIndex == index)
                            return new ResolvedExportObject(exportIndex, pkg);
                }
            }

            return null;
        }

        private class ResolvedExportObject : ResolvedObject
        {
            public FExportMapEntry ExportMapEntry;
            public Lazy<UObject> ExportObject;

            public ResolvedExportObject(int exportIndex, IoPackage package) : base(package, exportIndex)
            {
                if (exportIndex >= package.ExportMap.Length) return;
                ExportMapEntry = package.ExportMap[exportIndex];
                ExportObject = package.ExportsLazy[exportIndex];
            }

            public override FName Name => ((IoPackage) Package).CreateFNameFromMappedName(ExportMapEntry.ObjectName);
            public override ResolvedObject Outer => ((IoPackage) Package).ResolveObjectIndex(ExportMapEntry.OuterIndex) ?? new ResolvedLoadedObject(Index, (UObject) Package);
            public override ResolvedObject? Class => ((IoPackage) Package).ResolveObjectIndex(ExportMapEntry.ClassIndex);
            public override ResolvedObject? Super => ((IoPackage) Package).ResolveObjectIndex(ExportMapEntry.SuperIndex);
            public override Lazy<UObject> Object => ExportObject;
        }

        private class ResolvedScriptObject : ResolvedObject
        {
            // public FScriptObjectEntry ScriptImport;
            public string ScriptImportName;

            public ResolvedScriptObject(string scriptImportName, IoPackage package) : base(package, 0)
            {
                ScriptImportName = scriptImportName;
            }

            public override FName Name => new(ScriptImportName);
            public override ResolvedObject? Outer => null; //((IoPackage) Package).ResolveObjectIndex(ScriptImport.OuterIndex);
            public override ResolvedObject Class => new ResolvedLoadedObject(Index, new UScriptClass("Class"));
            public override Lazy<UObject> Object => new(() => new UScriptClass(Name.Text));
        }
    }
}