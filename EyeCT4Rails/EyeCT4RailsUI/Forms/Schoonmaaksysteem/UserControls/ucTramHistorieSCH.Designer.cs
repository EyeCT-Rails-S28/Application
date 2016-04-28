namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    partial class UcTramHistorieSch
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
            this.clmTram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramSoort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schoonmaak_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uitgevoerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTramHistorie
            // 
            this.dgvTramHistorie.AllowUserToAddRows = false;
            this.dgvTramHistorie.AllowUserToDeleteRows = false;
            this.dgvTramHistorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTramHistorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTram,
            this.clmTramSoort,
            this.Type_Beurt,
            this.Schoonmaak_Datum,
            this.Uitgevoerd});
            this.dgvTramHistorie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTramHistorie.Location = new System.Drawing.Point(0, 0);
            this.dgvTramHistorie.MultiSelect = false;
            this.dgvTramHistorie.Name = "dgvTramHistorie";
            this.dgvTramHistorie.ReadOnly = true;
            this.dgvTramHistorie.RowHeadersVisible = false;
            this.dgvTramHistorie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTramHistorie.Size = new System.Drawing.Size(449, 498);
            this.dgvTramHistorie.TabIndex = 3;
            // 
            // clmTram
            // 
            this.clmTram.HeaderText = "Tram Id";
            this.clmTram.Name = "clmTram";
            this.clmTram.ReadOnly = true;
            // 
            // clmTramSoort
            // 
            this.clmTramSoort.HeaderText = "Tram Soort";
            this.clmTramSoort.Name = "clmTramSoort";
            this.clmTramSoort.ReadOnly = true;
            // 
            // Type_Beurt
            // 
            this.Type_Beurt.HeaderText = "Type Beurt";
            this.Type_Beurt.Name = "Type_Beurt";
            this.Type_Beurt.ReadOnly = true;
            // 
            // Schoonmaak_Datum
            // 
            this.Schoonmaak_Datum.HeaderText = "Schoonmaak datum";
            this.Schoonmaak_Datum.Name = "Schoonmaak_Datum";
            this.Schoonmaak_Datum.ReadOnly = true;
            // 
            // Uitgevoerd
            // 
            this.Uitgevoerd.HeaderText = "Uitgevoerd door";
            this.Uitgevoerd.Name = "Uitgevoerd";
            this.Uitgevoerd.ReadOnly = true;
            // 
            // UcTramHistorieSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTramHistorie);
            this.Name = "UcTramHistorieSch";
            this.Size = new System.Drawing.Size(449, 498);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTramHistorie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTramHistorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTram;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramSoort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schoonmaak_Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uitgevoerd;
    }
}
