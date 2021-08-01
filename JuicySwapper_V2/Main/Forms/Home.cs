using MaterialSkin.Controls;
using System.Windows.Forms;
using MaterialSkin;
using JuicySwapper_V2.IO;
using System.IO;
using JuicySwapper_V2.Main.Classes;

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

            PaksSorter a = new();
            a.ShowDialog();
        }
    }
}
