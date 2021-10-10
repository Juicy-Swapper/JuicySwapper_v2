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
    public partial class EmoteSwapperTakeElf : MaterialForm
    {
        public EmoteSwapperTakeElf()
        {
            InitializeComponent();

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

            try
            {
                dynamic parsed = JObject.Parse(File.ReadAllText(vars.JsonRead.ToString()));

                foreach (var cosmetic in parsed.items)
                {
                    string skinsname = cosmetic.name;
                    
                    if (skinsname.ToString().Contains(vars.item))
                    {
                        skinsname = skinsname.Replace("_", " ");
                        string swapsicon = "https://fortnite-api.com/images/cosmetics/br/EID_TakeTheElf/smallicon.png";
                        pictureBox1.ImageLocation = swapsicon.ToString();
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        Text = skinsname;
                        if (cosmetic.ExtraInfo != null)
                        {
                            string info = cosmetic.ExtraInfo;
                            MessageBox.Show(info.ToString(), $"Extra Info - {skinsname.Replace("_", " ")}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    var uasset = "FortniteGame/Content/Athena/Items/Cosmetics/Dances/EID_TakeTheElf.uasset";


                    bool exportbool2 = Engine.ExportCompressed(uasset.ToString(), Directory.GetCurrentDirectory());
                    if (!exportbool2)
                    {
                        LogBox.Text += $"[LOG] Error Getting uasset\n";
                        return;
                    }
                    LogBox.Text += $"[LOG] Dance 1/2 removed\n";
                    LogBox.Text += $"[LOG] Dance 2/2 removed\n";


                    Oodle.Oodle.Compress(uasset, uasset + ".Compressed");

                    var dataswap = File.ReadAllBytes(uasset + ".Compressed");

                    var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                    bool SwapUassetBool2 = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                    if (!SwapUassetBool2)
                    {
                        LogBox.Text += $"[LOG] Error adding Uasset\n";
                        return;
                    }
                    LogBox.Text += $"[LOG] Reverted!\n";
                }
            }
        }

        public void swapcp(string CMF, string CMM)
        {
            var uasset = "FortniteGame/Content/Athena/Items/Cosmetics/Dances/EID_TakeTheElf.uasset";
            //body
            bool exportbool = Engine.ExportCompressed(uasset.ToString(), Directory.GetCurrentDirectory());
            if (!exportbool)
            {
                LogBox.Text += $"[LOG] Error Getting uasset\n";
                return;
            }

            bool swapbool = Researcher.ConvertInUasset(uasset, "/Game/Animation/Game/MainPlayer/Emotes/Take_The_Elf/Emote_Take_The_Elf_CMF_M.Emote_Take_The_Elf_CMF_M", CMF.ToString());
            if (swapbool)
                LogBox.Text += $"[LOG] Dance 1/2 added\n";
            else
            {
                LogBox.Text += $"[LOG] Dance 1/2 error\n";
                return;
            }

            bool swapbool1 = Researcher.ConvertInUasset(uasset, "/Game/Animation/Game/MainPlayer/Emotes/Take_The_Elf/Emote_Take_The_Elf_CMM_M.Emote_Take_The_Elf_CMM_M", CMM.ToString());
            if (swapbool1)
                LogBox.Text += $"[LOG] Dance 2/2 added\n";
            else
            {
                LogBox.Text += $"[LOG] Dance 2/2 error\n";
                return;
            }

            Oodle.Oodle.Compress(uasset, uasset + ".Compressed");

            var dataswap = File.ReadAllBytes(uasset + ".Compressed");

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

                    string a = cosmetic.CMF;
                    string b = cosmetic.CMM;
                    swapcp(a.ToString(), b.ToString());

                    LogBox.Text += $"[LOG] Converted!\n";

                }
            }
        }
    }
}
