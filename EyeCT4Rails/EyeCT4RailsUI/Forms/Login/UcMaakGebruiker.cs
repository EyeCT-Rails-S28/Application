using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Login
{
    public partial class UcMaakGebruiker : UserControl
    {
        public UcMaakGebruiker()
        {
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbNaam.Text;
                string email = tbEmail.Text;
                string password = tbWachtwoord.Text;
                string password2 = tbHerhaalWachtwoord.Text;
                Role role = (Role)Enum.Parse(typeof(Role), cbRole.Text);

                if (password == password2 && ValidEmail(email) && name.Trim() != "")
                {
                    UserRepository.Instance.CreateUser(name, password, email, role);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidEmail(string email)
        {
            if (email.IndexOf("@") > -1 && email.IndexOf(".") > -1)
            {
                return true;
            }

            return false;
        }
    }
}
