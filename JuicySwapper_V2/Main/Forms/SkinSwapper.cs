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
    public partial class SkinSwapper : MaterialForm
    {
        public SkinSwapper()
        {
            InitializeComponent();

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            dynamic parsed = JObject.Parse(File.ReadAllText(vars.JsonRead.ToString()));

            foreach(var cosmetic in parsed.items)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    string swapsicon = cosmetic.swapicon;
                    pictureBox1.ImageLocation = swapsicon.ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Text = skinsname.Replace("_", " ").ToString();
                    if (cosmetic.ExtraInfo != null)
                    {
                        string info = cosmetic.ExtraInfo;
                        MessageBox.Show(info.ToString(), $"Extra Info - {skinsname.Replace("_", " ")}");
                    }
                }
            }
        }

        private void RevertBtn_Click(object sender, EventArgs e)
        {
            dynamic parsed = JObject.Parse(File.ReadAllText(vars.JsonRead.ToString()));

            LogBox.Clear();
            LogBox.Text += $"[LOG] Starting...\n";

            foreach (var cosmetic in parsed.items)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    foreach (var asset in cosmetic.assets)
                    {
                        string mainasset = $"{asset.parentasset}.uasset";

                        bool exportbool = Engine.ExportCompressed(mainasset.ToString(), Directory.GetCurrentDirectory());
                        if (!exportbool)
                        {
                            LogBox.Text += $"[LOG] Error Getting uasset\n";
                            return;
                        }

                        foreach (var swap in asset.swaps)
                        {
                            if (swap.log != null)
                            {
                                LogBox.Text += $"[LOG] {swap.log} removed\n";

                            }
                        }

                        Oodle.Oodle.Compress(mainasset, mainasset + "Non");

                        var dataswap = File.ReadAllBytes(mainasset + "Non");

                        var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                        bool SwapUassetBool = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                        if (!SwapUassetBool)
                        {
                            LogBox.Text += $"[LOG] Error adding Uasset\n";
                            return;
                        }

                        try
                        {
                            PaksLocations.DeleteDirectory("FortniteGame");
                        }
                        catch { }
                    }
                    LogBox.Text += $"[LOG] Reverted!\n";

                }
            }
        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            dynamic parsed = JObject.Parse(File.ReadAllText(vars.JsonRead.ToString()));

            LogBox.Clear();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
            LogBox.Text += $"[LOG] Starting...\n";

            foreach (var cosmetic in parsed.items)
            {
                string skinsname = cosmetic.name;
                if (skinsname.ToString().Contains(vars.item))
                {
                    

                   foreach(var asset in cosmetic.assets)
                   {
                        string mainasset = $"{asset.parentasset}.uasset";

                        bool exportbool = Engine.ExportCompressed(mainasset.ToString(), Directory.GetCurrentDirectory());
                        if (!exportbool)
                        {
                            LogBox.Text += $"[LOG] Error Getting uasset\n";
                            return;
                        }

                        //Researcher.DelStructs(mainasset);


                        foreach (var swap in asset.swaps)
                        {
                            string Researchertemp = swap.Researcher;
                            //MessageBox.Show(Researchertemp.ToLower().ToString());
                            if (Researchertemp.ToLower().ToString() == "string")
                            {
                                string swap1 = swap.search;
                                string swap2 = swap.replace;

                                bool swapbool = Researcher.ConvertInUasset(mainasset, swap1.ToString(), swap2.ToString());
                                if (swap.log != null)
                                {
                                    if(swapbool)
                                        LogBox.Text += $"[LOG] {swap.log} added\n";
                                    else
                                    {
                                        LogBox.Text += $"[LOG] {swap.log} error\n";
                                        return;
                                    }
                                        
                                }
                                
                            }
                            else if (Researchertemp.ToLower().ToString() == "byte")
                            {
                                byte[] swap1 = Convert.FromBase64String(swap.search);
                                byte[] swap2 = Convert.FromBase64String(swap.replace);
                                bool swapbool = Researcher.ConvertInUasset(mainasset, Encoding.UTF8.GetString(swap1), Encoding.UTF8.GetString(swap2));
                                if (!swap.log == null)
                                {
                                    if (swapbool)
                                        LogBox.Text += $"[LOG] {swap.log} added\n";
                                    else
                                    {
                                        LogBox.Text += $"[LOG] {swap.log} error\n";
                                        return;
                                    }

                                }
                            }
                        }

                        Oodle.Oodle.Compress(mainasset, mainasset + ".Compressed");

                        var dataswap = File.ReadAllBytes(mainasset + ".Compressed");

                        var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                        bool SwapUassetBool = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                        if (!SwapUassetBool)
                        {
                            LogBox.Text += $"[LOG] Error adding Uasset\n";
                            return;
                        }

                        try
                        {
                            PaksLocations.DeleteDirectory("FortniteGame");
                        }
                        catch { }
                   }

                    LogBox.Text += $"[LOG] Converted!\n";

                }
            }
        }
    }
}
