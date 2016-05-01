
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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.spoorInformatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblRemise = new System.Windows.Forms.Label();
            this.lblSchoonmaak = new System.Windows.Forms.Label();
            this.lblReparatie = new System.Windows.Forms.Label();
            this.lblDienst = new System.Windows.Forms.Label();
            this.btnBevestig = new System.Windows.Forms.Button();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReserveringen
            // 
            this.lblReserveringen.AutoSize = true;
            this.lblReserveringen.Location = new System.Drawing.Point(12, 14);
            this.lblReserveringen.Name = "lblReserveringen";
            this.lblReserveringen.Size = new System.Drawing.Size(79, 13);
            this.lblReserveringen.TabIndex = 5;
            this.lblReserveringen.Text = "Reserveringen:";
            // 
            // lbReserveringen
            // 
            this.lbReserveringen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbReserveringen.FormattingEnabled = true;
            this.lbReserveringen.Location = new System.Drawing.Point(15, 39);
            this.lbReserveringen.Name = "lbReserveringen";
            this.lbReserveringen.Size = new System.Drawing.Size(120, 290);
            this.lbReserveringen.TabIndex = 6;
            this.lbReserveringen.SelectedIndexChanged += new System.EventHandler(this.lbReserveringen_SelectedIndexChanged);
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
            this.contextMenuStrip.Size = new System.Drawing.Size(183, 148);
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
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // lblRemise
            // 
            this.lblRemise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemise.AutoSize = true;
            this.lblRemise.ForeColor = System.Drawing.Color.Black;
            this.lblRemise.Location = new System.Drawing.Point(16, 384);
            this.lblRemise.Name = "lblRemise";
            this.lblRemise.Size = new System.Drawing.Size(42, 13);
            this.lblRemise.TabIndex = 10;
            this.lblRemise.Text = "Remise";
            // 
            // lblSchoonmaak
            // 
            this.lblSchoonmaak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchoonmaak.AutoSize = true;
            this.lblSchoonmaak.ForeColor = System.Drawing.Color.Blue;
            this.lblSchoonmaak.Location = new System.Drawing.Point(16, 406);
            this.lblSchoonmaak.Name = "lblSchoonmaak";
            this.lblSchoonmaak.Size = new System.Drawing.Size(70, 13);
            this.lblSchoonmaak.TabIndex = 11;
            this.lblSchoonmaak.Text = "Schoonmaak";
            // 
            // lblReparatie
            // 
            this.lblReparatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReparatie.AutoSize = true;
            this.lblReparatie.ForeColor = System.Drawing.Color.Red;
            this.lblReparatie.Location = new System.Drawing.Point(16, 428);
            this.lblReparatie.Name = "lblReparatie";
            this.lblReparatie.Size = new System.Drawing.Size(53, 13);
            this.lblReparatie.TabIndex = 12;
            this.lblReparatie.Text = "Reparatie";
            // 
            // lblDienst
            // 
            this.lblDienst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDienst.AutoSize = true;
            this.lblDienst.ForeColor = System.Drawing.Color.Purple;
            this.lblDienst.Location = new System.Drawing.Point(16, 450);
            this.lblDienst.Name = "lblDienst";
            this.lblDienst.Size = new System.Drawing.Size(37, 13);
            this.lblDienst.TabIndex = 14;
            this.lblDienst.Text = "Dienst";
            // 
            // btnBevestig
            // 
            this.btnBevestig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBevestig.Enabled = false;
            this.btnBevestig.Location = new System.Drawing.Point(15, 335);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(121, 24);
            this.btnBevestig.TabIndex = 15;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulate.Location = new System.Drawing.Point(684, 4);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(109, 23);
            this.btnSimulate.TabIndex = 16;
            this.btnSimulate.Text = "Simuleer Data";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // UcOverzichtBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.lblDienst);
            this.Controls.Add(this.lblReparatie);
            this.Controls.Add(this.lblSchoonmaak);
            this.Controls.Add(this.lblRemise);
            this.Controls.Add(this.lblSelectedSection);
            this.Controls.Add(this.lblSeletedTrack);
            this.Controls.Add(this.pnlTracks);
            this.Controls.Add(this.lbReserveringen);
            this.Controls.Add(this.lblReserveringen);
            this.Name = "UcOverzichtBs";
            this.Size = new System.Drawing.Size(796, 508);
            this.Resize += new System.EventHandler(this.ucOverzichtBS_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label lblRemise;
        private System.Windows.Forms.Label lblSchoonmaak;
        private System.Windows.Forms.Label lblReparatie;
        private System.Windows.Forms.Label lblDienst;
        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.Button btnSimulate;
    }
}
