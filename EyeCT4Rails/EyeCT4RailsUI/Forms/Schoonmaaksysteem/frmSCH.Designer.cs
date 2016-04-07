namespace EyeCT4RailsUI.Forms.Beheersysteem
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
            this.ucMainSCH = new EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls.ucMainSCH();
            this.SuspendLayout();
            // 
            // ucMainSCH
            // 
            this.ucMainSCH.Location = new System.Drawing.Point(0, 0);
            this.ucMainSCH.Name = "ucMainSCH";
            this.ucMainSCH.Size = new System.Drawing.Size(646, 425);
            this.ucMainSCH.TabIndex = 0;
            // 
            // frmSCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 429);
            this.Controls.Add(this.ucMainSCH);
            this.Name = "frmSCH";
            this.Text = "frmSCH";
            this.ResumeLayout(false);

        }

        #endregion

        private Schoonmaaksysteem.UserControls.ucMainSCH ucMainSCH;
    }
}