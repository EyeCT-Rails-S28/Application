namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    partial class ucMainSCH
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
            this.dgvTrams = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tramnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schoonmaak_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSchoonmaakbeurtAfronden = new System.Windows.Forms.Button();
            this.tbOpmerking = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrams
            // 
            this.dgvTrams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Tramnummer,
            this.Soort,
            this.Spoor,
            this.Type_Beurt,
            this.Schoonmaak_Datum});
            this.dgvTrams.Location = new System.Drawing.Point(0, 3);
            this.dgvTrams.Name = "dgvTrams";
            this.dgvTrams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTrams.Size = new System.Drawing.Size(644, 383);
            this.dgvTrams.TabIndex = 0;
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
            // Schoonmaak_Datum
            // 
            this.Schoonmaak_Datum.HeaderText = "Schoonmaak Datum";
            this.Schoonmaak_Datum.Name = "Schoonmaak_Datum";
            // 
            // btnSchoonmaakbeurtAfronden
            // 
            this.btnSchoonmaakbeurtAfronden.Location = new System.Drawing.Point(3, 392);
            this.btnSchoonmaakbeurtAfronden.Name = "btnSchoonmaakbeurtAfronden";
            this.btnSchoonmaakbeurtAfronden.Size = new System.Drawing.Size(162, 23);
            this.btnSchoonmaakbeurtAfronden.TabIndex = 1;
            this.btnSchoonmaakbeurtAfronden.Text = "Schoonmaakbeurt afronden";
            this.btnSchoonmaakbeurtAfronden.UseVisualStyleBackColor = true;
            // 
            // tbOpmerking
            // 
            this.tbOpmerking.Location = new System.Drawing.Point(183, 395);
            this.tbOpmerking.Name = "tbOpmerking";
            this.tbOpmerking.Size = new System.Drawing.Size(460, 20);
            this.tbOpmerking.TabIndex = 2;
            // 
            // ucMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbOpmerking);
            this.Controls.Add(this.btnSchoonmaakbeurtAfronden);
            this.Controls.Add(this.dgvTrams);
            this.Name = "ucMain";
            this.Size = new System.Drawing.Size(646, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrams;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tramnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schoonmaak_Datum;
        private System.Windows.Forms.Button btnSchoonmaakbeurtAfronden;
        private System.Windows.Forms.TextBox tbOpmerking;
    }
}
