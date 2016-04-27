namespace EyeCT4RailsUI.Forms.Login
{
    partial class UcMaakGebruiker
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
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbWachtwoord = new System.Windows.Forms.TextBox();
            this.tbHerhaalWachtwoord = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblWachtwoord = new System.Windows.Forms.Label();
            this.lblHerhaalWachtwoord = new System.Windows.Forms.Label();
            this.lblNaam = new System.Windows.Forms.Label();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(124, 38);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(174, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // tbWachtwoord
            // 
            this.tbWachtwoord.Location = new System.Drawing.Point(124, 64);
            this.tbWachtwoord.Name = "tbWachtwoord";
            this.tbWachtwoord.Size = new System.Drawing.Size(174, 20);
            this.tbWachtwoord.TabIndex = 3;
            // 
            // tbHerhaalWachtwoord
            // 
            this.tbHerhaalWachtwoord.Location = new System.Drawing.Point(124, 90);
            this.tbHerhaalWachtwoord.Name = "tbHerhaalWachtwoord";
            this.tbHerhaalWachtwoord.Size = new System.Drawing.Size(174, 20);
            this.tbHerhaalWachtwoord.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblWachtwoord
            // 
            this.lblWachtwoord.AutoSize = true;
            this.lblWachtwoord.Location = new System.Drawing.Point(13, 67);
            this.lblWachtwoord.Name = "lblWachtwoord";
            this.lblWachtwoord.Size = new System.Drawing.Size(71, 13);
            this.lblWachtwoord.TabIndex = 6;
            this.lblWachtwoord.Text = "Wachtwoord:";
            // 
            // lblHerhaalWachtwoord
            // 
            this.lblHerhaalWachtwoord.AutoSize = true;
            this.lblHerhaalWachtwoord.Location = new System.Drawing.Point(13, 93);
            this.lblHerhaalWachtwoord.Name = "lblHerhaalWachtwoord";
            this.lblHerhaalWachtwoord.Size = new System.Drawing.Size(105, 13);
            this.lblHerhaalWachtwoord.TabIndex = 7;
            this.lblHerhaalWachtwoord.Text = "Herhaal wachtwoord";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(13, 15);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(38, 13);
            this.lblNaam.TabIndex = 8;
            this.lblNaam.Text = "Naam:";
            // 
            // tbNaam
            // 
            this.tbNaam.Location = new System.Drawing.Point(124, 12);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(174, 20);
            this.tbNaam.TabIndex = 9;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(124, 155);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(174, 23);
            this.btnCreateUser.TabIndex = 10;
            this.btnCreateUser.Text = "Maak gebruiker";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // cbRole
            // 
            this.cbRole.AutoCompleteCustomSource.AddRange(new string[] {
            "Administrator",
            "Beheerder",
            "Schoonmaker",
            "Reparateur",
            "Machinist"});
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Administrator",
            "Cleanup",
            "DepotManager",
            "Driver",
            "Mechanic"});
            this.cbRole.Location = new System.Drawing.Point(124, 117);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(174, 21);
            this.cbRole.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(13, 120);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 13);
            this.lblRol.TabIndex = 12;
            this.lblRol.Text = "Rol:";
            // 
            // UcMaakGebruiker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.btnCreateUser);
            this.Controls.Add(this.tbNaam);
            this.Controls.Add(this.lblNaam);
            this.Controls.Add(this.lblHerhaalWachtwoord);
            this.Controls.Add(this.lblWachtwoord);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbHerhaalWachtwoord);
            this.Controls.Add(this.tbWachtwoord);
            this.Controls.Add(this.tbEmail);
            this.Name = "UcMaakGebruiker";
            this.Size = new System.Drawing.Size(357, 216);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbWachtwoord;
        private System.Windows.Forms.TextBox tbHerhaalWachtwoord;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblWachtwoord;
        private System.Windows.Forms.Label lblHerhaalWachtwoord;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblRol;
    }
}
