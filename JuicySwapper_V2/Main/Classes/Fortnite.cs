using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using static System.Environment;

namespace JuicySwapper_V2
{
	public static class Fortnite
	{
		public static List<Installation> GetEpicInstallLocations()
		{
			var path = Path.Combine(GetFolderPath(SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");

			if (!Directory.Exists(Path.GetDirectoryName(path)) || !File.Exists(path))
				return null;

			return JsonConvert.DeserializeObject<EpicInstallLocations>(File.ReadAllText(path)).InstallationList;
		}

		public class EpicInstallLocations
		{
			[JsonProperty("InstallationList")]
			public List<Installation> InstallationList { get; set; }
		}

		public class Installation
		{
			[JsonProperty("InstallLocation")]
			public string InstallLocation { get; set; }

			[JsonProperty("AppVersion")]
			public string AppVersion { get; set; }

			[JsonProperty("AppName")]
			public string AppName { get; set; }
		}

		public static class PFP
		{
			public static string callPFP()
			{
				WebClient webdownload = new();
				dynamic parsed = JArray.Parse(webdownload.DownloadString("https://benbot.app/api/v1/cosmetics/br?lang=en"));

				var adv = new List<string> { };

				foreach (var cid in parsed)
				{
					string a = cid.id;
					if (a.Contains("CID"))
					{
						string icon = cid.icons.icon;

						adv.Add(icon.ToString());
					}
				}
				Random random = new Random();
				int i = random.Next(adv.Count);
				string strg = adv[i];
				return strg;
			}
		}

		public class ICONS
		{
			public string Icons { get; set; }
		}
	}


}
