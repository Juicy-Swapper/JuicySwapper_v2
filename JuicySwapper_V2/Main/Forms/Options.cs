using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using System.Windows.Forms;
using MaterialSkin;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JuicySwapper_V2.Main.Forms
{
    public partial class Options : MaterialForm
    {
        private void buttonOn_Click(object sender, EventArgs e)
        {
            vars.optionskin = ((Bunifu.Framework.UI.BunifuImageButton)sender).Name;
            vars.item = Text.Replace(" ", "_");
            new SkinSwapperOptions().ShowDialog();
        }

        public Options()
        {
            InitializeComponent();
            var MsM = MaterialSkinManager.Instance;
            MsM.AddFormToManage(this);
            MsM.Theme = MaterialSkinManager.Themes.DARK;
            MsM.ColorScheme = new ColorScheme(Primary.Pink200, Primary.Grey900, Primary.Grey900,
                Accent.DeepOrange100, TextShade.WHITE);

            dynamic parsed = JObject.Parse(File.ReadAllText(vars.JsonRead.ToString()));

            int SkinsItems = 0;

            foreach (var cosmetic in parsed.items)
            {
                string skinsname = cosmetic.name;

                if (skinsname.ToString().Contains(vars.item))
                {
                    Text = skinsname.ToString().Replace("_", " ");
                    foreach (var options in cosmetic.Options)
                    {
                        SkinsItems += 1;

                        Panel panelA = new Panel
                        {
                            Size = new System.Drawing.Size(124, 124),
                            BackColor = Color.Transparent
                        };

                        Label labelA = new Label
                        {
                            Size = new Size(35, 10),
                            BackColor = Color.Transparent,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Text = null,
                            ForeColor = Color.Transparent
                        };

                        Bunifu.Framework.UI.BunifuImageButton newPic = new();
                        newPic.ImageLocation = options.icon;
                        string a = options.name;
                        newPic.Name = a.ToString();
                        //MessageBox.Show(a.ToString());
                        Cursor = Cursors.Hand;
                        newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                        newPic.Size = new Size(121, 121);
                        newPic.ImageActive = null;
                        newPic.BackColor = Color.Transparent;
                        newPic.Click += buttonOn_Click;
                        panelA.Controls.Add(newPic);
                        SkinDisplayIcons.Controls.Add(panelA);
                        SkinDisplayIcons.Controls.Add(labelA);
                    }
                }
            }

            Region = Region.FromHrgn(Ui.Round.CreateRoundRectRgn(0, 0, Width, Height, 14, 14));

        }
    }
}
