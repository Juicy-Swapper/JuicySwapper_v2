
namespace JuicySwapper_V2.Main.Forms
{
    partial class SkinSwapperCP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConvertBtn = new MaterialSkin.Controls.MaterialButton();
            this.RevertBtn = new MaterialSkin.Controls.MaterialButton();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 155);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.ConvertBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConvertBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ConvertBtn.Depth = 0;
            this.ConvertBtn.HighEmphasis = true;
            this.ConvertBtn.Icon = null;
            this.ConvertBtn.Location = new System.Drawing.Point(182, 95);
            this.ConvertBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ConvertBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.ConvertBtn.Size = new System.Drawing.Size(88, 36);
            this.ConvertBtn.TabIndex = 1;
            this.ConvertBtn.Text = "Convert";
            this.ConvertBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ConvertBtn.UseAccentColor = false;
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.ConvertBtn_Click);
            // 
            // RevertBtn
            // 
            this.RevertBtn.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.RevertBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RevertBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RevertBtn.Depth = 0;
            this.RevertBtn.HighEmphasis = true;
            this.RevertBtn.Icon = null;
            this.RevertBtn.Location = new System.Drawing.Point(182, 143);
            this.RevertBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RevertBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RevertBtn.Name = "RevertBtn";
            this.RevertBtn.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.RevertBtn.Size = new System.Drawing.Size(89, 36);
            this.RevertBtn.TabIndex = 2;
            this.RevertBtn.Text = "    Revert   ";
            this.RevertBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RevertBtn.UseAccentColor = false;
            this.RevertBtn.UseVisualStyleBackColor = true;
            this.RevertBtn.Click += new System.EventHandler(this.RevertBtn_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(277, 72);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(248, 155);
            this.LogBox.TabIndex = 3;
            this.LogBox.Text = "";
            // 
            // SkinSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 239);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.RevertBtn);
            this.Controls.Add(this.ConvertBtn);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "SkinSwapper";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkinSwapper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialButton ConvertBtn;
        private MaterialSkin.Controls.MaterialButton RevertBtn;
        private System.Windows.Forms.RichTextBox LogBox;
    }
}