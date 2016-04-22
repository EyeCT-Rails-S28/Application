using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

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
            User user = CheckLogin();

            if (user != null)
            {
                LoginSucceeded?.Invoke(user, new EventArgs());
            }

            //test
            LoginSucceeded?.Invoke(new User(1, "test", "test@test.test", Role.Administrator), new EventArgs());
        }

        private User CheckLogin()
        {
            return null;
        }
    }
}
