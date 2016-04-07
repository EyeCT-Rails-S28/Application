namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    partial class ucTramHistorieSCH
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
            this.lblTramNummer = new System.Windows.Forms.Label();
            this.lblSoort = new System.Windows.Forms.Label();
            this.lblSpoor = new System.Windows.Forms.Label();
            this.dgvTramHistorie = new System.Windows.Forms.DataGridView();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schoonmaak_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opmerkingen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uitgevoerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTramNummer
            // 
            this.lblTramNummer.AutoSize = true;
            this.lblTramNummer.Location = new System.Drawing.Point(-3, 12);
            this.lblTramNummer.Name = "lblTramNummer";
            this.lblTramNummer.Size = new System.Drawing.Size(74, 13);
            this.lblTramNummer.TabIndex = 0;
            this.lblTramNummer.Text = "Tram nummer:";
            // 
            // lblSoort
            // 
            this.lblSoort.AutoSize = true;
            this.lblSoort.Location = new System.Drawing.Point(131, 12);
            this.lblSoort.Name = "lblSoort";
            this.lblSoort.Size = new System.Drawing.Size(35, 13);
            this.lblSoort.TabIndex = 1;
            this.lblSoort.Text = "Soort:";
            // 
            // lblSpoor
            // 
            this.lblSpoor.AutoSize = true;
            this.lblSpoor.Location = new System.Drawing.Point(240, 12);
            this.lblSpoor.Name = "lblSpoor";
            this.lblSpoor.Size = new System.Drawing.Size(38, 13);
            this.lblSpoor.TabIndex = 2;
            this.lblSpoor.Text = "Spoor:";
            // 
            // dgvTramHistorie
            // 
            this.dgvTramHistorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramHistorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type_Beurt,
            this.Schoonmaak_Datum,
            this.Opmerkingen,
            this.Uitgevoerd});
            this.dgvTramHistorie.Location = new System.Drawing.Point(3, 28);
            this.dgvTramHistorie.Name = "dgvTramHistorie";
            this.dgvTramHistorie.Size = new System.Drawing.Size(443, 464);
            this.dgvTramHistorie.TabIndex = 3;
            // 
            // Type_Beurt
            // 
            this.Type_Beurt.HeaderText = "Type Beurt";
            this.Type_Beurt.Name = "Type_Beurt";
            // 
            // Schoonmaak_Datum
            // 
            this.Schoonmaak_Datum.HeaderText = "Schoonmaak datum";
            this.Schoonmaak_Datum.Name = "Schoonmaak_Datum";
            // 
            // Opmerkingen
            // 
            this.Opmerkingen.HeaderText = "Opmerkingen";
            this.Opmerkingen.Name = "Opmerkingen";
            // 
            // Uitgevoerd
            // 
            this.Uitgevoerd.HeaderText = "Uitgevoerd door";
            this.Uitgevoerd.Name = "Uitgevoerd";
            // 
            // ucTramHistorieSCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTramHistorie);
            this.Controls.Add(this.lblSpoor);
            this.Controls.Add(this.lblSoort);
            this.Controls.Add(this.lblTramNummer);
            this.Name = "ucTramHistorieSCH";
            this.Size = new System.Drawing.Size(449, 498);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTramNummer;
        private System.Windows.Forms.Label lblSoort;
        private System.Windows.Forms.Label lblSpoor;
        private System.Windows.Forms.DataGridView dgvTramHistorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schoonmaak_Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opmerkingen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uitgevoerd;
    }
}
