using MaterialSkin.Controls;
using System.Windows.Forms;
using MaterialSkin;
using JuicySwapper_V2.IO;
using System.IO;
using System.Drawing;
using JuicySwapper_V2.Main.Classes;
using System.Net;
using System.Threading;

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

            WebClient webdownload = new();

            var Skin = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Skins.json");
            var Pickaxe = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Pickaxes.json");
            var BackBling = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/BackBlings.json");
            var Emote = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Emotes.json");

            if (Directory.Exists("Api"))
            {
                PaksLocations.DeleteDirectory("Api");
                Thread.Sleep(100);
                Directory.CreateDirectory("Api");
            }
            else
                Directory.CreateDirectory("Api");

            File.WriteAllText("Api/Skins.json", Skin);
            File.WriteAllText("Api/Pickaxes.json", Pickaxe);
            File.WriteAllText("Api/BackBlings.json", BackBling);
            File.WriteAllText("Api/Emotes.json", Emote);

            PaksSorter a = new();
            a.ShowDialog();
        }
    }
}
