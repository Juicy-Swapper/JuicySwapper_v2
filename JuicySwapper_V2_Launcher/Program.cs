using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JuicySwapper_V2_Launcher.StatusAPI;

namespace JuicySwapper_V2_Launcher
{
    class Program
    {
        static WebClient webclient = new WebClient();

        static string InstallFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Juicy Industries";

        static string exe = InstallFolder + "\\JuicySwapper_V2.exe";

        static string zip = InstallFolder + "\\JuicySwapper_V2.Zip";

        static bool update;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Juicy Swapper v2 (Beta) Launcher";

            var StatusAPI = webclient.DownloadString("http://juicyswapper.netlify.app/api/v2/status.json");
            Status StatusResponse = JsonConvert.DeserializeObject<Status>(StatusAPI);
            if(StatusResponse.IsRelease)
            {
                Console.WriteLine("Looks like Juicy Swapper v2 is out of beta please Join our discord server for more info.");
                Process.Start("http://juicyswapper.netlify.app/discord");
                Console.ReadLine();
                return;
            }
            if (!Directory.Exists(InstallFolder))
            {
                Directory.CreateDirectory(InstallFolder);
            }
            Process Swapper;
            Swapper = new Process
            {
                StartInfo = new ProcessStartInfo(exe)
                {
                    UseShellExecute = true,
                    WorkingDirectory = InstallFolder,
                    Arguments = "-SwapperToken=bRKNnvyHNRZaWVrVuTLi"
                },
            };
            Logs.Warn("Please disable antivirus or whitelist Juicy Swapper v2 (Beta) before use or it might cause issues.\n\n\n");

            Title();
            Logs.Info("Welcome to Juicy Swapper V2 (beta) Launcher!");
            foreach (Process process in Process.GetProcessesByName("JuicySwapper_V2"))
            {
                Logs.Info("Juicy Swapper v2 (beta) was forced closed!");
                process.Kill();
            }

            if (File.Exists(exe))
            {
                Logs.Check("Checking for updates!");
                GetFileVer();
                if (update)
                {
                    try
                    {
                        if (Directory.Exists(InstallFolder))
                        {
                            DeleteDirectory(InstallFolder);
                            Thread.Sleep(100);
                            Directory.CreateDirectory(InstallFolder);
                        }
                        else
                            Directory.CreateDirectory(InstallFolder);


                        webclient.Proxy = null;
                        webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                        webclient.DownloadFileAsync(new Uri(StatusResponse.SwapperZip), zip);
                        while (webclient.IsBusy)
                            Thread.Sleep(1000);
                        if (File.Exists(zip))
                        {
                            Logs.Zip("Extracting Files!");
                            ZipFile.ExtractToDirectory(zip, InstallFolder);
                            Logs.Zip("Extracted Files!");

                            Thread.Sleep(1000);

                            Logs.Info("Finished! Launching Juicy Swapper v2...");
                            Swapper.Start();
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Logs.Error("ERROR: File not downloaded!");
                            Console.ReadLine();
                        }
                    }
                    catch (Exception arg)
                    {
                        Logs.FatalError("ERROR: " + arg);
                        Console.Read();
                    }
                }
                else
                {
                    Logs.Info("Launching Juicy Swapper v2...");
                    Swapper.Start();

                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }
            else
            {
                try
                {
                    webclient.Proxy = null;
                    webclient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webclient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webclient.DownloadFileAsync(new Uri(StatusResponse.SwapperZip), zip);
                    while (webclient.IsBusy)
                        Thread.Sleep(1000);
                    if (File.Exists(zip))
                    {
                        Logs.Zip("Extracting Files!");
                        ZipFile.ExtractToDirectory(zip, InstallFolder);
                        Logs.Zip("Extracted Files!");

                        Thread.Sleep(1000);
                        Logs.Info("Finished! Launching Juicy Swapper v2...");
                        Swapper.Start();

                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Logs.Error("ERROR: File not downloaded!");
                        Console.ReadLine();
                    }
                }
                catch (Exception arg)
                {
                    Logs.FatalError("ERROR: " + arg);
                    Console.Read();
                }
            }
        }

