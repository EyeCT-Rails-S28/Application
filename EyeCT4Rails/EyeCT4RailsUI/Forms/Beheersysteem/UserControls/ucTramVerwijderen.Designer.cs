using EyeCT4RailsLib;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    partial class UcTramVerwijderen
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudSectornummer = new System.Windows.Forms.NumericUpDown();
            this.lblSectornummer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(32, 98);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // nudSectornummer
            // 
            this.nudSectornummer.Location = new System.Drawing.Point(32, 64);
            this.nudSectornummer.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudSectornummer.Name = "nudSectornummer";
            this.nudSectornummer.Size = new System.Drawing.Size(107, 20);
            this.nudSectornummer.TabIndex = 21;
            // 
            // lblSectornummer
            // 
            this.lblSectornummer.AutoSize = true;
            this.lblSectornummer.Location = new System.Drawing.Point(29, 26);
            this.lblSectornummer.Name = "lblSectornummer";
            this.lblSectornummer.Size = new System.Drawing.Size(78, 13);
            this.lblSectornummer.TabIndex = 18;
            this.lblSectornummer.Text = "Sectornummer:";
            // 
            // UcTramVerwijderen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudSectornummer);
            this.Controls.Add(this.lblSectornummer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "UcTramVerwijderen";
            this.Size = new System.Drawing.Size(420, 159);
            ((System.ComponentModel.ISupportInitialize)(this.nudSectornummer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudSectornummer;
        private System.Windows.Forms.Label lblSectornummer;
    }
}
