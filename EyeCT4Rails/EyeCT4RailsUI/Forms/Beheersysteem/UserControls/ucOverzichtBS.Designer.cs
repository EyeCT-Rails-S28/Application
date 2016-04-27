
namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcOverzichtBs
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
            this.components = new System.ComponentModel.Container();
            this.lblTram = new System.Windows.Forms.Label();
            this.lblSpoor = new System.Windows.Forms.Label();
            this.tbTram = new System.Windows.Forms.TextBox();
            this.tbSpoor = new System.Windows.Forms.TextBox();
            this.lblReserveringen = new System.Windows.Forms.Label();
            this.lbReserveringen = new System.Windows.Forms.ListBox();
            this.pnlTracks = new System.Windows.Forms.Panel();
            this.lblSeletedTrack = new System.Windows.Forms.Label();
            this.lblSelectedSection = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reserveringPlaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTramWijzigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dienstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramVerwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramPlaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleBlokkadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.spoorInformatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
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
            this.pnlTracks.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTracks_Paint);
            this.pnlTracks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlTracks_MouseClick);
            // 
            // lblSeletedTrack
            // 
            this.lblSeletedTrack.AutoSize = true;
            this.lblSeletedTrack.Location = new System.Drawing.Point(139, 14);
            this.lblSeletedTrack.Name = "lblSeletedTrack";
            this.lblSeletedTrack.Size = new System.Drawing.Size(79, 13);
            this.lblSeletedTrack.TabIndex = 8;
            this.lblSeletedTrack.Text = "Selected track:";
            // 
            // lblSelectedSection
            // 
            this.lblSelectedSection.AutoSize = true;
            this.lblSelectedSection.Location = new System.Drawing.Point(279, 14);
            this.lblSelectedSection.Name = "lblSelectedSection";
            this.lblSelectedSection.Size = new System.Drawing.Size(89, 13);
            this.lblSelectedSection.TabIndex = 9;
            this.lblSelectedSection.Text = "Selected section:";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reserveringPlaatsenToolStripMenuItem,
            this.statusTramWijzigenToolStripMenuItem,
            this.tramVerwijderenToolStripMenuItem,
            this.tramPlaatsenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toggleBlokkadeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.spoorInformatieToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(183, 170);
            this.contextMenuStrip.Opened += new System.EventHandler(this.contextMenuStrip_Opened);
            // 
            // reserveringPlaatsenToolStripMenuItem
            // 
            this.reserveringPlaatsenToolStripMenuItem.Name = "reserveringPlaatsenToolStripMenuItem";
            this.reserveringPlaatsenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.reserveringPlaatsenToolStripMenuItem.Text = "Reservering plaatsen";
            this.reserveringPlaatsenToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // statusTramWijzigenToolStripMenuItem
            // 
            this.statusTramWijzigenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defectToolStripMenuItem,
            this.schoonmaakToolStripMenuItem,
            this.remiseToolStripMenuItem,
            this.dienstToolStripMenuItem});
            this.statusTramWijzigenToolStripMenuItem.Name = "statusTramWijzigenToolStripMenuItem";
            this.statusTramWijzigenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.statusTramWijzigenToolStripMenuItem.Text = "Status tram wijzigen";
            this.statusTramWijzigenToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // defectToolStripMenuItem
            // 
            this.defectToolStripMenuItem.Name = "defectToolStripMenuItem";
            this.defectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.defectToolStripMenuItem.Text = "Defect";
            this.defectToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // schoonmaakToolStripMenuItem
            // 
            this.schoonmaakToolStripMenuItem.Name = "schoonmaakToolStripMenuItem";
            this.schoonmaakToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.schoonmaakToolStripMenuItem.Text = "Schoonmaak";
            this.schoonmaakToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // remiseToolStripMenuItem
            // 
            this.remiseToolStripMenuItem.Name = "remiseToolStripMenuItem";
            this.remiseToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.remiseToolStripMenuItem.Text = "Remise";
            this.remiseToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // dienstToolStripMenuItem
            // 
            this.dienstToolStripMenuItem.Name = "dienstToolStripMenuItem";
            this.dienstToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.dienstToolStripMenuItem.Text = "Dienst";
            this.dienstToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // tramVerwijderenToolStripMenuItem
            // 
            this.tramVerwijderenToolStripMenuItem.Name = "tramVerwijderenToolStripMenuItem";
            this.tramVerwijderenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tramVerwijderenToolStripMenuItem.Text = "Tram verwijderen";
            this.tramVerwijderenToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // tramPlaatsenToolStripMenuItem
            // 
            this.tramPlaatsenToolStripMenuItem.Name = "tramPlaatsenToolStripMenuItem";
            this.tramPlaatsenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tramPlaatsenToolStripMenuItem.Text = "Tram plaatsen";
            this.tramPlaatsenToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // toggleBlokkadeToolStripMenuItem
            // 
            this.toggleBlokkadeToolStripMenuItem.Name = "toggleBlokkadeToolStripMenuItem";
            this.toggleBlokkadeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toggleBlokkadeToolStripMenuItem.Text = "Toggle Blokkade";
            this.toggleBlokkadeToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // timer
            // 
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // spoorInformatieToolStripMenuItem
            // 
            this.spoorInformatieToolStripMenuItem.Name = "spoorInformatieToolStripMenuItem";
            this.spoorInformatieToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.spoorInformatieToolStripMenuItem.Text = "Spoor Informatie";
            this.spoorInformatieToolStripMenuItem.Click += new System.EventHandler(this.menu_Click);
            // 
            // UcOverzichtBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.lblSelectedSection);
            this.Controls.Add(this.lblSeletedTrack);
            this.Controls.Add(this.pnlTracks);
            this.Controls.Add(this.lbReserveringen);
            this.Controls.Add(this.lblReserveringen);
            this.Controls.Add(this.tbSpoor);
            this.Controls.Add(this.tbTram);
            this.Controls.Add(this.lblSpoor);
            this.Controls.Add(this.lblTram);
            this.Name = "UcOverzichtBs";
            this.Size = new System.Drawing.Size(796, 508);
            this.Resize += new System.EventHandler(this.ucOverzichtBS_Resize);
            this.contextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlTracks;
        private System.Windows.Forms.Label lblSeletedTrack;
        private System.Windows.Forms.Label lblSelectedSection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem reserveringPlaatsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusTramWijzigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramVerwijderenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramPlaatsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dienstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toggleBlokkadeToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem spoorInformatieToolStripMenuItem;
    }
}
