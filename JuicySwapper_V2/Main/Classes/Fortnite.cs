using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static System.Environment;

namespace JuicySwapper_V2
{
    class Fortnite
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
	}
}
