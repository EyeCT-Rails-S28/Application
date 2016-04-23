
namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcReserveringPlaatsen
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblSectornummer = new System.Windows.Forms.Label();
            this.lblTramnummer = new System.Windows.Forms.Label();
            this.cbReparatie = new System.Windows.Forms.CheckBox();
            this.nudTramnummer = new System.Windows.Forms.NumericUpDown();
            this.nudSectornummer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 110);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSectornummer
            // 
            this.lblSectornummer.AutoSize = true;
            this.lblSectornummer.Location = new System.Drawing.Point(149, 29);
            this.lblSectornummer.Name = "lblSectornummer";
            this.lblSectornummer.Size = new System.Drawing.Size(78, 13);
            this.lblSectornummer.TabIndex = 8;
            this.lblSectornummer.Text = "Sectornummer:";
            // 
            // lblTramnummer
            // 
            this.lblTramnummer.AutoSize = true;
            this.lblTramnummer.Location = new System.Drawing.Point(12, 29);
            this.lblTramnummer.Name = "lblTramnummer";
            this.lblTramnummer.Size = new System.Drawing.Size(71, 13);
            this.lblTramnummer.TabIndex = 7;
            this.lblTramnummer.Text = "Tramnummer:";
            // 
            // cbReparatie
            // 
            this.cbReparatie.AutoSize = true;
            this.cbReparatie.Location = new System.Drawing.Point(152, 110);
            this.cbReparatie.Name = "cbReparatie";
            this.cbReparatie.Size = new System.Drawing.Size(72, 17);
            this.cbReparatie.TabIndex = 12;
            this.cbReparatie.Text = "Reparatie";
            this.cbReparatie.UseVisualStyleBackColor = true;
            // 
            // nudTramnummer
            // 
            this.nudTramnummer.Location = new System.Drawing.Point(15, 67);
            this.nudTramnummer.Name = "nudTramnummer";
            this.nudTramnummer.Size = new System.Drawing.Size(120, 20);
            this.nudTramnummer.TabIndex = 13;
            // 
            // nudSectornummer
            // 
            this.nudSectornummer.Location = new System.Drawing.Point(147, 67);
            this.nudSectornummer.Name = "nudSectornummer";
            this.nudSectornummer.Size = new System.Drawing.Size(120, 20);
            this.nudSectornummer.TabIndex = 14;
            // 
            // UcReserveringPlaatsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudSectornummer);
            this.Controls.Add(this.nudTramnummer);
            this.Controls.Add(this.cbReparatie);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSectornummer);
            this.Controls.Add(this.lblTramnummer);
            this.Name = "UcReserveringPlaatsen";
            this.Size = new System.Drawing.Size(270, 162);
            ((System.ComponentModel.ISupportInitialize)(this.nudTramnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblSectornummer;
        private System.Windows.Forms.Label lblTramnummer;
        private System.Windows.Forms.CheckBox cbReparatie;
        private System.Windows.Forms.NumericUpDown nudTramnummer;
        private System.Windows.Forms.NumericUpDown nudSectornummer;
    }
}
