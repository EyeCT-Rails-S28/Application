using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcToggleBlokkade
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.lblSectornummer = new System.Windows.Forms.Label();
            this.nudSpoornummer = new System.Windows.Forms.NumericUpDown();
            this.nudSectornummer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(148, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(38, 91);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(10, 12);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(75, 13);
            this.lblSpoornummer.TabIndex = 9;
            this.lblSpoornummer.Text = "Spoornummer:";
            // 
            // lblSectornummer
            // 
            this.lblSectornummer.AutoSize = true;
            this.lblSectornummer.Location = new System.Drawing.Point(144, 12);
            this.lblSectornummer.Name = "lblSectornummer";
            this.lblSectornummer.Size = new System.Drawing.Size(78, 13);
            this.lblSectornummer.TabIndex = 8;
            this.lblSectornummer.Text = "Sectornummer:";
            // 
            // nudSpoornummer
            // 
            this.nudSpoornummer.Location = new System.Drawing.Point(13, 46);
            this.nudSpoornummer.Name = "nudSpoornummer";
            this.nudSpoornummer.Size = new System.Drawing.Size(120, 20);
            this.nudSpoornummer.TabIndex = 14;
            // 
            // nudSectornummer
            // 
            this.nudSectornummer.Location = new System.Drawing.Point(147, 46);
            this.nudSectornummer.Name = "nudSectornummer";
            this.nudSectornummer.Size = new System.Drawing.Size(120, 20);
            this.nudSectornummer.TabIndex = 15;
            // 
            // UcToggleBlokkade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudSectornummer);
            this.Controls.Add(this.nudSpoornummer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSpoornummer);
            this.Controls.Add(this.lblSectornummer);
            this.Name = "UcToggleBlokkade";
            this.Size = new System.Drawing.Size(294, 147);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Label lblSectornummer;
        private System.Windows.Forms.NumericUpDown nudSpoornummer;
        private System.Windows.Forms.NumericUpDown nudSectornummer;
    }
}
