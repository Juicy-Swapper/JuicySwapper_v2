
namespace JuicySwapper_V2
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.TabIcons = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.DashBoredTab = new System.Windows.Forms.TabPage();
            this.SkinsTab = new System.Windows.Forms.TabPage();
            this.skinTab1 = new JuicySwapper_V2.Pannels.SkinTab();
            this.PickaxesTab = new System.Windows.Forms.TabPage();
            this.BackblingsTab = new System.Windows.Forms.TabPage();
            this.EmotesTab = new System.Windows.Forms.TabPage();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.materialTabControl1.SuspendLayout();
            this.SkinsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabIcons
            // 
            this.TabIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.TabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabIcons.ImageStream")));
            this.TabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TabIcons.Images.SetKeyName(0, "Wrap.png");
            this.TabIcons.Images.SetKeyName(1, "Backbling.png");
            this.TabIcons.Images.SetKeyName(2, "Emote.png");
            this.TabIcons.Images.SetKeyName(3, "Pickaxe.png");
            this.TabIcons.Images.SetKeyName(4, "Settings.png");
            this.TabIcons.Images.SetKeyName(5, "Skin.png");
            this.TabIcons.Images.SetKeyName(6, "Dashboard.png");
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.DashBoredTab);
            this.materialTabControl1.Controls.Add(this.SkinsTab);
            this.materialTabControl1.Controls.Add(this.PickaxesTab);
            this.materialTabControl1.Controls.Add(this.BackblingsTab);
            this.materialTabControl1.Controls.Add(this.EmotesTab);
            this.materialTabControl1.Controls.Add(this.MiscTab);
            this.materialTabControl1.Controls.Add(this.SettingsTab);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.TabIcons;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(904, 349);
            this.materialTabControl1.TabIndex = 0;
            // 
            // DashBoredTab
            // 
            this.DashBoredTab.ImageKey = "Dashboard.png";
            this.DashBoredTab.Location = new System.Drawing.Point(4, 39);
            this.DashBoredTab.Name = "DashBoredTab";
            this.DashBoredTab.Size = new System.Drawing.Size(896, 306);
            this.DashBoredTab.TabIndex = 6;
            this.DashBoredTab.Text = "DashBored";
            this.DashBoredTab.UseVisualStyleBackColor = true;
            // 
            // SkinsTab
            // 
            this.SkinsTab.Controls.Add(this.skinTab1);
            this.SkinsTab.ImageKey = "Skin.png";
            this.SkinsTab.Location = new System.Drawing.Point(4, 39);
            this.SkinsTab.Name = "SkinsTab";
            this.SkinsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SkinsTab.Size = new System.Drawing.Size(896, 306);
            this.SkinsTab.TabIndex = 0;
            this.SkinsTab.Text = "Skins";
            this.SkinsTab.UseVisualStyleBackColor = true;
            // 
            // skinTab1
            // 
            this.skinTab1.AutoScroll = true;
            this.skinTab1.BackColor = System.Drawing.Color.Transparent;
            this.skinTab1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTab1.Location = new System.Drawing.Point(3, 3);
            this.skinTab1.Name = "skinTab1";
            this.skinTab1.Size = new System.Drawing.Size(890, 300);
            this.skinTab1.TabIndex = 0;
            // 
            // PickaxesTab
            // 
            this.PickaxesTab.ImageKey = "Pickaxe.png";
            this.PickaxesTab.Location = new System.Drawing.Point(4, 39);
            this.PickaxesTab.Name = "PickaxesTab";
            this.PickaxesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PickaxesTab.Size = new System.Drawing.Size(896, 306);
            this.PickaxesTab.TabIndex = 1;
            this.PickaxesTab.Text = "Pickaxes";
            this.PickaxesTab.UseVisualStyleBackColor = true;
            // 
            // BackblingsTab
            // 
            this.BackblingsTab.ImageKey = "Backbling.png";
            this.BackblingsTab.Location = new System.Drawing.Point(4, 39);
            this.BackblingsTab.Name = "BackblingsTab";
            this.BackblingsTab.Size = new System.Drawing.Size(896, 306);
            this.BackblingsTab.TabIndex = 2;
            this.BackblingsTab.Text = "BackBlings";
            this.BackblingsTab.UseVisualStyleBackColor = true;
            // 
            // EmotesTab
            // 
            this.EmotesTab.ImageKey = "Emote.png";
            this.EmotesTab.Location = new System.Drawing.Point(4, 39);
            this.EmotesTab.Name = "EmotesTab";
            this.EmotesTab.Size = new System.Drawing.Size(896, 306);
            this.EmotesTab.TabIndex = 3;
            this.EmotesTab.Text = "Emotes";
            this.EmotesTab.UseVisualStyleBackColor = true;
            // 
            // MiscTab
            // 
            this.MiscTab.ImageKey = "Wrap.png";
            this.MiscTab.Location = new System.Drawing.Point(4, 39);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(896, 306);
            this.MiscTab.TabIndex = 4;
            this.MiscTab.Text = "Misc";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTab
            // 
            this.SettingsTab.ImageKey = "Settings.png";
            this.SettingsTab.Location = new System.Drawing.Point(4, 39);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(896, 306);
            this.SettingsTab.TabIndex = 5;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 416);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🧃 • Juicy Swapper";
            this.materialTabControl1.ResumeLayout(false);
            this.SkinsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList TabIcons;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage SkinsTab;
        private System.Windows.Forms.TabPage PickaxesTab;
        private System.Windows.Forms.TabPage BackblingsTab;
        private System.Windows.Forms.TabPage EmotesTab;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.TabPage DashBoredTab;
        private Pannels.SkinTab skinTab1;
        private System.Windows.Forms.TabPage SettingsTab;
    }
}

