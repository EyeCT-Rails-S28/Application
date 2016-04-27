namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    partial class UcPlanSchoonmaak
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
            this.lblGrootteBeurt = new System.Windows.Forms.Label();
            this.cbGrootteBeurt = new System.Windows.Forms.ComboBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.tbTramID = new System.Windows.Forms.TextBox();
            this.lblTramID = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpEindDatum = new System.Windows.Forms.DateTimePicker();
            this.lblEindDatum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGrootteBeurt
            // 
            this.lblGrootteBeurt.AutoSize = true;
            this.lblGrootteBeurt.Location = new System.Drawing.Point(17, 22);
            this.lblGrootteBeurt.Name = "lblGrootteBeurt";
            this.lblGrootteBeurt.Size = new System.Drawing.Size(72, 13);
            this.lblGrootteBeurt.TabIndex = 0;
            this.lblGrootteBeurt.Text = "Grootte beurt:";
            // 
            // cbGrootteBeurt
            // 
            this.cbGrootteBeurt.FormattingEnabled = true;
            this.cbGrootteBeurt.Items.AddRange(new object[] {
            "Big",
            "Small"});
            this.cbGrootteBeurt.Location = new System.Drawing.Point(95, 19);
            this.cbGrootteBeurt.Name = "cbGrootteBeurt";
            this.cbGrootteBeurt.Size = new System.Drawing.Size(200, 21);
            this.cbGrootteBeurt.TabIndex = 1;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(17, 49);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(46, 13);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "User ID:";
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(95, 46);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.ReadOnly = true;
            this.tbUserID.Size = new System.Drawing.Size(200, 20);
            this.tbUserID.TabIndex = 4;
            // 
            // tbTramID
            // 
            this.tbTramID.Location = new System.Drawing.Point(95, 72);
            this.tbTramID.Name = "tbTramID";
            this.tbTramID.Size = new System.Drawing.Size(200, 20);
            this.tbTramID.TabIndex = 6;
            // 
            // lblTramID
            // 
            this.lblTramID.AutoSize = true;
            this.lblTramID.Location = new System.Drawing.Point(17, 75);
            this.lblTramID.Name = "lblTramID";
            this.lblTramID.Size = new System.Drawing.Size(48, 13);
            this.lblTramID.TabIndex = 5;
            this.lblTramID.Text = "Tram ID:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(17, 106);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 7;
            this.lblDatum.Text = "Datum:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(95, 100);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 8;
            // 
            // dtpEindDatum
            // 
            this.dtpEindDatum.Location = new System.Drawing.Point(95, 130);
            this.dtpEindDatum.Name = "dtpEindDatum";
            this.dtpEindDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpEindDatum.TabIndex = 10;
            // 
            // lblEindDatum
            // 
            this.lblEindDatum.AutoSize = true;
            this.lblEindDatum.Location = new System.Drawing.Point(17, 136);
            this.lblEindDatum.Name = "lblEindDatum";
            this.lblEindDatum.Size = new System.Drawing.Size(63, 13);
            this.lblEindDatum.TabIndex = 9;
            this.lblEindDatum.Text = "Eind datum:";
            // 
            // UcPlanSchoonmaak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpEindDatum);
            this.Controls.Add(this.lblEindDatum);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.tbTramID);
            this.Controls.Add(this.lblTramID);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.cbGrootteBeurt);
            this.Controls.Add(this.lblGrootteBeurt);
            this.Name = "UcPlanSchoonmaak";
            this.Size = new System.Drawing.Size(433, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrootteBeurt;
        private System.Windows.Forms.ComboBox cbGrootteBeurt;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.TextBox tbTramID;
        private System.Windows.Forms.Label lblTramID;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpEindDatum;
        private System.Windows.Forms.Label lblEindDatum;
    }
}
