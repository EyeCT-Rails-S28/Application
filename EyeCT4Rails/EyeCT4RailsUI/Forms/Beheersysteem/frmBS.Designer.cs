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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.gebruikerBeheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overzichtBSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inEnUitrijSysteemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planSchoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoekSchoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historieSchoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planReparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoekReparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historieReparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControls = new System.Windows.Forms.Panel();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gebruikerBeheerToolStripMenuItem,
            this.overzichtBSToolStripMenuItem,
            this.tramsToolStripMenuItem,
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
            // gebruikerBeheerToolStripMenuItem
            // 
            this.gebruikerBeheerToolStripMenuItem.Name = "gebruikerBeheerToolStripMenuItem";
            this.gebruikerBeheerToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.gebruikerBeheerToolStripMenuItem.Text = "Maak gebruiker";
            this.gebruikerBeheerToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
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
            this.tramsToolStripMenuItem.Name = "tramsToolStripMenuItem";
            this.tramsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.tramsToolStripMenuItem.Text = "Tram info";
            this.tramsToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
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
            this.schoonmaakToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planSchoonmaakToolStripMenuItem,
            this.zoekSchoonmaakToolStripMenuItem,
            this.historieSchoonmaakToolStripMenuItem});
            this.schoonmaakToolStripMenuItem.Name = "schoonmaakToolStripMenuItem";
            this.schoonmaakToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.schoonmaakToolStripMenuItem.Text = "Schoonmaak";
            this.schoonmaakToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // planSchoonmaakToolStripMenuItem
            // 
            this.planSchoonmaakToolStripMenuItem.Name = "planSchoonmaakToolStripMenuItem";
            this.planSchoonmaakToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.planSchoonmaakToolStripMenuItem.Text = "Plan schoonmaak";
            this.planSchoonmaakToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // zoekSchoonmaakToolStripMenuItem
            // 
            this.zoekSchoonmaakToolStripMenuItem.Name = "zoekSchoonmaakToolStripMenuItem";
            this.zoekSchoonmaakToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.zoekSchoonmaakToolStripMenuItem.Text = "Zoek";
            this.zoekSchoonmaakToolStripMenuItem.Click += new System.EventHandler(this.zoekSchoonmaakToolStripMenuItem_Click);
            // 
            // historieSchoonmaakToolStripMenuItem
            // 
            this.historieSchoonmaakToolStripMenuItem.Name = "historieSchoonmaakToolStripMenuItem";
            this.historieSchoonmaakToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.historieSchoonmaakToolStripMenuItem.Text = "Historie";
            this.historieSchoonmaakToolStripMenuItem.Click += new System.EventHandler(this.historieSchoonmaakToolStripMenuItem_Click);
            // 
            // reparatieToolStripMenuItem
            // 
            this.reparatieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planReparatieToolStripMenuItem,
            this.zoekReparatieToolStripMenuItem,
            this.historieReparatieToolStripMenuItem});
            this.reparatieToolStripMenuItem.Name = "reparatieToolStripMenuItem";
            this.reparatieToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.reparatieToolStripMenuItem.Text = "Reparatie";
            this.reparatieToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // planReparatieToolStripMenuItem
            // 
            this.planReparatieToolStripMenuItem.Name = "planReparatieToolStripMenuItem";
            this.planReparatieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.planReparatieToolStripMenuItem.Text = "Plan reparatie";
            this.planReparatieToolStripMenuItem.Click += new System.EventHandler(this.UserControl_Change);
            // 
            // zoekReparatieToolStripMenuItem
            // 
            this.zoekReparatieToolStripMenuItem.Name = "zoekReparatieToolStripMenuItem";
            this.zoekReparatieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zoekReparatieToolStripMenuItem.Text = "Zoek";
            this.zoekReparatieToolStripMenuItem.Click += new System.EventHandler(this.zoekReparatieToolStripMenuItem_Click);
            // 
            // historieReparatieToolStripMenuItem
            // 
            this.historieReparatieToolStripMenuItem.Name = "historieReparatieToolStripMenuItem";
            this.historieReparatieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.historieReparatieToolStripMenuItem.Text = "Historie";
            this.historieReparatieToolStripMenuItem.Click += new System.EventHandler(this.historieReparatieToolStripMenuItem_Click);
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
            this.panelControls.Location = new System.Drawing.Point(0, 24);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1122, 651);
            this.panelControls.TabIndex = 2;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reparatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.ToolStripMenuItem overzichtBSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inEnUitrijSysteemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gebruikerBeheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planSchoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planReparatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoekSchoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoekReparatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historieSchoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historieReparatieToolStripMenuItem;
    }
}

