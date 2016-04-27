using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
{
    public partial class UcPlanSchoonmaak : UserControl
    {
        private User _user;

        public UcPlanSchoonmaak()
        {
            InitializeComponent();
        }

        public void SetUser(User user)
        {
            _user = user;

            tbUser.Text = user.Name;
        }

        private void btnEnkel_Click(object sender, EventArgs e)
        {
            try
            {
                JobSize jobSize = (JobSize)Enum.Parse(typeof(JobSize), cbGrootteBeurt.Text);
                int userId = _user.Id;
                int tramId = Convert.ToInt32(tbTramID.Text);
                DateTime date = dtpDatum.Value;

                if (CleanupRepository.Instance.ScheduleJob(jobSize, userId, tramId, date))
                {
                    MessageBox.Show("De opgegeven schoonmaakbeurt is succesvol ingepland.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van een schoonmaakbeurt: {ex.Message}");
            }
        }

        private void btnMeerdere_Click(object sender, EventArgs e)
        {
            try
            {
                JobSize jobSize = (JobSize)Enum.Parse(typeof(JobSize), cbGrootteBeurt.Text);
                int userId = _user.Id;
                int tramId = Convert.ToInt32(tbTramID.Text);
                DateTime date = dtpDatum.Value;
                DateTime endDate = dtpEindDatum.Value;
                int interval = Convert.ToInt32(nudInterval.Value);

                if (CleanupRepository.Instance.ScheduleRecurringJob(jobSize, userId, tramId, date, interval, endDate))
                {
                    MessageBox.Show("Alle opgegeven schoonmaakbeurten zijn succesvol ingepland.");
                }
                else
                {
                    MessageBox.Show("Éen of meer opgegeven schoonmaakbeurt(en) is/zijn niet succesvol ingepland.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van een schoonmaakbeurt: {ex.Message}");
            }
        }
    }
}
