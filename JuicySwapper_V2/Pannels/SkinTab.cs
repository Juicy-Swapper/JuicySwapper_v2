using JuicySwapper_V2.Main.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            vars.JsonRead = "Api\\Skins.json";
            vars.item = ((Bunifu.Framework.UI.BunifuImageButton)sender).Name;
            new SkinSwapper().ShowDialog();
        }

        private void buttonOn_CP_Click(object sender, EventArgs e)
        {
            vars.JsonRead = "Api\\Skins.json";
            vars.item = ((Bunifu.Framework.UI.BunifuImageButton)sender).Name;
            new SkinSwapperCP().ShowDialog();
        }

        private void buttonOn_Options_Click(object sender, EventArgs e)
        {
            vars.JsonRead = "Api\\Skins.json";
            vars.item = ((Bunifu.Framework.UI.BunifuImageButton)sender).Name;
            new Options().ShowDialog();
        }

        private void SkinTab_Load(object sender, EventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 12.0f,
                        FontStyle.Bold );

            Label label = new Label
            {
                Size = new Size(760, 35),
                Text = "Mesh Skins - Backblings work",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = font
            };
            SkinDisplayIcons.Controls.Add(label);



            dynamic parsed = JObject.Parse(File.ReadAllText("Api\\Skins.json"));
            
            foreach (var Cosmetic in parsed.items)
            {
                string NewName = Cosmetic.name;
                NewName = NewName.Replace("_", " ").ToLower();
                //MessageBox.Show(NewName);

                //PictureBox newPic = new();
                Bunifu.Framework.UI.BunifuImageButton newPic = new Bunifu.Framework.UI.BunifuImageButton();

                if (NewName.Contains("cp"))
                {
                    //nothing
                }
                else
                {
                    if (NewName.Contains("options"))
                    {
                        newPic.Click += buttonOn_Options_Click;
                    }
                    else
                        newPic.Click += buttonOn_Click;


                    Panel panelA = new Panel
                    {
                        Size = new Size(76, 76),
                        BackColor = Color.Transparent
                    };

                    newPic.ImageLocation = Cosmetic.icon;
                    newPic.Name = Cosmetic.name;
                    Cursor = Cursors.Hand;
                    newPic.SizeMode = PictureBoxSizeMode.Zoom;
                    newPic.Size = new Size(71, 71);
                    //newPic.ImageActive = null;
                    newPic.BackColor = Color.Transparent;
                    panelA.Controls.Add(newPic);
                    SkinDisplayIcons.Controls.Add(panelA);
                }

                
            }

            Label label1 = new Label
            {
                Size = new Size(760, 35),
                Text = "CP Skins - Backblings DONT work",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = font
            };

            SkinDisplayIcons.Controls.Add(label1);
            foreach (var Cosmetic in parsed.items)
            {
                string NewName = Cosmetic.name;
                NewName = NewName.Replace("_", " ").ToLower();
                //MessageBox.Show(NewName);

                //PictureBox newPic = new();
                Bunifu.Framework.UI.BunifuImageButton newPic = new Bunifu.Framework.UI.BunifuImageButton();

                if (!NewName.Contains("cp"))
                {
                    //nothing
                }
                else
                {
                    newPic.Click += buttonOn_CP_Click;


                    Panel panelA = new Panel
                    {
                        Size = new Size(76, 76),
                        BackColor = Color.Transparent
                    };

                    newPic.ImageLocation = Cosmetic.icon;
                    newPic.Name = Cosmetic.name;
                    Cursor = Cursors.Hand;
                    newPic.SizeMode = PictureBoxSizeMode.Zoom;
                    newPic.Size = new Size(71, 71);
                    //newPic.ImageActive = null;
                    newPic.BackColor = Color.Transparent;
                    panelA.Controls.Add(newPic);
                    SkinDisplayIcons.Controls.Add(panelA);
                }
            }
        }
    }
}
