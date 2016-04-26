namespace EyeCT4RailsUI.Forms.Beheersysteem
{
    partial class FrmBs
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
            this.components = new System.ComponentModel.Container();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.overzichtBSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sporenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleBlokkadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inEnUitrijSysteemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControls = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tramPlaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramVerwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTramWijzigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reserveringPlaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overzichtBSToolStripMenuItem,
            this.tramsToolStripMenuItem,
            this.sporenToolStripMenuItem,
            this.inEnUitrijSysteemToolStripMenuItem,
            this.schoonmaakToolStripMenuItem,
            this.reparatieToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1122, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menuStrip1";
            // 
            // overzichtBSToolStripMenuItem
            // 
            this.overzichtBSToolStripMenuItem.Name = "overzichtBSToolStripMenuItem";
            this.overzichtBSToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.overzichtBSToolStripMenuItem.Text = "Overzicht Bs";
            this.overzichtBSToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // tramsToolStripMenuItem
            // 
            this.tramsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tramPlaatsenToolStripMenuItem,
            this.tramVerwijderenToolStripMenuItem,
            this.tramInfoToolStripMenuItem,
            this.statusTramWijzigenToolStripMenuItem,
            this.reserveringPlaatsenToolStripMenuItem});
            this.tramsToolStripMenuItem.Name = "tramsToolStripMenuItem";
            this.tramsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tramsToolStripMenuItem.Text = "Trams";
            // 
            // sporenToolStripMenuItem
            // 
            this.sporenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleBlokkadeToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.sporenToolStripMenuItem.Name = "sporenToolStripMenuItem";
            this.sporenToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.sporenToolStripMenuItem.Text = "Sporen";
            // 
            // toggleBlokkadeToolStripMenuItem
            // 
            this.toggleBlokkadeToolStripMenuItem.Name = "toggleBlokkadeToolStripMenuItem";
            this.toggleBlokkadeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.toggleBlokkadeToolStripMenuItem.Text = "Toggle blokkade";
            this.toggleBlokkadeToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.infoToolStripMenuItem.Text = "Spoor info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // inEnUitrijSysteemToolStripMenuItem
            // 
            this.inEnUitrijSysteemToolStripMenuItem.Name = "inEnUitrijSysteemToolStripMenuItem";
            this.inEnUitrijSysteemToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.inEnUitrijSysteemToolStripMenuItem.Text = "In en uit rij systeem";
            this.inEnUitrijSysteemToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // schoonmaakToolStripMenuItem
            // 
            this.schoonmaakToolStripMenuItem.Name = "schoonmaakToolStripMenuItem";
            this.schoonmaakToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.schoonmaakToolStripMenuItem.Text = "Schoonmaak";
            this.schoonmaakToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // reparatieToolStripMenuItem
            // 
            this.reparatieToolStripMenuItem.Name = "reparatieToolStripMenuItem";
            this.reparatieToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.reparatieToolStripMenuItem.Text = "Reparatie";
            this.reparatieToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.ContextMenuStrip = this.contextMenuStrip;
            this.panelControls.Location = new System.Drawing.Point(0, 24);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1122, 651);
            this.panelControls.TabIndex = 2;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // tramPlaatsenToolStripMenuItem
            // 
            this.tramPlaatsenToolStripMenuItem.Name = "tramPlaatsenToolStripMenuItem";
            this.tramPlaatsenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tramPlaatsenToolStripMenuItem.Text = "Tram plaatsen";
            this.tramPlaatsenToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // tramVerwijderenToolStripMenuItem
            // 
            this.tramVerwijderenToolStripMenuItem.Name = "tramVerwijderenToolStripMenuItem";
            this.tramVerwijderenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tramVerwijderenToolStripMenuItem.Text = "Tram verwijderen";
            this.tramVerwijderenToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // tramInfoToolStripMenuItem
            // 
            this.tramInfoToolStripMenuItem.Name = "tramInfoToolStripMenuItem";
            this.tramInfoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tramInfoToolStripMenuItem.Text = "Tram info";
            this.tramInfoToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // statusTramWijzigenToolStripMenuItem
            // 
            this.statusTramWijzigenToolStripMenuItem.Name = "statusTramWijzigenToolStripMenuItem";
            this.statusTramWijzigenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.statusTramWijzigenToolStripMenuItem.Text = "Status tram wijzigen";
            this.statusTramWijzigenToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // reserveringPlaatsenToolStripMenuItem
            // 
            this.reserveringPlaatsenToolStripMenuItem.Name = "reserveringPlaatsenToolStripMenuItem";
            this.reserveringPlaatsenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.reserveringPlaatsenToolStripMenuItem.Text = "Reservering plaatsen";
            this.reserveringPlaatsenToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // FrmBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 675);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.msMenu);
            this.Name = "FrmBs";
            this.Text = "Beheersysteem";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sporenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleBlokkadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reparatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.ToolStripMenuItem overzichtBSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inEnUitrijSysteemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tramPlaatsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramVerwijderenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tramInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusTramWijzigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserveringPlaatsenToolStripMenuItem;
    }
}

