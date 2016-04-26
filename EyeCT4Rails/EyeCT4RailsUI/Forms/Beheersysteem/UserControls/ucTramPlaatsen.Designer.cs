using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcTramPlaatsen
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
            this.lblTramnummer = new System.Windows.Forms.Label();
            this.lblSectornummer = new System.Windows.Forms.Label();
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudTramnummer = new System.Windows.Forms.NumericUpDown();
            this.nudSectornummer = new System.Windows.Forms.NumericUpDown();
            this.nudSpoornummer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudTramnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTramnummer
            // 
            this.lblTramnummer.AutoSize = true;
            this.lblTramnummer.Location = new System.Drawing.Point(13, 42);
            this.lblTramnummer.Name = "lblTramnummer";
            this.lblTramnummer.Size = new System.Drawing.Size(71, 13);
            this.lblTramnummer.TabIndex = 0;
            this.lblTramnummer.Text = "Tramnummer:";
            // 
            // lblSectornummer
            // 
            this.lblSectornummer.AutoSize = true;
            this.lblSectornummer.Location = new System.Drawing.Point(284, 42);
            this.lblSectornummer.Name = "lblSectornummer";
            this.lblSectornummer.Size = new System.Drawing.Size(78, 13);
            this.lblSectornummer.TabIndex = 1;
            this.lblSectornummer.Text = "Sectornummer:";
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(150, 42);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(75, 13);
            this.lblSpoornummer.TabIndex = 2;
            this.lblSpoornummer.Text = "Spoornummer:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(99, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudTramnummer
            // 
            this.nudTramnummer.Location = new System.Drawing.Point(16, 80);
            this.nudTramnummer.Name = "nudTramnummer";
            this.nudTramnummer.Size = new System.Drawing.Size(107, 20);
            this.nudTramnummer.TabIndex = 14;
            // 
            // nudSectornummer
            // 
            this.nudSectornummer.Location = new System.Drawing.Point(287, 80);
            this.nudSectornummer.Name = "nudSectornummer";
            this.nudSectornummer.Size = new System.Drawing.Size(107, 20);
            this.nudSectornummer.TabIndex = 17;
            // 
            // nudSpoornummer
            // 
            this.nudSpoornummer.Location = new System.Drawing.Point(153, 80);
            this.nudSpoornummer.Name = "nudSpoornummer";
            this.nudSpoornummer.Size = new System.Drawing.Size(107, 20);
            this.nudSpoornummer.TabIndex = 16;
            // 
            // UcTramPlaatsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudSectornummer);
            this.Controls.Add(this.nudSpoornummer);
            this.Controls.Add(this.nudTramnummer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSpoornummer);
            this.Controls.Add(this.lblSectornummer);
            this.Controls.Add(this.lblTramnummer);
            this.Name = "UcTramPlaatsen";
            this.Size = new System.Drawing.Size(417, 200);
            ((System.ComponentModel.ISupportInitialize)(this.nudTramnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTramnummer;
        private System.Windows.Forms.Label lblSectornummer;
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudTramnummer;
        private System.Windows.Forms.NumericUpDown nudSectornummer;
        private System.Windows.Forms.NumericUpDown nudSpoornummer;
    }
}
