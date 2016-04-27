namespace EyeCT4RailsUI.Forms.InUitSysteem
{
    partial class UcInEnUitRijSysteem
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
            this.btnBevestig = new System.Windows.Forms.Button();
            this.cbSchoonmaak = new System.Windows.Forms.CheckBox();
            this.gbTA = new System.Windows.Forms.GroupBox();
            this.rbJa = new System.Windows.Forms.RadioButton();
            this.rbNee = new System.Windows.Forms.RadioButton();
            this.lbHistorie = new System.Windows.Forms.ListBox();
            this.lblHistorie = new System.Windows.Forms.Label();
            this.tbSpoornummer = new System.Windows.Forms.TextBox();
            this.tbTramnummer = new System.Windows.Forms.TextBox();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.lblTramnummer = new System.Windows.Forms.Label();
            this.tbSectienummer = new System.Windows.Forms.TextBox();
            this.lblSectienummer = new System.Windows.Forms.Label();
            this.gbTA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(269, 51);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(112, 46);
            this.btnBevestig.TabIndex = 22;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // cbSchoonmaak
            // 
            this.cbSchoonmaak.AutoSize = true;
            this.cbSchoonmaak.Location = new System.Drawing.Point(20, 306);
            this.cbSchoonmaak.Name = "cbSchoonmaak";
            this.cbSchoonmaak.Size = new System.Drawing.Size(124, 17);
            this.cbSchoonmaak.TabIndex = 21;
            this.cbSchoonmaak.Text = "Schoonmaak nodig?";
            this.cbSchoonmaak.UseVisualStyleBackColor = true;
            // 
            // gbTA
            // 
            this.gbTA.Controls.Add(this.rbJa);
            this.gbTA.Controls.Add(this.rbNee);
            this.gbTA.Location = new System.Drawing.Point(3, 156);
            this.gbTA.Name = "gbTA";
            this.gbTA.Size = new System.Drawing.Size(249, 111);
            this.gbTA.TabIndex = 20;
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
            // lbHistorie
            // 
            this.lbHistorie.FormattingEnabled = true;
            this.lbHistorie.Location = new System.Drawing.Point(446, 47);
            this.lbHistorie.Name = "lbHistorie";
            this.lbHistorie.Size = new System.Drawing.Size(188, 108);
            this.lbHistorie.TabIndex = 19;
            // 
            // lblHistorie
            // 
            this.lblHistorie.AutoSize = true;
            this.lblHistorie.Location = new System.Drawing.Point(443, 9);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(45, 13);
            this.lblHistorie.TabIndex = 18;
            this.lblHistorie.Text = "Historie:";
            // 
            // tbSpoornummer
            // 
            this.tbSpoornummer.Location = new System.Drawing.Point(60, 25);
            this.tbSpoornummer.Name = "tbSpoornummer";
            this.tbSpoornummer.ReadOnly = true;
            this.tbSpoornummer.Size = new System.Drawing.Size(100, 20);
            this.tbSpoornummer.TabIndex = 17;
            // 
            // tbTramnummer
            // 
            this.tbTramnummer.Location = new System.Drawing.Point(269, 25);
            this.tbTramnummer.Name = "tbTramnummer";
            this.tbTramnummer.Size = new System.Drawing.Size(112, 20);
            this.tbTramnummer.TabIndex = 16;
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(57, 9);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(77, 13);
            this.lblSpoornummer.TabIndex = 15;
            this.lblSpoornummer.Text = "Ga naar spoor:";
            // 
            // lblTramnummer
            // 
            this.lblTramnummer.AutoSize = true;
            this.lblTramnummer.Location = new System.Drawing.Point(266, 9);
            this.lblTramnummer.Name = "lblTramnummer";
            this.lblTramnummer.Size = new System.Drawing.Size(71, 13);
            this.lblTramnummer.TabIndex = 14;
            this.lblTramnummer.Text = "Tramnummer:";
            // 
            // tbSectienummer
            // 
            this.tbSectienummer.Location = new System.Drawing.Point(60, 67);
            this.tbSectienummer.Name = "tbSectienummer";
            this.tbSectienummer.ReadOnly = true;
            this.tbSectienummer.Size = new System.Drawing.Size(100, 20);
            this.tbSectienummer.TabIndex = 24;
            // 
            // lblSectienummer
            // 
            this.lblSectienummer.AutoSize = true;
            this.lblSectienummer.Location = new System.Drawing.Point(57, 51);
            this.lblSectienummer.Name = "lblSectienummer";
            this.lblSectienummer.Size = new System.Drawing.Size(79, 13);
            this.lblSectienummer.TabIndex = 23;
            this.lblSectienummer.Text = "Ga naar sectie:";
            // 
            // UcInEnUitRijSysteem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSectienummer);
            this.Controls.Add(this.lblSectienummer);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.cbSchoonmaak);
            this.Controls.Add(this.gbTA);
            this.Controls.Add(this.lbHistorie);
            this.Controls.Add(this.lblHistorie);
            this.Controls.Add(this.tbSpoornummer);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.lblSpoornummer);
            this.Controls.Add(this.lblTramnummer);
            this.Name = "UcInEnUitRijSysteem";
            this.Size = new System.Drawing.Size(647, 348);
            this.gbTA.ResumeLayout(false);
            this.gbTA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.CheckBox cbSchoonmaak;
        private System.Windows.Forms.GroupBox gbTA;
        private System.Windows.Forms.RadioButton rbJa;
        private System.Windows.Forms.RadioButton rbNee;
        private System.Windows.Forms.ListBox lbHistorie;
        private System.Windows.Forms.Label lblHistorie;
        private System.Windows.Forms.TextBox tbSpoornummer;
        private System.Windows.Forms.TextBox tbTramnummer;
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Label lblTramnummer;
        private System.Windows.Forms.TextBox tbSectienummer;
        private System.Windows.Forms.Label lblSectienummer;
    }
}
