
namespace JuicySwapper_V2.Pannels
{
    partial class BackBlingTab
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
            this.BackBlingDisplayIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BackBlingDisplayIcons
            // 
            this.BackBlingDisplayIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackBlingDisplayIcons.Location = new System.Drawing.Point(0, 0);
            this.BackBlingDisplayIcons.Name = "BackBlingDisplayIcons";
            this.BackBlingDisplayIcons.Size = new System.Drawing.Size(859, 385);
            this.BackBlingDisplayIcons.TabIndex = 0;
            // 
            // BackBlingTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BackBlingDisplayIcons);
            this.Name = "BackBlingTab";
            this.Size = new System.Drawing.Size(859, 385);
            this.Load += new System.EventHandler(this.BackBlingTab_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel BackBlingDisplayIcons;
    }
}
