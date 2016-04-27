
namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcSpoorInfo
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
            this.components = new System.ComponentModel.Container();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.clmSpoorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSectionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBlocked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTramId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(3, 0);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(75, 13);
            this.lblSpoornummer.TabIndex = 5;
            this.lblSpoornummer.Text = "Spoornummer:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSpoorId,
            this.clmSectionId,
            this.clmBlocked,
            this.clmTramId});
            this.dataGridView.Location = new System.Drawing.Point(0, 16);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(307, 308);
            this.dataGridView.TabIndex = 17;
            // 
            // clmSpoorId
            // 
            this.clmSpoorId.HeaderText = "Spoor ID";
            this.clmSpoorId.Name = "clmSpoorId";
            this.clmSpoorId.ReadOnly = true;
            // 
            // clmSectionId
            // 
            this.clmSectionId.HeaderText = "Section ID";
            this.clmSectionId.Name = "clmSectionId";
            this.clmSectionId.ReadOnly = true;
            // 
            // clmBlocked
            // 
            this.clmBlocked.HeaderText = "Geblokkeerd";
            this.clmBlocked.Name = "clmBlocked";
            this.clmBlocked.ReadOnly = true;
            // 
            // clmTramId
            // 
            this.clmTramId.HeaderText = "Tram ID";
            this.clmTramId.Name = "clmTramId";
            this.clmTramId.ReadOnly = true;
            // 
            // UcSpoorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblSpoornummer);
            this.Name = "UcSpoorInfo";
            this.Size = new System.Drawing.Size(307, 324);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSpoorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSectionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBlocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTramId;
    }
}
