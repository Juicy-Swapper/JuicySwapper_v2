using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_GetAllCps.Exports
{
	class HIDExport
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

			public long value { get; set; }
		}

		public class SuperIndex
		{
			public string type { get; set; }

			public long value { get; set; }
		}

		public class TemplateIndex
		{
			public string type { get; set; }

			public long value { get; set; }
		}

		public class GlobalImportIndex
		{
			public string type { get; set; }

			public long value { get; set; }
		}

		public class ExportMap
		{
			public int cookedSerialOffset { get; set; }

			public int cookedSerialSize { get; set; }

			public HIDExport.ObjectName objectName { get; set; }

			public HIDExport.OuterIndex outerIndex { get; set; }

			public HIDExport.ClassIndex classIndex { get; set; }

			public HIDExport.SuperIndex superIndex { get; set; }

			public HIDExport.TemplateIndex templateIndex { get; set; }

			public HIDExport.GlobalImportIndex globalImportIndex { get; set; }

			public int objectFlags { get; set; }

			public int filterFlags { get; set; }
		}

		public class Specialization
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class DefaultMontageLookupTable
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class OverridePawnClass
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class FrontEndAnimClass
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class AttributeInitKey
		{
			public string AttributeInitCategory { get; set; }

			public string AttributeInitSubCategory { get; set; }
		}

		public class LegacyStatHandle
		{
			public string DataTable { get; set; }

			public string RowName { get; set; }
		}

		public class LevelToXpHandle
		{
			public string CurveTable { get; set; }

			public string RowName { get; set; }
		}

		public class LevelToSacrificeXpHandle
		{
			public string CurveTable { get; set; }

			public string RowName { get; set; }
		}

		public class TransmogSacrificeRow
		{
			public string DataTable { get; set; }

			public string RowName { get; set; }
		}

		public class ConversionRecipe
		{
			public string DataTable { get; set; }

			public string RowName { get; set; }
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

			public HIDExport.Value value { get; set; }
		}

		public class Description
		{
			public string historyType { get; set; }

			public string finalText { get; set; }

			public HIDExport.Value value { get; set; }
		}

		public class RatingLookup
		{
			public string CurveTable { get; set; }

			public string RowName { get; set; }
		}

		public class SmallPreviewImage
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class LargePreviewImage
		{
			public string assetPath { get; set; }

			public string subPath { get; set; }
		}

		public class ExportProperty
		{
			public string exportType { get; set; }

			public List<HIDExport.Specialization> Specializations { get; set; }

			public HIDExport.DefaultMontageLookupTable DefaultMontageLookupTable { get; set; }

			public List<string> RequiredGPTags { get; set; }

			public HIDExport.OverridePawnClass OverridePawnClass { get; set; }

			public HIDExport.FrontEndAnimClass FrontEndAnimClass { get; set; }

			public HIDExport.AttributeInitKey AttributeInitKey { get; set; }

			public HIDExport.LegacyStatHandle LegacyStatHandle { get; set; }

			public HIDExport.LevelToXpHandle LevelToXpHandle { get; set; }

			public HIDExport.LevelToSacrificeXpHandle LevelToSacrificeXpHandle { get; set; }

			public HIDExport.TransmogSacrificeRow TransmogSacrificeRow { get; set; }

			public List<HIDExport.ConversionRecipe> ConversionRecipes { get; set; }

			public int MaxLevel { get; set; }

			public string Tier { get; set; }

			public string MaxTier { get; set; }

			public bool bNeverPersisted { get; set; }

			public HIDExport.DisplayName DisplayName { get; set; }

			public HIDExport.Description Description { get; set; }

			public List<string> GameplayTags { get; set; }

			public HIDExport.RatingLookup RatingLookup { get; set; }

			public HIDExport.SmallPreviewImage SmallPreviewImage { get; set; }

			public HIDExport.LargePreviewImage LargePreviewImage { get; set; }
		}

		public class Root
		{
			public List<HIDExport.ImportMap> import_map { get; set; }

			public List<HIDExport.ExportMap> export_map { get; set; }

			public List<HIDExport.ExportProperty> export_properties { get; set; }
		}
	}
}
