using MaterialSkin.Controls;
using System.Windows.Forms;
using MaterialSkin;
using JuicySwapper_V2.IO;
using System.IO;
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


            WebClient webdownload = new();

            var json = webdownload.DownloadString("https://juicyswapper.netlify.app/api/v1/Skins.json");

            if (Directory.Exists("Api"))
            {
                PaksLocations.DeleteDirectory("Api");
                Thread.Sleep(100);
                Directory.CreateDirectory("Api");
            }
            else
                Directory.CreateDirectory("Api");

            File.WriteAllText("Api/Skins.json", json);

            //PaksSorter a = new();
            //a.ShowDialog();
        }
    }
}
