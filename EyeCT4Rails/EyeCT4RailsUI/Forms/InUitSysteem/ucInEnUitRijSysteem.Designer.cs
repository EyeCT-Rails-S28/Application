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
            this.components = new System.ComponentModel.Container();
            this.btnBevestig = new System.Windows.Forms.Button();
            this.gbTA = new System.Windows.Forms.GroupBox();
            this.rbGeen = new System.Windows.Forms.RadioButton();
            this.rbDefect = new System.Windows.Forms.RadioButton();
            this.rbNee = new System.Windows.Forms.RadioButton();
            this.lbHistorie = new System.Windows.Forms.ListBox();
            this.lblHistorie = new System.Windows.Forms.Label();
            this.tbSpoornummer = new System.Windows.Forms.TextBox();
            this.tbTramnummer = new System.Windows.Forms.TextBox();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.lblTramnummer = new System.Windows.Forms.Label();
            this.tbSectienummer = new System.Windows.Forms.TextBox();
            this.lblSectienummer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbTA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(140, 42);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(112, 46);
            this.btnBevestig.TabIndex = 22;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // gbTA
            // 
            this.gbTA.Controls.Add(this.rbGeen);
            this.gbTA.Controls.Add(this.rbDefect);
            this.gbTA.Controls.Add(this.rbNee);
            this.gbTA.Location = new System.Drawing.Point(5, 94);
            this.gbTA.Name = "gbTA";
            this.gbTA.Size = new System.Drawing.Size(247, 117);
            this.gbTA.TabIndex = 20;
            this.gbTA.TabStop = false;
            this.gbTA.Text = "Technische assistentie nodig?";
            // 
            // rbGeen
            // 
            this.rbGeen.AutoSize = true;
            this.rbGeen.Checked = true;
            this.rbGeen.Location = new System.Drawing.Point(17, 30);
            this.rbGeen.Name = "rbGeen";
            this.rbGeen.Size = new System.Drawing.Size(51, 17);
            this.rbGeen.TabIndex = 14;
            this.rbGeen.TabStop = true;
            this.rbGeen.Text = "Geen";
            this.rbGeen.UseVisualStyleBackColor = true;
            // 
            // rbDefect
            // 
            this.rbDefect.AutoSize = true;
            this.rbDefect.Location = new System.Drawing.Point(17, 76);
            this.rbDefect.Name = "rbDefect";
            this.rbDefect.Size = new System.Drawing.Size(78, 17);
            this.rbDefect.TabIndex = 12;
            this.rbDefect.Text = "Onderhoud";
            this.rbDefect.UseVisualStyleBackColor = true;
            // 
            // rbNee
            // 
            this.rbNee.AutoSize = true;
            this.rbNee.Location = new System.Drawing.Point(17, 53);
            this.rbNee.Name = "rbNee";
            this.rbNee.Size = new System.Drawing.Size(88, 17);
            this.rbNee.TabIndex = 13;
            this.rbNee.Text = "Schoonmaak";
            this.rbNee.UseVisualStyleBackColor = true;
            // 
            // lbHistorie
            // 
            this.lbHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHistorie.FormattingEnabled = true;
            this.lbHistorie.Location = new System.Drawing.Point(302, 25);
            this.lbHistorie.Name = "lbHistorie";
            this.lbHistorie.Size = new System.Drawing.Size(204, 186);
            this.lbHistorie.TabIndex = 19;
            // 
            // lblHistorie
            // 
            this.lblHistorie.AutoSize = true;
            this.lblHistorie.Location = new System.Drawing.Point(299, 0);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(45, 13);
            this.lblHistorie.TabIndex = 18;
            this.lblHistorie.Text = "Historie:";
            // 
            // tbSpoornummer
            // 
            this.tbSpoornummer.Location = new System.Drawing.Point(5, 16);
            this.tbSpoornummer.Name = "tbSpoornummer";
            this.tbSpoornummer.ReadOnly = true;
            this.tbSpoornummer.Size = new System.Drawing.Size(100, 20);
            this.tbSpoornummer.TabIndex = 17;
            // 
            // tbTramnummer
            // 
            this.tbTramnummer.Location = new System.Drawing.Point(140, 16);
            this.tbTramnummer.Name = "tbTramnummer";
            this.tbTramnummer.Size = new System.Drawing.Size(112, 20);
            this.tbTramnummer.TabIndex = 16;
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(14, 0);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(77, 13);
            this.lblSpoornummer.TabIndex = 15;
            this.lblSpoornummer.Text = "Ga naar spoor:";
            // 
            // lblTramnummer
            // 
            this.lblTramnummer.AutoSize = true;
            this.lblTramnummer.Location = new System.Drawing.Point(156, 0);
            this.lblTramnummer.Name = "lblTramnummer";
            this.lblTramnummer.Size = new System.Drawing.Size(71, 13);
            this.lblTramnummer.TabIndex = 14;
            this.lblTramnummer.Text = "Tramnummer:";
            // 
            // tbSectienummer
            // 
            this.tbSectienummer.Location = new System.Drawing.Point(5, 65);
            this.tbSectienummer.Name = "tbSectienummer";
            this.tbSectienummer.ReadOnly = true;
            this.tbSectienummer.Size = new System.Drawing.Size(100, 20);
            this.tbSectienummer.TabIndex = 24;
            // 
            // lblSectienummer
            // 
            this.lblSectienummer.AutoSize = true;
            this.lblSectienummer.Location = new System.Drawing.Point(12, 49);
            this.lblSectienummer.Name = "lblSectienummer";
            this.lblSectienummer.Size = new System.Drawing.Size(79, 13);
            this.lblSectienummer.TabIndex = 23;
            this.lblSectienummer.Text = "Ga naar sectie:";
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // UcInEnUitRijSysteem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSectienummer);
            this.Controls.Add(this.lblSectienummer);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.gbTA);
            this.Controls.Add(this.lbHistorie);
            this.Controls.Add(this.lblHistorie);
            this.Controls.Add(this.tbSpoornummer);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.lblSpoornummer);
            this.Controls.Add(this.lblTramnummer);
            this.Name = "UcInEnUitRijSysteem";
            this.Size = new System.Drawing.Size(509, 211);
            this.gbTA.ResumeLayout(false);
            this.gbTA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.GroupBox gbTA;
        private System.Windows.Forms.RadioButton rbDefect;
        private System.Windows.Forms.RadioButton rbNee;
        private System.Windows.Forms.ListBox lbHistorie;
        private System.Windows.Forms.Label lblHistorie;
        private System.Windows.Forms.TextBox tbSpoornummer;
        private System.Windows.Forms.TextBox tbTramnummer;
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Label lblTramnummer;
        private System.Windows.Forms.TextBox tbSectienummer;
        private System.Windows.Forms.Label lblSectienummer;
        private System.Windows.Forms.RadioButton rbGeen;
        private System.Windows.Forms.Timer timer;
    }
}
