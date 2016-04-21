namespace EyeCT4RailsUI.Forms.Reparatiesysteem
{
    partial class frmRS
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
            this.ucMain = new EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls.ucReparatie();
            this.SuspendLayout();
            // 
            // ucMain
            // 
            this.ucMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMain.Location = new System.Drawing.Point(0, 0);
            this.ucMain.Name = "ucMain";
            this.ucMain.Size = new System.Drawing.Size(777, 458);
            this.ucMain.TabIndex = 0;
            // 
            // frmRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 455);
            this.Controls.Add(this.ucMain);
            this.Name = "frmRS";
            this.Text = "Schoonmaaksysteem";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucReparatie ucMain;
    }
}