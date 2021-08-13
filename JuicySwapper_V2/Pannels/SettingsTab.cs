using JuicySwapper_V2.Main.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuicySwapper_V2.Pannels
{
    public partial class SettingsTab : UserControl
    {
        public SettingsTab()
        {
            InitializeComponent();
            materialTextBox1.Text = $"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string[] ucas = PaksLocations.FortniteFix;

            foreach (var files in ucas)
            {
                var file = files.Replace("10", "100");

                var toc = file.Replace(".ucas", ".utoc");
                var pak = file.Replace(".ucas", ".pak");
                var sig = file.Replace(".ucas", ".sig");

                if (File.Exists(file))
                    File.Delete(file);

                if (File.Exists(toc))
                    File.Delete(toc);

                if (File.Exists(pak))
                    File.Delete(pak);

                if (File.Exists(sig))
                    File.Delete(sig);

                if (!File.Exists(file))
                {
                    File.Copy(file.Replace("100", "10"), file);
                    File.Copy(toc.Replace("100", "10"), toc);
                    File.Copy(pak.Replace("100", "10"), pak);
                    File.Copy(sig.Replace("100", "10"), sig);
                }
            }
            MessageBox.Show("All items where reverted!", "Juicy Swapper v2 - Items Done!");
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            var exestart = $"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe";

            Process.Start(exestart);

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName("Fortnite.exe"))
            {
                foreach (Process a in Process.GetProcessesByName("EpicGamesLauncher.exe"))
                {
                    a.Kill();
                    MessageBox.Show("Verification files bypass please click ok when you wanna close fortnite!", "Juicy Swapper v2");
                    process.Kill();
                    timer1.Enabled = false;
                }
            }

        }
    }
}
