
namespace JuicySwapper_V2.Pannels
{
    partial class SkinTab
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

        #region Component Designer generated code

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
            this.SkinDisplayIcons.AutoScroll = true;
            this.SkinDisplayIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkinDisplayIcons.Location = new System.Drawing.Point(0, 0);
            this.SkinDisplayIcons.Name = "SkinDisplayIcons";
            this.SkinDisplayIcons.Size = new System.Drawing.Size(859, 385);
            this.SkinDisplayIcons.TabIndex = 0;
            // 
            // SkinTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SkinDisplayIcons);
            this.Name = "SkinTab";
            this.Size = new System.Drawing.Size(859, 385);
            this.Load += new System.EventHandler(this.SkinTab_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SkinDisplayIcons;
    }
}
