using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuicySwapper_V2_GetAllCps.Exports
{
	public class CID
	{
		public class Icons
		{
			public string icon { get; set; }

			public string featured { get; set; }

			public object series { get; set; }
		}

		public class Option
		{
			public string tag { get; set; }

			public string name { get; set; }

			public string image { get; set; }

			public bool startUnlocked { get; set; }

			public bool isDefault { get; set; }

			public bool hideIfNotOwned { get; set; }
		}

		public class Variant
		{
			public string channel { get; set; }

			public string type { get; set; }

			public List<CID.Option> options { get; set; }
		}

		public class Root
		{
			public string id { get; set; }

			public string path { get; set; }

			public CID.Icons icons { get; set; }

			public string name { get; set; }

			public string description { get; set; }

			public string shortDescription { get; set; }

			public string backendType { get; set; }

			public string rarity { get; set; }

			public string backendRarity { get; set; }

			public string set { get; set; }

			public string setText { get; set; }

			public object series { get; set; }

			public List<CID.Variant> variants { get; set; }

			public List<string> gameplayTags { get; set; }
		}
	}
}
