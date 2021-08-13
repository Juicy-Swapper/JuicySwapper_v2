using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MaterialSkin.Controls;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using JuicySwapper_V2.Main.Classes;
using System.Threading;

namespace JuicySwapper_V2
{
    public partial class PaksSorter : MaterialForm
    {
        public PaksSorter()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Textlb.Text = "Please DO NOT CLOSE this form\nPlease wait untill we sort out your paks.\nPlease be patient as this might take up to a minute or two\nThis will auto close once everting is done!\nThis will take longer if your on a hdd.\nEnjoy Swapping - Juicy Team.";

            PaksLocations.pastintem();

            Thread.Sleep(1000);

            Close();
        }

        private void ContinueBtn_Click(object sender, EventArgs e) => Close();
    }
}
