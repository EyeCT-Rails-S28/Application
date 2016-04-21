namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    partial class ucReparatie
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
            this.tbOpmerking = new System.Windows.Forms.TextBox();
            this.btnReparatieAfronden = new System.Windows.Forms.Button();
            this.dgvTrams = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tramnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reparatie_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOpmerking
            // 
            this.tbOpmerking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpmerking.BackColor = System.Drawing.SystemColors.Window;
            this.tbOpmerking.Location = new System.Drawing.Point(174, 395);
            this.tbOpmerking.Name = "tbOpmerking";
            this.tbOpmerking.Size = new System.Drawing.Size(485, 20);
            this.tbOpmerking.TabIndex = 5;
            // 
            // btnReparatieAfronden
            // 
            this.btnReparatieAfronden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReparatieAfronden.Location = new System.Drawing.Point(6, 392);
            this.btnReparatieAfronden.Name = "btnReparatieAfronden";
            this.btnReparatieAfronden.Size = new System.Drawing.Size(162, 23);
            this.btnReparatieAfronden.TabIndex = 4;
            this.btnReparatieAfronden.Text = "Reparatiebeurt afronden";
            this.btnReparatieAfronden.UseVisualStyleBackColor = true;
            // 
            // dgvTrams
            // 
            this.dgvTrams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Tramnummer,
            this.Soort,
            this.Spoor,
            this.Type_Beurt,
            this.Reparatie_Datum});
            this.dgvTrams.Location = new System.Drawing.Point(0, 0);
            this.dgvTrams.Name = "dgvTrams";
            this.dgvTrams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTrams.Size = new System.Drawing.Size(659, 386);
            this.dgvTrams.TabIndex = 3;
            this.dgvTrams.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrams_CellDoubleClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // Tramnummer
            // 
            this.Tramnummer.HeaderText = "Tramnummer";
            this.Tramnummer.Name = "Tramnummer";
            // 
            // Soort
            // 
            this.Soort.HeaderText = "Soort";
            this.Soort.Name = "Soort";
            // 
            // Spoor
            // 
            this.Spoor.HeaderText = "Spoor";
            this.Spoor.Name = "Spoor";
            // 
            // Type_Beurt
            // 
            this.Type_Beurt.HeaderText = "Type Beurt";
            this.Type_Beurt.Name = "Type_Beurt";
            // 
            // Reparatie_Datum
            // 
            this.Reparatie_Datum.HeaderText = "Reparatie Datum";
            this.Reparatie_Datum.Name = "Reparatie_Datum";
            // 
            // ucReparatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbOpmerking);
            this.Controls.Add(this.btnReparatieAfronden);
            this.Controls.Add(this.dgvTrams);
            this.Name = "ucReparatie";
            this.Size = new System.Drawing.Size(659, 424);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOpmerking;
        private System.Windows.Forms.Button btnReparatieAfronden;
        private System.Windows.Forms.DataGridView dgvTrams;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tramnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reparatie_Datum;
    }
}
