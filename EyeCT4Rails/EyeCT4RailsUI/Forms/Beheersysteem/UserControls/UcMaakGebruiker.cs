using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcMaakGebruiker : UserControl
    {
        private bool invalid;

        public UcMaakGebruiker()
        {
            InitializeComponent();

            cbRole.DataSource = Enum.GetValues(typeof (Role));
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbNaam.Text;
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Gebruikersnaam mag niet leeg zijn!");
                    return;
                }

                string email = tbEmail.Text;
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Het opgegeven email adres is niet een juist adres.");
                    return;
                }

                string password = tbWachtwoord.Text;
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Het opgegeven wachtwoord mag niet leeg zijn.");
                    return;
                }

                string password2 = tbHerhaalWachtwoord.Text;
                if (!password.Equals(password2))
                {
                    MessageBox.Show("De opgegeven wachtwoorden komen niet overeen.");
                    return;
                }

                Role role = (Role)Enum.Parse(typeof(Role), Convert.ToString(cbRole.SelectedValue));
                UserRepository.Instance.CreateUser(name, password, email, role);

                MessageBox.Show($"Gebruiker {name} is succesvol toegevoegd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        public bool IsValidEmail(string value)
        {
            invalid = false;
            if (string.IsNullOrEmpty(value))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                value = Regex.Replace(value, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if value is in valid e-mail format.
            try
            {
                return Regex.IsMatch(value,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }
}
