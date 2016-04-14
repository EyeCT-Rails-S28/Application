using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem
{
    partial class frmSCH
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
            this.ucMain = new EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls.ucSchoonmaak();
            this.SuspendLayout();
            // 
            // ucMain
            // 
            this.ucMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMain.Location = new System.Drawing.Point(0, 0);
            this.ucMain.Name = "ucMain";
            this.ucMain.Size = new System.Drawing.Size(653, 429);
            this.ucMain.TabIndex = 0;
            // 
            // frmSCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 429);
            this.Controls.Add(this.ucMain);
            this.Name = "frmSCH";
            this.Text = "frmSCH";
            this.ResumeLayout(false);

        }

        #endregion

        private Schoonmaaksysteem.UserControls.ucSchoonmaak ucMain;
    }
}