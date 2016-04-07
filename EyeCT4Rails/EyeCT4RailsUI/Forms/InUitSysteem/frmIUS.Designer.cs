namespace EyeCT4RailsUI.Forms.InUitSysteem
{
    partial class frmIUS
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSpoornummer = new System.Windows.Forms.TextBox();
            this.tbTramnummer = new System.Windows.Forms.TextBox();
            this.lblTramnummer = new System.Windows.Forms.Label();
            this.lblHistorie = new System.Windows.Forms.Label();
            this.lbHistorie = new System.Windows.Forms.ListBox();
            this.gbTA = new System.Windows.Forms.GroupBox();
            this.rbJa = new System.Windows.Forms.RadioButton();
            this.rbNee = new System.Windows.Forms.RadioButton();
            this.cbSchoonmaak = new System.Windows.Forms.CheckBox();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.btnBevestig = new System.Windows.Forms.Button();
            this.gbTA.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSpoornummer
            // 
            this.tbSpoornummer.Location = new System.Drawing.Point(87, 83);
            this.tbSpoornummer.Name = "tbSpoornummer";
            this.tbSpoornummer.Size = new System.Drawing.Size(100, 20);
            this.tbSpoornummer.TabIndex = 8;
            // 
            // tbTramnummer
            // 
            this.tbTramnummer.Location = new System.Drawing.Point(296, 83);
            this.tbTramnummer.Name = "tbTramnummer";
            this.tbTramnummer.Size = new System.Drawing.Size(112, 20);
            this.tbTramnummer.TabIndex = 7;
            // 
            // lblTramnummer
            // 
            this.lblTramnummer.AutoSize = true;
            this.lblTramnummer.Location = new System.Drawing.Point(293, 45);
            this.lblTramnummer.Name = "lblTramnummer";
            this.lblTramnummer.Size = new System.Drawing.Size(71, 13);
            this.lblTramnummer.TabIndex = 5;
            this.lblTramnummer.Text = "Tramnummer:";
            // 
            // lblHistorie
            // 
            this.lblHistorie.AutoSize = true;
            this.lblHistorie.Location = new System.Drawing.Point(470, 45);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(45, 13);
            this.lblHistorie.TabIndex = 9;
            this.lblHistorie.Text = "Historie:";
            // 
            // lbHistorie
            // 
            this.lbHistorie.FormattingEnabled = true;
            this.lbHistorie.Location = new System.Drawing.Point(473, 83);
            this.lbHistorie.Name = "lbHistorie";
            this.lbHistorie.Size = new System.Drawing.Size(188, 108);
            this.lbHistorie.TabIndex = 10;
            // 
            // gbTA
            // 
            this.gbTA.Controls.Add(this.rbJa);
            this.gbTA.Controls.Add(this.rbNee);
            this.gbTA.Location = new System.Drawing.Point(30, 192);
            this.gbTA.Name = "gbTA";
            this.gbTA.Size = new System.Drawing.Size(249, 111);
            this.gbTA.TabIndex = 11;
            this.gbTA.TabStop = false;
            this.gbTA.Text = "Technische assistentie nodig?";
            // 
            // rbJa
            // 
            this.rbJa.AutoSize = true;
            this.rbJa.Location = new System.Drawing.Point(17, 30);
            this.rbJa.Name = "rbJa";
            this.rbJa.Size = new System.Drawing.Size(36, 17);
            this.rbJa.TabIndex = 12;
            this.rbJa.TabStop = true;
            this.rbJa.Text = "Ja";
            this.rbJa.UseVisualStyleBackColor = true;
            // 
            // rbNee
            // 
            this.rbNee.AutoSize = true;
            this.rbNee.Location = new System.Drawing.Point(17, 66);
            this.rbNee.Name = "rbNee";
            this.rbNee.Size = new System.Drawing.Size(45, 17);
            this.rbNee.TabIndex = 13;
            this.rbNee.TabStop = true;
            this.rbNee.Text = "Nee";
            this.rbNee.UseVisualStyleBackColor = true;
            // 
            // cbSchoonmaak
            // 
            this.cbSchoonmaak.AutoSize = true;
            this.cbSchoonmaak.Location = new System.Drawing.Point(47, 342);
            this.cbSchoonmaak.Name = "cbSchoonmaak";
            this.cbSchoonmaak.Size = new System.Drawing.Size(124, 17);
            this.cbSchoonmaak.TabIndex = 12;
            this.cbSchoonmaak.Text = "Schoonmaak nodig?";
            this.cbSchoonmaak.UseVisualStyleBackColor = true;
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(84, 45);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(77, 13);
            this.lblSpoornummer.TabIndex = 6;
            this.lblSpoornummer.Text = "Ga naar spoor:";
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(296, 124);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(112, 46);
            this.btnBevestig.TabIndex = 13;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            // 
            // frmIUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 390);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.cbSchoonmaak);
            this.Controls.Add(this.gbTA);
            this.Controls.Add(this.lbHistorie);
            this.Controls.Add(this.lblHistorie);
            this.Controls.Add(this.tbSpoornummer);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.lblSpoornummer);
            this.Controls.Add(this.lblTramnummer);
            this.Name = "frmIUS";
            this.Text = "In- en uitrijsysteem";
            this.gbTA.ResumeLayout(false);
            this.gbTA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSpoornummer;
        private System.Windows.Forms.TextBox tbTramnummer;
        private System.Windows.Forms.Label lblTramnummer;
        private System.Windows.Forms.Label lblHistorie;
        private System.Windows.Forms.ListBox lbHistorie;
        private System.Windows.Forms.GroupBox gbTA;
        private System.Windows.Forms.RadioButton rbJa;
        private System.Windows.Forms.RadioButton rbNee;
        private System.Windows.Forms.CheckBox cbSchoonmaak;
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Button btnBevestig;
    }
}