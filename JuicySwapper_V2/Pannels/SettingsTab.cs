using JuicySwapper_V2.Main.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
