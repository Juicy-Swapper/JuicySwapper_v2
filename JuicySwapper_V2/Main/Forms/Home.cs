using MaterialSkin.Controls;
using System.Windows.Forms;
using MaterialSkin;
using JuicySwapper_V2.IO;
using System.IO;
using System.Drawing;
using JuicySwapper_V2.Main.Classes;
using System.Net;
using System.Threading;
using JuicySwapper_V2.Properties;

namespace JuicySwapper_V2
{
    public partial class Home : MaterialForm
    {
        public Home()
        {
            InitializeComponent();
            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            materialTabControl1.Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            if(Settings.Default.DebugAPI == null)
            {
                WebClient webdownload = new();

                var Skin = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Skins.json");
                var Pickaxe = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Pickaxes.json");
                var BackBling = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/BackBlings.json");
                var Emote = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Emotes.json");
                var API = Directory.GetCurrentDirectory() + "\\Api";

                if (Directory.Exists(API))
                {
                    PaksLocations.DeleteDirectory(API);
                    Thread.Sleep(100);
                    Directory.CreateDirectory(API);
                }
                else
                    Directory.CreateDirectory(API);

                File.WriteAllText($"{API}\\Skins.json", Skin);
                File.WriteAllText($"{API}\\Pickaxes.json", Pickaxe);
                File.WriteAllText($"{API}\\BackBlings.json", BackBling);
                File.WriteAllText($"{API}\\Emotes.json", Emote);
            }
            else
            {
                var API = Directory.GetCurrentDirectory() + "\\Api";
                if (Directory.Exists(API))
                {
                    PaksLocations.DeleteDirectory(API);
                    Thread.Sleep(100);
                    Directory.CreateDirectory(API);
                }
                else
                    Directory.CreateDirectory(API);

                
                var pathDEBUG = Settings.Default.DebugAPI;
                foreach (var json in Directory.GetFiles(pathDEBUG))
                {
                    var apistrings = File.ReadAllText(json);
                    var name = Path.GetFileName(json);
                    File.WriteAllText($"{API}\\{name}", apistrings);

                }
                

                Settings.Default.DebugAPI = null;
                Settings.Default.Save();

               
            }
            

            PaksSorter a = new();
            a.ShowDialog();
        }
    }
}
