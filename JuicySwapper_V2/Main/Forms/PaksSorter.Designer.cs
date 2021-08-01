
namespace JuicySwapper_V2
{
    partial class PaksSorter
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Textlb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Textlb
            // 
            this.Textlb.AutoSize = true;
            this.Textlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Textlb.Location = new System.Drawing.Point(6, 73);
            this.Textlb.Name = "Textlb";
            this.Textlb.Size = new System.Drawing.Size(402, 34);
            this.Textlb.TabIndex = 2;
            this.Textlb.Text = "Looks like your paks are all good. Now redirecting to swapper! \r\nEnjoy Swapping -" +
    " Juicy Team.";
            // 
            // PaksSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 150);
            this.Controls.Add(this.Textlb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaksSorter";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juicy - Sorting Paks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Textlb;
    }
}