        private static void Title()
        {
            Colorful.Console.WriteLine();
            Colorful.Console.Write("       ██╗██╗   ██╗██╗ ██████╗██╗   ██╗    ███████╗██╗    ██╗ █████╗ ██████╗ ██████╗ ███████╗██████╗ \n", Color.Orange);
            Colorful.Console.Write("       ██║██║   ██║██║██╔════╝╚██╗ ██╔╝    ██╔════╝██║    ██║██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗\n", Color.Orange);
            Colorful.Console.Write("       ██║██║   ██║██║██║      ╚████╔╝     ███████╗██║ █╗ ██║███████║██████╔╝██████╔╝█████╗  ██████╔╝\n", Color.Orange);
            Colorful.Console.Write("  ██   ██║██║   ██║██║██║       ╚██╔╝      ╚════██║██║███╗██║██╔══██║██╔═══╝ ██╔═══╝ ██╔══╝  ██╔══██╗\n", Color.Orange);
            Colorful.Console.Write("  ╚█████╔╝╚██████╔╝██║╚██████╗   ██║       ███████║╚███╔███╔╝██║  ██║██║     ██║     ███████╗██║  ██║\n", Color.Orange);
            Colorful.Console.Write("   ╚════╝  ╚═════╝ ╚═╝ ╚═════╝   ╚═╝       ╚══════╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝     ╚═╝     ╚══════╝╚═╝  ╚═╝\n", Color.Orange);
            Colorful.Console.Write("                                                                                                     \n", Color.Orange);
            Colorful.Console.Write("\n\n\n");
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

        private static int counter;
        public static string totalfix;
        private static void ProgressChanged(object obj, DownloadProgressChangedEventArgs e)
        {

            var Loger = $" {e.ProgressPercentage}% of 100%, {((e.BytesReceived / 1024f) / 1024f).ToString("#0.##")}MB of {((e.TotalBytesToReceive / 1024f) / 1024f).ToString("#0.##")}MB.";

            totalfix = $"{((e.TotalBytesToReceive / 1024f) / 1024f).ToString("#0.##")}MB.";

            counter++;

            if (counter % 65 == 0)
            {
                Input(Loger);
            }
        }

        public static void Input(string text)
        {
            Console.Write("\r[");
            Colorful.Console.Write(string.Format("{0}", "Downloading"), Color.Yellow);
            Console.Write("]");
            Colorful.Console.Write(text + "\n", Color.White);
        }


        private static void Completed(object obj, AsyncCompletedEventArgs e)
        {
            var Loger = $" 100% of 100%, {totalfix}MB of {totalfix}MB.";
            Input(Loger);
        }

        private static void GetFileVer()
        {
            if (File.Exists(exe))
            {
                FileVersionInfo fileVersionInfo = null;
                try
                {
                    fileVersionInfo = FileVersionInfo.GetVersionInfo(exe);
                }
                catch
                {
                    Logs.Error("ERROR: Unknown!");
                }
                string text = string.Format("{0}.{1}.{2}.{3}", new object[]
                {
                    fileVersionInfo.FileMajorPart,
                    fileVersionInfo.FileMinorPart,
                    fileVersionInfo.FileBuildPart,
                    fileVersionInfo.FilePrivatePart,
                });
                CheckUpdate(text);
                return;
            }
        }

        static void CheckUpdate(string fv)
        {
            foreach (Process process in Process.GetProcessesByName(exe))
            {
                process.Kill();
            }

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    var StatusAPI = webClient.DownloadString("http://juicyswapper.netlify.app/api/v2/status.json");
                    Status StatusResponse = JsonConvert.DeserializeObject<Status>(StatusAPI);
                    webClient.Proxy = null;
                    string text = StatusResponse.version;
                    Logs.Update($"Newest version: {text}");
                    if (!text.Contains(fv))
                    {
                        Logs.Update("Update available!");
                        update = true;
                    }
                    else
                    {
                        update = false;
                        Logs.Update("You are up to date!");
                        Thread.Sleep(1000);

                    }
                }
                catch
                {
                    Logs.Error("ERROR: Unknown!");
                }
            }
        }
    }

    class StatusAPI
    {
        public class Status
        {
            [JsonProperty("SwapperZip")]
            public string SwapperZip { get; set; }

            [JsonProperty("SwapperExe")]
            public string SwapperExe { get; set; }

            [JsonProperty("version")]
            public string version { get; set; }

            [JsonProperty("IsEnabled")]
            public bool IsEnabled { get; set; }

            [JsonProperty("IsRelease")]
            public bool IsRelease { get; set; }
        }
    }
}
