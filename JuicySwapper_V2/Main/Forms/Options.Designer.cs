
namespace JuicySwapper_V2.Main.Forms
{
    partial class Options
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
            this.SkinDisplayIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // SkinDisplayIcons
            // 
            this.SkinDisplayIcons.AutoSize = true;
            this.SkinDisplayIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkinDisplayIcons.Location = new System.Drawing.Point(3, 64);
            this.SkinDisplayIcons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SkinDisplayIcons.Name = "SkinDisplayIcons";
            this.SkinDisplayIcons.Size = new System.Drawing.Size(223, 62);
            this.SkinDisplayIcons.TabIndex = 1;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(229, 129);
            this.Controls.Add(this.SkinDisplayIcons);
            this.MaximizeBox = false;
            this.Name = "Options";
            this.Sizable = false;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SkinDisplayIcons;
    }
}