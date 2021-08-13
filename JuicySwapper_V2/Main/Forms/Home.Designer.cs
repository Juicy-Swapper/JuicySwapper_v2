
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
            this.dashBoardTab1 = new JuicySwapper_V2.Pannels.DashBoardTab();
            this.SkinsTab = new System.Windows.Forms.TabPage();
            this.skinTab1 = new JuicySwapper_V2.Pannels.SkinTab();
            this.PickaxesTabbb = new System.Windows.Forms.TabPage();
            this.pickaxeTab1 = new JuicySwapper_V2.Pannels.PickaxeTab();
            this.BackblingsTab = new System.Windows.Forms.TabPage();
            this.backBlingTab1 = new JuicySwapper_V2.Pannels.BackBlingTab();
            this.EmotesTab = new System.Windows.Forms.TabPage();
            this.emoteTab1 = new JuicySwapper_V2.Pannels.EmoteTab();
            this.MiscTab = new System.Windows.Forms.TabPage();
            this.miscTab1 = new JuicySwapper_V2.Pannels.MiscTab();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.settingsTab1 = new JuicySwapper_V2.Pannels.SettingsTab();
            this.materialTabControl1.SuspendLayout();
            this.DashBoredTab.SuspendLayout();
            this.SkinsTab.SuspendLayout();
            this.PickaxesTabbb.SuspendLayout();
            this.BackblingsTab.SuspendLayout();
            this.EmotesTab.SuspendLayout();
            this.MiscTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
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
            this.materialTabControl1.Controls.Add(this.PickaxesTabbb);
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
            this.DashBoredTab.Controls.Add(this.dashBoardTab1);
            this.DashBoredTab.ImageKey = "Dashboard.png";
            this.DashBoredTab.Location = new System.Drawing.Point(4, 39);
            this.DashBoredTab.Name = "DashBoredTab";
            this.DashBoredTab.Size = new System.Drawing.Size(896, 306);
            this.DashBoredTab.TabIndex = 6;
            this.DashBoredTab.Text = "DashBoard";
            this.DashBoredTab.UseVisualStyleBackColor = true;
            // 
            // dashBoardTab1
            // 
            this.dashBoardTab1.BackColor = System.Drawing.Color.Transparent;
            this.dashBoardTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashBoardTab1.Location = new System.Drawing.Point(0, 0);
            this.dashBoardTab1.Name = "dashBoardTab1";
            this.dashBoardTab1.Size = new System.Drawing.Size(896, 306);
            this.dashBoardTab1.TabIndex = 0;
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
            this.skinTab1.Location = new System.Drawing.Point(0, 0);
            this.skinTab1.Name = "skinTab1";
            this.skinTab1.Size = new System.Drawing.Size(890, 300);
            this.skinTab1.TabIndex = 0;
            // 
            // PickaxesTabbb
            // 
            this.PickaxesTabbb.Controls.Add(this.pickaxeTab1);
            this.PickaxesTabbb.ImageKey = "Pickaxe.png";
            this.PickaxesTabbb.Location = new System.Drawing.Point(4, 39);
            this.PickaxesTabbb.Name = "PickaxesTabbb";
            this.PickaxesTabbb.Padding = new System.Windows.Forms.Padding(3);
            this.PickaxesTabbb.Size = new System.Drawing.Size(896, 306);
            this.PickaxesTabbb.TabIndex = 1;
            this.PickaxesTabbb.Text = "Pickaxes";
            this.PickaxesTabbb.UseVisualStyleBackColor = true;
            // 
            // pickaxeTab1
            // 
            this.pickaxeTab1.BackColor = System.Drawing.Color.Transparent;
            this.pickaxeTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickaxeTab1.Location = new System.Drawing.Point(0, 0);
            this.pickaxeTab1.Name = "pickaxeTab1";
            this.pickaxeTab1.Size = new System.Drawing.Size(890, 300);
            this.pickaxeTab1.TabIndex = 0;
            // 
            // BackblingsTab
            // 
            this.BackblingsTab.Controls.Add(this.backBlingTab1);
            this.BackblingsTab.ImageKey = "Backbling.png";
            this.BackblingsTab.Location = new System.Drawing.Point(4, 39);
            this.BackblingsTab.Name = "BackblingsTab";
            this.BackblingsTab.Size = new System.Drawing.Size(896, 306);
            this.BackblingsTab.TabIndex = 2;
            this.BackblingsTab.Text = "BackBlings";
            this.BackblingsTab.UseVisualStyleBackColor = true;
            // 
            // backBlingTab1
            // 
            this.backBlingTab1.BackColor = System.Drawing.Color.Transparent;
            this.backBlingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backBlingTab1.Location = new System.Drawing.Point(0, 0);
            this.backBlingTab1.Name = "backBlingTab1";
            this.backBlingTab1.Size = new System.Drawing.Size(896, 306);
            this.backBlingTab1.TabIndex = 0;
            // 
            // EmotesTab
            // 
            this.EmotesTab.Controls.Add(this.emoteTab1);
            this.EmotesTab.ImageKey = "Emote.png";
            this.EmotesTab.Location = new System.Drawing.Point(4, 39);
            this.EmotesTab.Name = "EmotesTab";
            this.EmotesTab.Size = new System.Drawing.Size(896, 306);
            this.EmotesTab.TabIndex = 3;
            this.EmotesTab.Text = "Emotes";
            this.EmotesTab.UseVisualStyleBackColor = true;
            // 
            // emoteTab1
            // 
            this.emoteTab1.BackColor = System.Drawing.Color.Transparent;
            this.emoteTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emoteTab1.Location = new System.Drawing.Point(0, 0);
            this.emoteTab1.Name = "emoteTab1";
            this.emoteTab1.Size = new System.Drawing.Size(896, 306);
            this.emoteTab1.TabIndex = 0;
            // 
            // MiscTab
            // 
            this.MiscTab.Controls.Add(this.miscTab1);
            this.MiscTab.ImageKey = "Wrap.png";
            this.MiscTab.Location = new System.Drawing.Point(4, 39);
            this.MiscTab.Name = "MiscTab";
            this.MiscTab.Size = new System.Drawing.Size(896, 306);
            this.MiscTab.TabIndex = 4;
            this.MiscTab.Text = "Misc";
            this.MiscTab.UseVisualStyleBackColor = true;
            // 
            // miscTab1
            // 
            this.miscTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscTab1.Location = new System.Drawing.Point(0, 0);
            this.miscTab1.Name = "miscTab1";
            this.miscTab1.Size = new System.Drawing.Size(896, 306);
            this.miscTab1.TabIndex = 0;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.settingsTab1);
            this.SettingsTab.ImageKey = "Settings.png";
            this.SettingsTab.Location = new System.Drawing.Point(4, 39);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(896, 306);
            this.SettingsTab.TabIndex = 5;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // settingsTab1
            // 
            this.settingsTab1.BackColor = System.Drawing.Color.Transparent;
            this.settingsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTab1.Location = new System.Drawing.Point(0, 0);
            this.settingsTab1.Name = "settingsTab1";
            this.settingsTab1.Size = new System.Drawing.Size(896, 306);
            this.settingsTab1.TabIndex = 0;
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
            this.DashBoredTab.ResumeLayout(false);
            this.SkinsTab.ResumeLayout(false);
            this.PickaxesTabbb.ResumeLayout(false);
            this.BackblingsTab.ResumeLayout(false);
            this.EmotesTab.ResumeLayout(false);
            this.MiscTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList TabIcons;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage SkinsTab;
        private System.Windows.Forms.TabPage PickaxesTabbb;
        private System.Windows.Forms.TabPage BackblingsTab;
        private System.Windows.Forms.TabPage EmotesTab;
        private System.Windows.Forms.TabPage MiscTab;
        private System.Windows.Forms.TabPage DashBoredTab;
        private Pannels.SkinTab skinTab1;
        private System.Windows.Forms.TabPage SettingsTab;
        private Pannels.PickaxeTab pickaxeTab1;
        private Pannels.BackBlingTab backBlingTab1;
        private Pannels.EmoteTab emoteTab1;
        private Pannels.MiscTab miscTab1;
        private Pannels.SettingsTab settingsTab1;
        private Pannels.DashBoardTab dashBoardTab1;
    }
}

