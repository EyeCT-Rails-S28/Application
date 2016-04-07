namespace EyeCT4RailsUI.Forms.UserControls
{
    partial class ucTramInfo
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
            this.tbTramnummer = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbLijn = new System.Windows.Forms.TextBox();
            this.tbSoort = new System.Windows.Forms.TextBox();
            this.tbSpoor = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(746, 447);
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
            // tbTramnummer
            // 
            this.tbTramnummer.Location = new System.Drawing.Point(56, 9);
            this.tbTramnummer.Name = "tbTramnummer";
            this.tbTramnummer.Size = new System.Drawing.Size(78, 20);
            this.tbTramnummer.TabIndex = 1;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(353, 9);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(78, 20);
            this.tbStatus.TabIndex = 2;
            // 
            // tbLijn
            // 
            this.tbLijn.Location = new System.Drawing.Point(154, 9);
            this.tbLijn.Name = "tbLijn";
            this.tbLijn.Size = new System.Drawing.Size(78, 20);
            this.tbLijn.TabIndex = 2;
            // 
            // tbSoort
            // 
            this.tbSoort.Location = new System.Drawing.Point(258, 9);
            this.tbSoort.Name = "tbSoort";
            this.tbSoort.Size = new System.Drawing.Size(78, 20);
            this.tbSoort.TabIndex = 3;
            // 
            // tbSpoor
            // 
            this.tbSpoor.Location = new System.Drawing.Point(456, 9);
            this.tbSpoor.Name = "tbSpoor";
            this.tbSpoor.Size = new System.Drawing.Size(78, 20);
            this.tbSpoor.TabIndex = 4;
            // 
            // ucTramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSpoor);
            this.Controls.Add(this.tbSoort);
            this.Controls.Add(this.tbLijn);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucTramInfo";
            this.Size = new System.Drawing.Size(754, 485);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox tbTramnummer;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TextBox tbLijn;
        private System.Windows.Forms.TextBox tbSoort;
        private System.Windows.Forms.TextBox tbSpoor;
    }
}
