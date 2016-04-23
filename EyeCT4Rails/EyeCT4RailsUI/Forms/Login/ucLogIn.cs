using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Login
{
    public partial class UcLogIn : UserControl
    {
        public event EventHandler LoginSucceeded;

        public UcLogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                User user = UserRepository.Instance.LoginUser(tbEmail.Text, tbPassword.Text);

                LoginSucceeded?.Invoke(user, new EventArgs());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                //test
                LoginSucceeded?.Invoke(new User(1, "test", "test@test.test", Role.Administrator), new EventArgs());
            }
        }

        private User CheckLogin()
        {
            return null;
        }
    }
}
