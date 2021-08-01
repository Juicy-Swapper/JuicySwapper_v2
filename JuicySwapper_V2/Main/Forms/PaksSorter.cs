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

            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Textlb.Text = "Please wait untill we sort out your paks.\nPlease be pationt as this might take up to a minite or two\nThis will auto close once everting is done!\nEnjoy Swapping - Juicy Team.";

            PaksLocations.pastintem();

            Thread.Sleep(1000);

            Close();
        }

        private void ContinueBtn_Click(object sender, EventArgs e) => Close();
    }
}
