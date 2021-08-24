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
    public partial class SkinSwapperCP : MaterialForm
    {
        public SkinSwapperCP()
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
                    string swapsicon = "https://static.wikia.nocookie.net/fortnite/images/f/f6/Recruit_3_%28Chapter_2%29_-_Outfit_-_Fortnite.png/revision/latest?cb=20191016000217";
                    pictureBox1.ImageLocation = swapsicon.ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Text = skinsname.Replace("_", " ").Replace("cp", "Default to").ToString();
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
                    var maleuasset = "FortniteGame/Content/Athena/Heroes/Meshes/Bodies/CP_Body_Commando_F_RebirthDefaultA.uasset";
                    var femaleuasset = "FortniteGame/Content/Athena/Heroes/Meshes/Bodies/CP_Athena_Body_M_RebirthSoldier.uasset";

                    bool exportbool = Engine.ExportCompressed(maleuasset.ToString(), Directory.GetCurrentDirectory());
                    if (!exportbool)
                    {
                        LogBox.Text += $"[LOG] Error Getting uasset\n";
                        return;
                    }

                    LogBox.Text += $"[LOG] Character Part 1/2 added\n";
                    LogBox.Text += $"[LOG] Character Part 2/2 added\n";

                    Oodle.Oodle.Compress(maleuasset, maleuasset + ".Compressed");

                    var dataswap = File.ReadAllBytes(maleuasset + ".Compressed");

                    var utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                    bool SwapUassetBool = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                    if (!SwapUassetBool)
                    {
                        LogBox.Text += $"[LOG] Error adding Uasset\n";
                        return;
                    }

                    bool exportbool1 = Engine.ExportCompressed(femaleuasset.ToString(), Directory.GetCurrentDirectory());
                    if (!exportbool1)
                    {
                        LogBox.Text += $"[LOG] Error Getting uasset\n";
                        return;
                    }


                    Oodle.Oodle.Compress(maleuasset, maleuasset + ".Compressed");

                    dataswap = File.ReadAllBytes(maleuasset + ".Compressed");

                    utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

                    bool SwapUassetBool1 = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap);
                    if (!SwapUassetBool1)
                    {
                        LogBox.Text += $"[LOG] Error adding Uasset\n";
                        return;
                    }

                    var uasset = "FortniteGame/Content/Balance/DefaultGameDataCosmetics.uasset";


                    bool exportbool2 = Engine.ExportCompressed(maleuasset.ToString(), Directory.GetCurrentDirectory());
                    if (!exportbool2)
                    {
                        LogBox.Text += $"[LOG] Error Getting uasset\n";
                        return;
                    }
                    LogBox.Text += $"[LOG] Body added\n";
                    LogBox.Text += $"[LOG] Head added\n";


                    Oodle.Oodle.Compress(maleuasset, maleuasset + ".Compressed");

                    dataswap = File.ReadAllBytes(maleuasset + ".Compressed");

                    utocTucas = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

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

        public void InvalidConvert()
        {
            var maleuasset = "FortniteGame/Content/Athena/Heroes/Meshes/Bodies/CP_Body_Commando_F_RebirthDefaultA.uasset";
            var femaleuasset = "FortniteGame/Content/Athena/Heroes/Meshes/Bodies/CP_Athena_Body_M_RebirthSoldier.uasset";

            bool exportbool = Engine.ExportCompressed(maleuasset.ToString(), Directory.GetCurrentDirectory());
            if (!exportbool)
            {
                LogBox.Text += $"[LOG] Error Getting uasset\n";
                return;
            }

            byte[] c = { 34, 67, 80, 95, 66, 111, 100, 121, 95, 67, 111, 109, 109, 97, 110, 100, 111, 95, 70, 95, 82, 101, 98, 105, 114, 116, 104, 68, 101, 102, 97, 117, 108, 116, 65 };
            byte[] d = { 106, 117, 105, 99, 121 };

            bool swapbool1 = Researcher.ConvertInUasset(maleuasset, c, d);
            if (swapbool1)
                LogBox.Text += $"[LOG] Character Part 1/2 added\n";
            else
            {
                LogBox.Text += $"[LOG] Character Part 1/2 error\n";
                return;
            }

            Oodle.Oodle.Compress(maleuasset, maleuasset + ".Compressed");

            var dataswap = File.ReadAllBytes(maleuasset + ".Compressed");

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

            bool exportbool1 = Engine.ExportCompressed(femaleuasset.ToString(), Directory.GetCurrentDirectory());
            if (!exportbool1)
            {
                LogBox.Text += $"[LOG] Error Getting uasset\n";
                return;
            }

            byte[] a = { 0, 31, 67, 80, 95, 65, 116, 104, 101, 110, 97, 95, 66, 111, 100, 121, 95, 77, 95, 82, 101, 98, 105, 114, 116, 104, 83, 111, 108, 100, 105, 101, 114 };
            byte[] b = { 106, 117, 105, 99, 121 };

            bool swapbool11 = Researcher.ConvertInUasset(femaleuasset, a, b);
            if (swapbool11)
                LogBox.Text += $"[LOG] Character Part 2/2 added\n";
            else
            {
                LogBox.Text += $"[LOG] Character Part 2/2 error\n";
                return;
            }

            Oodle.Oodle.Compress(femaleuasset, femaleuasset + ".Compressed");

            var dataswap1 = File.ReadAllBytes(femaleuasset + ".Compressed");

            var utocTucas1 = CUE4Parse.Kaede.PakFile.Replace("utoc", "ucas");

            bool SwapUassetBool1 = Researcher.SwapUasset($"{Fortnite.GetEpicInstallLocations().FirstOrDefault(x => x.AppName == "Fortnite")?.InstallLocation}\\FortniteGame\\Content\\Paks\\{utocTucas1.Replace("10", "100")}", CUE4Parse.Kaede.offset, dataswap1);
            if (!SwapUassetBool1)
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

        public void swapcp(string body, string head)
        {
            var uasset = "FortniteGame/Content/Balance/DefaultGameDataCosmetics.uasset";
            //body
            bool exportbool = Engine.ExportCompressed(uasset.ToString(), Directory.GetCurrentDirectory());
            if (!exportbool)
            {
                LogBox.Text += $"[LOG] Error Getting uasset\n";
                return;
            }

            bool swapbool = Researcher.ConvertInUasset(uasset, "/Game/Animation/Game/MainPlayer/Combat/Melee/DualWield/AncientGladiator/AncientGladiator_DualWield_Harvesting_Combo_M.AncientGladiator_DualWield_Harvesting_Combo_M", body.ToString());
            if (swapbool)
                LogBox.Text += $"[LOG] Body added\n";
            else
            {
                LogBox.Text += $"[LOG] Body error\n";
                return;
            }

            bool swapbool1 = Researcher.ConvertInUasset(uasset, "/Game/Animation/Game/MainPlayer/Combat/Melee/DualWield/Embers/Embers_DualWield_Harvesting_Combo_M.Embers_DualWield_Harvesting_Combo_M", head.ToString());
            if (swapbool1)
                LogBox.Text += $"[LOG] Head added\n";
            else
            {
                LogBox.Text += $"[LOG] Head error\n";
                return;
            }

            byte[] a = new byte[] { 2, 0, 0, 0, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 123 };
            byte[] b = new byte[] { 2, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13 };

            bool swapbool2 = Researcher.ConvertInUasset(uasset, a, b);
            if (!swapbool2)
            {
                LogBox.Text += "[LOG] ERROR";
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

                    InvalidConvert();

                    string a = cosmetic.Body;
                    string b = cosmetic.Head;
                    swapcp(a.ToString(), b.ToString());

                    LogBox.Text += $"[LOG] Converted!\n";

                }
            }
        }
    }
}
