
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
            this.lblSpoornummer = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.nudSpoornummer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSpoornummer
            // 
            this.lblSpoornummer.AutoSize = true;
            this.lblSpoornummer.Location = new System.Drawing.Point(98, 7);
            this.lblSpoornummer.Name = "lblSpoornummer";
            this.lblSpoornummer.Size = new System.Drawing.Size(75, 13);
            this.lblSpoornummer.TabIndex = 5;
            this.lblSpoornummer.Text = "Spoornummer:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(296, 206);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // nudSpoornummer
            // 
            this.nudSpoornummer.Location = new System.Drawing.Point(101, 32);
            this.nudSpoornummer.Name = "nudSpoornummer";
            this.nudSpoornummer.Size = new System.Drawing.Size(90, 20);
            this.nudSpoornummer.TabIndex = 15;
            // 
            // UcSpoorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudSpoornummer);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblSpoornummer);
            this.Name = "UcSpoorInfo";
            this.Size = new System.Drawing.Size(307, 287);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpoornummer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSpoornummer;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown nudSpoornummer;
    }
}
