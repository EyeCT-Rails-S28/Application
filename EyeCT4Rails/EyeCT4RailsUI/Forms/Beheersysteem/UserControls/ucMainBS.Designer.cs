
namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class ucMainRs
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
            this.lblTram = new System.Windows.Forms.Label();
            this.lblSpoor = new System.Windows.Forms.Label();
            this.tbTram = new System.Windows.Forms.TextBox();
            this.tbSpoor = new System.Windows.Forms.TextBox();
            this.lblReserveringen = new System.Windows.Forms.Label();
            this.lbReserveringen = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlTracks = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTram
            // 
            this.lblTram.AutoSize = true;
            this.lblTram.Location = new System.Drawing.Point(13, 39);
            this.lblTram.Name = "lblTram";
            this.lblTram.Size = new System.Drawing.Size(34, 13);
            this.lblTram.TabIndex = 1;
            this.lblTram.Text = "Tram:";
            // 
            // lblSpoor
            // 
            this.lblSpoor.AutoSize = true;
            this.lblSpoor.Location = new System.Drawing.Point(13, 103);
            this.lblSpoor.Name = "lblSpoor";
            this.lblSpoor.Size = new System.Drawing.Size(38, 13);
            this.lblSpoor.TabIndex = 2;
            this.lblSpoor.Text = "Spoor:";
            // 
            // tbTram
            // 
            this.tbTram.Location = new System.Drawing.Point(16, 65);
            this.tbTram.Name = "tbTram";
            this.tbTram.Size = new System.Drawing.Size(120, 20);
            this.tbTram.TabIndex = 3;
            // 
            // tbSpoor
            // 
            this.tbSpoor.Location = new System.Drawing.Point(16, 136);
            this.tbSpoor.Name = "tbSpoor";
            this.tbSpoor.Size = new System.Drawing.Size(120, 20);
            this.tbSpoor.TabIndex = 4;
            // 
            // lblReserveringen
            // 
            this.lblReserveringen.AutoSize = true;
            this.lblReserveringen.Location = new System.Drawing.Point(16, 178);
            this.lblReserveringen.Name = "lblReserveringen";
            this.lblReserveringen.Size = new System.Drawing.Size(79, 13);
            this.lblReserveringen.TabIndex = 5;
            this.lblReserveringen.Text = "Reserveringen:";
            // 
            // lbReserveringen
            // 
            this.lbReserveringen.FormattingEnabled = true;
            this.lbReserveringen.Location = new System.Drawing.Point(16, 208);
            this.lbReserveringen.Name = "lbReserveringen";
            this.lbReserveringen.Size = new System.Drawing.Size(120, 160);
            this.lbReserveringen.TabIndex = 6;
            // 
            // pnlTracks
            // 
            this.pnlTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTracks.Location = new System.Drawing.Point(142, 39);
            this.pnlTracks.Name = "pnlTracks";
            this.pnlTracks.Size = new System.Drawing.Size(654, 469);
            this.pnlTracks.TabIndex = 7;
            this.pnlTracks.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlTracks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlTracks_MouseClick);
            // 
            // ucMainRs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTracks);
            this.Controls.Add(this.lbReserveringen);
            this.Controls.Add(this.lblReserveringen);
            this.Controls.Add(this.tbSpoor);
            this.Controls.Add(this.tbTram);
            this.Controls.Add(this.lblSpoor);
            this.Controls.Add(this.lblTram);
            this.Name = "ucMainRs";
            this.Size = new System.Drawing.Size(796, 508);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTram;
        private System.Windows.Forms.Label lblSpoor;
        private System.Windows.Forms.TextBox tbTram;
        private System.Windows.Forms.TextBox tbSpoor;
        private System.Windows.Forms.Label lblReserveringen;
        private System.Windows.Forms.ListBox lbReserveringen;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlTracks;
    }
}
