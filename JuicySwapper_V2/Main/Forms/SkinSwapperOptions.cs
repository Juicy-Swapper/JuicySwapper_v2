using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MaterialSkin.Controls;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using Newtonsoft.Json.Linq;
using System.Net;
using JuicySwapper_V2.IO;
using System.IO;
using JuicySwapper_V2.Main.Classes;
using System.Diagnostics;

namespace JuicySwapper_V2.Main.Forms
{
    public partial class SkinSwapperOptions : MaterialForm
    {
        public SkinSwapperOptions()
        {
            InitializeComponent();
            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            dynamic parsed = JObject.Parse(File.ReadAllText("Api/Skins.json"));

            foreach(var cosmetic in parsed.skins)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    foreach(var items in cosmetic.Options)
                    {
                        string itemsswap = items.name;
                        if (itemsswap.ToString().Contains(vars.optionskin))
                        {
                            string swapsicon = items.icon;
                            pictureBox1.ImageLocation = swapsicon.ToString();
                            Text = itemsswap.Replace("_", " ").ToString();
                            
                        }
                    }
                }
            }
        }

        private void RevertBtn_Click(object sender, EventArgs e)
        {
            LogBox.Text += $"[LOG] Starting...\n";

            dynamic parsed = JObject.Parse(File.ReadAllText("Api/Skins.json"));

            foreach (var cosmetic in parsed.skins)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    foreach (var items in cosmetic.Options)
                    {
                        string itemsswap = items.name;
                        if (itemsswap.ToString().Contains(vars.optionskin))
                        {
                            foreach (var asset in items.assets)
                            {
                                string mainasset = $"{asset.parentasset}.uasset";

                                LogBox.Text += $"[LOG] Getting uasset\n";

                                bool exportbool = Engine.ExportCompressed(mainasset.ToString(), Directory.GetCurrentDirectory());
                                if (exportbool)
                                    LogBox.Text += $"[LOG] Successfully Getting uasset\n";
                                else
                                {
                                    LogBox.Text += $"[LOG] Error Getting uasset\n";
                                    return;
                                }

                                Oodle.Oodle.Compress(mainasset, mainasset + "Non");

                                var dataswap = File.ReadAllBytes(mainasset + "Non");

                                var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                                bool SwapUassetBool = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                                if (SwapUassetBool)
                                    LogBox.Text += $"[LOG] Uasset Successfully added\n";
                                else
                                    LogBox.Text += $"[LOG] Error adding Uasset\n";

                                try
                                {
                                    PaksLocations.DeleteDirectory("FortniteGame");
                                }
                                catch { }
                            }

                        }
                    }
                }
            }
        

                
        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            LogBox.Text += $"[LOG] Starting...\n";

            dynamic parsed = JObject.Parse(File.ReadAllText("Api/Skins.json"));

            foreach (var cosmetic in parsed.skins)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    foreach (var items in cosmetic.Options)
                    {
                        string itemsswap = items.name;
                        if (itemsswap.ToString().Contains(vars.optionskin))
                        {
                            foreach (var asset in items.assets)
                            {
                                string mainasset = $"{asset.parentasset}.uasset";

                                LogBox.Text += $"[LOG] Getting uasset\n";

                                bool exportbool = Engine.ExportCompressed(mainasset.ToString(), Directory.GetCurrentDirectory());
                                if (exportbool)
                                    LogBox.Text += $"[LOG] Successfully Getting uasset\n";
                                else
                                {
                                    LogBox.Text += $"[LOG] Error Getting uasset\n";
                                    return;
                                }

                                foreach (var swap in asset.swaps)
                                {
                                    string Researchertemp = swap.Researcher;
                                    if (Researchertemp.ToLower().ToString() == "string")
                                    {
                                        string swap1 = swap.search;
                                        string swap2 = swap.replace;

                                        bool swapbool = Researcher.ConvertInUasset(mainasset, swap1.ToString(), swap2.ToString());
                                        if (swapbool)
                                            LogBox.Text += $"[LOG] {swap.log}\n";
                                    }
                                    else if (Researchertemp.ToLower().ToString() == "byte")
                                    {
                                        byte[] swap1 = swap.search;
                                        byte[] swap2 = swap.replace;
                                        bool swapbool = Researcher.ConvertInUasset(mainasset, swap1, swap2);
                                        if (swapbool)
                                            LogBox.Text += $"[LOG] {swap.log}\n";
                                    }
                                }

                                Oodle.Oodle.Compress(mainasset, mainasset + ".Compressed");

                                var dataswap = File.ReadAllBytes(mainasset + ".Compressed");

                                var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                                bool SwapUassetBool = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                                if (SwapUassetBool)
                                    LogBox.Text += $"[LOG] Uasset Successfully added\n";
                                else
                                    LogBox.Text += $"[LOG] Error adding Uasset\n";

                                try
                                {
                                    PaksLocations.DeleteDirectory("FortniteGame");
                                }
                                catch { }
                            }

                        }
                    }
                }
            }
        }
    }
}
