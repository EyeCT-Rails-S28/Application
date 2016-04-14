namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    partial class ucTramHistorieRS
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
            this.dgvTramHistorie = new System.Windows.Forms.DataGridView();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raparatie_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opmerkingen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uitgevoerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSpoor = new System.Windows.Forms.Label();
            this.lblSoort = new System.Windows.Forms.Label();
            this.lblTramNummer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTramHistorie
            // 
            this.dgvTramHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTramHistorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramHistorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type_Beurt,
            this.Raparatie_Datum,
            this.Opmerkingen,
            this.Uitgevoerd});
            this.dgvTramHistorie.Location = new System.Drawing.Point(0, 17);
            this.dgvTramHistorie.Name = "dgvTramHistorie";
            this.dgvTramHistorie.Size = new System.Drawing.Size(450, 469);
            this.dgvTramHistorie.TabIndex = 7;
            // 
            // Type_Beurt
            // 
            this.Type_Beurt.HeaderText = "Type Beurt";
            this.Type_Beurt.Name = "Type_Beurt";
            // 
            // Raparatie_Datum
            // 
            this.Raparatie_Datum.HeaderText = "Reparatie datum";
            this.Raparatie_Datum.Name = "Raparatie_Datum";
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
            // lblSpoor
            // 
            this.lblSpoor.AutoSize = true;
            this.lblSpoor.Location = new System.Drawing.Point(240, 1);
            this.lblSpoor.Name = "lblSpoor";
            this.lblSpoor.Size = new System.Drawing.Size(38, 13);
            this.lblSpoor.TabIndex = 6;
            this.lblSpoor.Text = "Spoor:";
            // 
            // lblSoort
            // 
            this.lblSoort.AutoSize = true;
            this.lblSoort.Location = new System.Drawing.Point(131, 1);
            this.lblSoort.Name = "lblSoort";
            this.lblSoort.Size = new System.Drawing.Size(35, 13);
            this.lblSoort.TabIndex = 5;
            this.lblSoort.Text = "Soort:";
            // 
            // lblTramNummer
            // 
            this.lblTramNummer.AutoSize = true;
            this.lblTramNummer.Location = new System.Drawing.Point(-3, 1);
            this.lblTramNummer.Name = "lblTramNummer";
            this.lblTramNummer.Size = new System.Drawing.Size(74, 13);
            this.lblTramNummer.TabIndex = 4;
            this.lblTramNummer.Text = "Tram nummer:";
            // 
            // ucTramHistorieRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTramHistorie);
            this.Controls.Add(this.lblSpoor);
            this.Controls.Add(this.lblSoort);
            this.Controls.Add(this.lblTramNummer);
            this.Name = "ucTramHistorieRS";
            this.Size = new System.Drawing.Size(450, 486);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTramHistorie;
        private System.Windows.Forms.Label lblSpoor;
        private System.Windows.Forms.Label lblSoort;
        private System.Windows.Forms.Label lblTramNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raparatie_Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opmerkingen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uitgevoerd;
    }
}
