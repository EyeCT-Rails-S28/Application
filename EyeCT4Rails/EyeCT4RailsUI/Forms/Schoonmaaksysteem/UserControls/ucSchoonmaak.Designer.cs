﻿namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    partial class UcSchoonmaak
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tramnummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_Beurt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schoonmaak_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSchoonmaakbeurtAfronden = new System.Windows.Forms.Button();
            this.btnSchoonmaakVerwijderen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrams
            // 
            this.dgvTrams.AllowUserToAddRows = false;
            this.dgvTrams.AllowUserToDeleteRows = false;
            this.dgvTrams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ID,
            this.Tramnummer,
            this.Soort,
            this.Spoor,
            this.Type_Beurt,
            this.Schoonmaak_Datum});
            this.dgvTrams.Location = new System.Drawing.Point(0, 0);
            this.dgvTrams.MultiSelect = false;
            this.dgvTrams.Name = "dgvTrams";
            this.dgvTrams.RowHeadersVisible = false;
            this.dgvTrams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTrams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrams.Size = new System.Drawing.Size(745, 383);
            this.dgvTrams.TabIndex = 0;
            this.dgvTrams.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrams_CellDoubleClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Tramnummer
            // 
            this.Tramnummer.HeaderText = "Tramnummer";
            this.Tramnummer.Name = "Tramnummer";
            this.Tramnummer.ReadOnly = true;
            // 
            // Soort
            // 
            this.Soort.HeaderText = "Soort";
            this.Soort.Name = "Soort";
            this.Soort.ReadOnly = true;
            // 
            // Spoor
            // 
            this.Spoor.HeaderText = "Spoor";
            this.Spoor.Name = "Spoor";
            this.Spoor.ReadOnly = true;
            // 
            // Type_Beurt
            // 
            this.Type_Beurt.HeaderText = "Type Beurt";
            this.Type_Beurt.Name = "Type_Beurt";
            this.Type_Beurt.ReadOnly = true;
            // 
            // Schoonmaak_Datum
            // 
            this.Schoonmaak_Datum.HeaderText = "Schoonmaak Datum";
            this.Schoonmaak_Datum.Name = "Schoonmaak_Datum";
            this.Schoonmaak_Datum.ReadOnly = true;
            // 
            // btnSchoonmaakbeurtAfronden
            // 
            this.btnSchoonmaakbeurtAfronden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSchoonmaakbeurtAfronden.Location = new System.Drawing.Point(3, 392);
            this.btnSchoonmaakbeurtAfronden.Name = "btnSchoonmaakbeurtAfronden";
            this.btnSchoonmaakbeurtAfronden.Size = new System.Drawing.Size(162, 23);
            this.btnSchoonmaakbeurtAfronden.TabIndex = 1;
            this.btnSchoonmaakbeurtAfronden.Text = "Schoonmaakbeurt afronden";
            this.btnSchoonmaakbeurtAfronden.UseVisualStyleBackColor = true;
            this.btnSchoonmaakbeurtAfronden.Click += new System.EventHandler(this.btnSchoonmaakbeurtAfronden_Click);
            // 
            // btnSchoonmaakVerwijderen
            // 
            this.btnSchoonmaakVerwijderen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSchoonmaakVerwijderen.Location = new System.Drawing.Point(171, 392);
            this.btnSchoonmaakVerwijderen.Name = "btnSchoonmaakVerwijderen";
            this.btnSchoonmaakVerwijderen.Size = new System.Drawing.Size(162, 23);
            this.btnSchoonmaakVerwijderen.TabIndex = 2;
            this.btnSchoonmaakVerwijderen.Text = "Schoonmaakbeurt verwijderen";
            this.btnSchoonmaakVerwijderen.UseVisualStyleBackColor = true;
            this.btnSchoonmaakVerwijderen.Click += new System.EventHandler(this.btnSchoonmaakVerwijderen_Click);
            // 
            // UcSchoonmaak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSchoonmaakVerwijderen);
            this.Controls.Add(this.btnSchoonmaakbeurtAfronden);
            this.Controls.Add(this.dgvTrams);
            this.Name = "UcSchoonmaak";
            this.Size = new System.Drawing.Size(745, 425);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrams;
        private System.Windows.Forms.Button btnSchoonmaakbeurtAfronden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tramnummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_Beurt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schoonmaak_Datum;
        private System.Windows.Forms.Button btnSchoonmaakVerwijderen;
    }
}
