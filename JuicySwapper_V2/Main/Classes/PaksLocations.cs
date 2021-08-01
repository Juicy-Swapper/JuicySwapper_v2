using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuicySwapper_V2.Main.Classes
{
    class PaksLocations
    {
        //
        // IK this whole form is ugly but idc becuase i did it at 2-4 in the morning.
        //

        public static string[] Ucas = new string[] { $"pakchunk10_s22-WindowsClient.ucas", $"pakchunk10_s3-WindowsClient.ucas", $"pakchunk10_s17-WindowsClient.ucas", $"pakchunk10_s4-WindowsClient.ucas", $"pakchunk10_s5-WindowsClient.ucas" };

        public static string paktopath = $"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks";

        public static string fortniteversion = $"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.AppVersion}";

        public static string[] FortniteFix = new string[] { $"{paktopath}\\{Ucas[0]}", $"{paktopath}\\{Ucas[1]}", $"{paktopath}\\{Ucas[2]}", $"{paktopath}\\{Ucas[3]}", $"{paktopath}\\{Ucas[4]}" };

        public static string swapper = $"{Directory.GetCurrentDirectory()}\\PakTemps";

        public static bool DupeCheck = Dupecheck();

		public static void pastintem()
        {
            if (!Directory.Exists("PakTemps"))
            {
                Directory.CreateDirectory("PakTemps");
            }
                
            if (DupeCheck)
            {
                if (Directory.Exists("PakTemps"))
                {
                    DeleteDirectory("PakTemps");
                    Thread.Sleep(100);
                    Directory.CreateDirectory("PakTemps");
                }
                else
                    Directory.CreateDirectory("PakTemps");

                foreach (var files in Directory.GetFiles(paktopath))
                {
                    if (files.Contains("100_s"))
                    {
                        File.Delete(files);
                    }  
                }

                File.Create($"PakTemps\\{fortniteversion}");
            }

            //paksdir
            foreach (var files in FortniteFix)
            {
                var file = files.Replace("10", "100");
                if (!File.Exists(file))
                {
                    var toc = file.Replace(".ucas", ".utoc");
                    var pak = file.Replace(".ucas", ".pak");
                    var sig = file.Replace(".ucas", ".sig");

                    File.Copy(file.Replace("100", "10"), file);
                    File.Copy(toc.Replace("100", "10"), toc);
                    File.Copy(pak.Replace("100", "10"), pak);
                    File.Copy(sig.Replace("100", "10"), sig);
                }
            }

            foreach (var file in Ucas)
            {
                if (!File.Exists($"{swapper}\\{file}"))
                {
                    
                    var toc = file.Replace(".ucas", ".utoc");
                    var pak = file.Replace(".ucas", ".pak");
                    var sig = file.Replace(".ucas", ".sig");

                    File.Copy($"{paktopath}\\{file}", $"{swapper}\\{file}");
                    File.Copy($"{paktopath}\\{toc}", $"{swapper}\\{toc}");
                    File.Copy($"{paktopath}\\{pak}", $"{swapper}\\{pak}");
                    File.Copy($"{paktopath}\\{sig}", $"{swapper}\\{sig}");
                }
            }
        }

        public static bool Dupecheck()
        {
            string[] files = Directory.GetFiles("PakTemps");

            foreach (string file in files)
            {
                if (file.Contains(fortniteversion))
                {
                    return false;
                }
            }

            return true;
        }

        public static void DeleteDirectory(string DirectoryToDelete)
        {
            string[] files = Directory.GetFiles(DirectoryToDelete);
            string[] dirs = Directory.GetDirectories(DirectoryToDelete);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(DirectoryToDelete, false);
        }
    }
}
