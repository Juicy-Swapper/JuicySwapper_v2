using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_GetAllCps.Exports
{
	public class CIDExport
	{
		public class ImportMap
		{
			public string type { get; set; }

			public object value { get; set; }
		}

		public class ObjectName
		{
			public int index { get; set; }

			public int number { get; set; }
		}

		public class OuterIndex
		{
			public string type { get; set; }

			public long value { get; set; }
		}

		public class ClassIndex
		{
			public string type { get; set; }

			public object value { get; set; }
		}

		public class SuperIndex
		{

			public string type { get; set; }

			public object value { get; set; }
		}

		public class TemplateIndex
		{
			public string type { get; set; }

			public object value { get; set; }
		}

		public class GlobalImportIndex
		{
			public string type { get; set; }

			public object value { get; set; }
		}

		public class ExportMap
		{
			public int cookedSerialOffset { get; set; }

			public int cookedSerialSize { get; set; }

			public CIDExport.ObjectName objectName { get; set; }

			public CIDExport.OuterIndex outerIndex { get; set; }

			public CIDExport.ClassIndex classIndex { get; set; }

			public CIDExport.SuperIndex superIndex { get; set; }

			public CIDExport.TemplateIndex templateIndex { get; set; }

			public CIDExport.GlobalImportIndex globalImportIndex { get; set; }

			public int objectFlags { get; set; }

			public int filterFlags { get; set; }
		}

		public class Value
		{
			public string @namespace { get; set; }

			public string key { get; set; }

			public string sourceString { get; set; }
		}

		public class DisplayName
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class ShortDescription
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class Description
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class MaterialToSwap
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class OverrideMaterial
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class VariantMaterial
		{
			public CIDExport.MaterialToSwap MaterialToSwap { get; set; }

			public string ComponentToOverride { get; set; }

			public string CascadeMaterialName { get; set; }

			public int MaterialOverrideIndex { get; set; }

			public CIDExport.OverrideMaterial OverrideMaterial { get; set; }
		}

		public class MetaTags
		{
			public List<object> MetaTagsToApply { get; set; }

			public List<object> MetaTagsToRemove { get; set; }
		}

		public class CustomizationVariantTag
		{
			public string TagName { get; set; }
		}

		public class VariantName
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class PreviewImage
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class UnlockRequirements
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class UnlockingItemDef
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class MaterialOption
		{
			public List<CIDExport.VariantMaterial> VariantMaterials { get; set; }

			public List<object> VariantMaterialParams { get; set; }

			public List<object> VariantSounds { get; set; }

			public List<object> VariantFoley { get; set; }

			public CIDExport.MetaTags MetaTags { get; set; }

			public bool bStartUnlocked { get; set; }

			public bool bIsDefault { get; set; }

			public bool bHideIfNotOwned { get; set; }

			public CIDExport.CustomizationVariantTag CustomizationVariantTag { get; set; }

			public CIDExport.VariantName VariantName { get; set; }

			public CIDExport.PreviewImage PreviewImage { get; set; }

			public CIDExport.UnlockRequirements UnlockRequirements { get; set; }

			public CIDExport.UnlockingItemDef UnlockingItemDef { get; set; }
		}

		public class VariantChannelTag
		{
			public string TagName { get; set; }
		}

		public class VariantChannelName
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public CIDExport.Value value { get; set; }
		}

		public class ExportProperty
		{
			public string exportType { get; set; }

			public string HeroDefinition { get; set; }

			public List<string> ItemVariants { get; set; }

			public string Rarity { get; set; }

			public CIDExport.DisplayName DisplayName { get; set; }

			public CIDExport.ShortDescription ShortDescription { get; set; }

			public CIDExport.Description Description { get; set; }

			public List<string> GameplayTags { get; set; }

			public List<CIDExport.MaterialOption> MaterialOptions { get; set; }

			public CIDExport.VariantChannelTag VariantChannelTag { get; set; }

			public CIDExport.VariantChannelName VariantChannelName { get; set; }
		}

		public class Root
		{
			public List<CIDExport.ImportMap> import_map { get; set; }

			public List<CIDExport.ExportMap> export_map { get; set; }

			public List<CIDExport.ExportProperty> export_properties { get; set; }
		}
	}
}
