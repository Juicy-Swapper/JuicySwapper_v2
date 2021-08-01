using JuicySwapper_V2.Main.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuicySwapper_V2.Pannels
{
    public partial class SkinTab : UserControl
    {
        public SkinTab()
        {
            InitializeComponent();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            vars.item = ((Bunifu.Framework.UI.BunifuImageButton)sender).Name;
            new SkinSwapper().ShowDialog();
        }

        private void SkinTab_Load(object sender, EventArgs e)
        {
            WebClient ProgramClient = new();

            dynamic parsed = JObject.Parse(ProgramClient.DownloadString("https://juicyswapper.netlify.app/api/v1/Skins.json"));

            foreach (var Cosmetic in parsed.skins)
            {
                Bunifu.Framework.UI.BunifuImageButton newPic = new Bunifu.Framework.UI.BunifuImageButton();
                newPic.ImageLocation = Cosmetic.icon;
                newPic.Name = Cosmetic.name;
                Cursor = Cursors.Hand;
                newPic.SizeMode = PictureBoxSizeMode.Zoom;
                newPic.Size = new Size(71, 71);
                newPic.ImageActive = null;
                newPic.BackColor = Color.Transparent;
                newPic.Click += buttonOn_Click;
                SkinDisplayIcons.Controls.Add(newPic);
            }
        }
    }
}
