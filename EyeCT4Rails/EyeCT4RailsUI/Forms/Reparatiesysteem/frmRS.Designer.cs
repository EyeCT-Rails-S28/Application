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
            this.ucMainRS1 = new EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls.ucMainRS();
            this.SuspendLayout();
            // 
            // ucMainRS1
            // 
            this.ucMainRS1.Location = new System.Drawing.Point(1, 1);
            this.ucMainRS1.Name = "ucMainRS1";
            this.ucMainRS1.Size = new System.Drawing.Size(659, 424);
            this.ucMainRS1.TabIndex = 0;
            // 
            // frmRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 425);
            this.Controls.Add(this.ucMainRS1);
            this.Name = "frmRS";
            this.Text = "Schoonmaaksysteem";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucMainRS ucMainRS1;
    }
}