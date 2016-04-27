using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    partial class UcPlanReparatie
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
            this.btnEnkel = new System.Windows.Forms.Button();
            this.gbReJob = new System.Windows.Forms.GroupBox();
            this.btnMeerdere = new System.Windows.Forms.Button();
            this.lblEindDatum = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.dtpEindDatum = new System.Windows.Forms.DateTimePicker();
            this.lblInterval = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblDatum = new System.Windows.Forms.Label();
            this.tbTramID = new System.Windows.Forms.TextBox();
            this.lblTramID = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbGrootteBeurt = new System.Windows.Forms.ComboBox();
            this.lblGrootteBeurt = new System.Windows.Forms.Label();
            this.gbReJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnkel
            // 
            this.btnEnkel.Location = new System.Drawing.Point(98, 111);
            this.btnEnkel.Name = "btnEnkel";
            this.btnEnkel.Size = new System.Drawing.Size(200, 23);
            this.btnEnkel.TabIndex = 24;
            this.btnEnkel.Text = "Enkel";
            this.btnEnkel.UseVisualStyleBackColor = true;
            this.btnEnkel.Click += new System.EventHandler(this.btnEnkel_Click);
            // 
            // gbReJob
            // 
            this.gbReJob.Controls.Add(this.btnMeerdere);
            this.gbReJob.Controls.Add(this.lblEindDatum);
            this.gbReJob.Controls.Add(this.nudInterval);
            this.gbReJob.Controls.Add(this.dtpEindDatum);
            this.gbReJob.Controls.Add(this.lblInterval);
            this.gbReJob.Location = new System.Drawing.Point(304, 0);
            this.gbReJob.Name = "gbReJob";
            this.gbReJob.Size = new System.Drawing.Size(309, 100);
            this.gbReJob.TabIndex = 23;
            this.gbReJob.TabStop = false;
            this.gbReJob.Text = "Meerdere";
            // 
            // btnMeerdere
            // 
            this.btnMeerdere.Location = new System.Drawing.Point(96, 62);
            this.btnMeerdere.Name = "btnMeerdere";
            this.btnMeerdere.Size = new System.Drawing.Size(200, 23);
            this.btnMeerdere.TabIndex = 15;
            this.btnMeerdere.Text = "Meerdere";
            this.btnMeerdere.UseVisualStyleBackColor = true;
            this.btnMeerdere.Click += new System.EventHandler(this.btnMeerdere_Click);
            // 
            // lblEindDatum
            // 
            this.lblEindDatum.AutoSize = true;
            this.lblEindDatum.Location = new System.Drawing.Point(6, 16);
            this.lblEindDatum.Name = "lblEindDatum";
            this.lblEindDatum.Size = new System.Drawing.Size(63, 13);
            this.lblEindDatum.TabIndex = 9;
            this.lblEindDatum.Text = "Eind datum:";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(96, 36);
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(200, 20);
            this.nudInterval.TabIndex = 12;
            // 
            // dtpEindDatum
            // 
            this.dtpEindDatum.Location = new System.Drawing.Point(96, 10);
            this.dtpEindDatum.Name = "dtpEindDatum";
            this.dtpEindDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpEindDatum.TabIndex = 10;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(6, 39);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(84, 13);
            this.lblInterval.TabIndex = 11;
            this.lblInterval.Text = "Interval (dagen):";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(98, 84);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 22;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(8, 90);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 21;
            this.lblDatum.Text = "Datum:";
            // 
            // tbTramID
            // 
            this.tbTramID.Location = new System.Drawing.Point(98, 56);
            this.tbTramID.Name = "tbTramID";
            this.tbTramID.Size = new System.Drawing.Size(200, 20);
            this.tbTramID.TabIndex = 20;
            // 
            // lblTramID
            // 
            this.lblTramID.AutoSize = true;
            this.lblTramID.Location = new System.Drawing.Point(8, 59);
            this.lblTramID.Name = "lblTramID";
            this.lblTramID.Size = new System.Drawing.Size(48, 13);
            this.lblTramID.TabIndex = 19;
            this.lblTramID.Text = "Tram ID:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(98, 30);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(200, 20);
            this.tbUser.TabIndex = 18;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(8, 33);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 17;
            this.lblUser.Text = "User:";
            // 
            // cbGrootteBeurt
            // 
            this.cbGrootteBeurt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrootteBeurt.FormattingEnabled = true;
            this.cbGrootteBeurt.Items.AddRange(new object[] {
            "Big",
            "Small"});
            this.cbGrootteBeurt.Location = new System.Drawing.Point(98, 3);
            this.cbGrootteBeurt.Name = "cbGrootteBeurt";
            this.cbGrootteBeurt.Size = new System.Drawing.Size(200, 21);
            this.cbGrootteBeurt.TabIndex = 16;
            // 
            // lblGrootteBeurt
            // 
            this.lblGrootteBeurt.AutoSize = true;
            this.lblGrootteBeurt.Location = new System.Drawing.Point(8, 6);
            this.lblGrootteBeurt.Name = "lblGrootteBeurt";
            this.lblGrootteBeurt.Size = new System.Drawing.Size(72, 13);
            this.lblGrootteBeurt.TabIndex = 15;
            this.lblGrootteBeurt.Text = "Grootte beurt:";
            // 
            // UcPlanReparatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnkel);
            this.Controls.Add(this.gbReJob);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.tbTramID);
            this.Controls.Add(this.lblTramID);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cbGrootteBeurt);
            this.Controls.Add(this.lblGrootteBeurt);
            this.Name = "UcPlanReparatie";
            this.Size = new System.Drawing.Size(620, 144);
            this.gbReJob.ResumeLayout(false);
            this.gbReJob.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnkel;
        private System.Windows.Forms.GroupBox gbReJob;
        private System.Windows.Forms.Button btnMeerdere;
        private System.Windows.Forms.Label lblEindDatum;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.DateTimePicker dtpEindDatum;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.TextBox tbTramID;
        private System.Windows.Forms.Label lblTramID;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbGrootteBeurt;
        private System.Windows.Forms.Label lblGrootteBeurt;
    }
}
