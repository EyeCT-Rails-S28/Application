namespace EyeCT4RailsUI
{
    partial class frmBs
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
            this.ucMain = new EyeCT4RailsUI.Forms.frmBS.Main();
            this.SuspendLayout();
            // 
            // ucMain
            // 
            this.ucMain.Location = new System.Drawing.Point(0, 0);
            this.ucMain.Name = "ucMain";
            this.ucMain.Size = new System.Drawing.Size(1123, 522);
            this.ucMain.TabIndex = 0;
            // 
            // frmBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 522);
            this.Controls.Add(this.ucMain);
            this.Name = "frmBs";
            this.Text = "Beheersysteem";
            this.Resize += new System.EventHandler(this.frmBs_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.frmBS.Main ucMain;
    }
}

