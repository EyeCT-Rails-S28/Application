using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcTramInfo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Tramnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lijn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reparaties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schoonmaak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tramnummer,
            this.Lijn,
            this.Soort,
            this.Status,
            this.Spoor,
            this.Reparaties,
            this.Schoonmaak});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(754, 485);
            this.dataGridView1.TabIndex = 0;
            // 
            // Tramnummer
            // 
            this.Tramnummer.HeaderText = "Tramnummer";
            this.Tramnummer.Name = "Tramnummer";
            // 
            // Lijn
            // 
            this.Lijn.HeaderText = "Lijn";
            this.Lijn.Name = "Lijn";
            // 
            // Soort
            // 
            this.Soort.HeaderText = "Soort";
            this.Soort.Name = "Soort";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Spoor
            // 
            this.Spoor.HeaderText = "Spoor";
            this.Spoor.Name = "Spoor";
            // 
            // Reparaties
            // 
            this.Reparaties.HeaderText = "Reparaties";
            this.Reparaties.Name = "Reparaties";
            // 
            // Schoonmaak
            // 
            this.Schoonmaak.HeaderText = "Schoonmaak";
            this.Schoonmaak.Name = "Schoonmaak";
            // 
            // UcTramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "UcTramInfo";
            this.Size = new System.Drawing.Size(754, 485);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tramnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lijn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reparaties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schoonmaak;
    }
}
