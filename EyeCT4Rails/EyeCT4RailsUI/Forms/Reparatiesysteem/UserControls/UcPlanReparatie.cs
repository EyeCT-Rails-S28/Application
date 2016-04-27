using System;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
{
    public partial class UcPlanReparatie : UserControl
    {
        private User _user;

        public UcPlanReparatie()
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
                int userID = _user.Id;
                int tramID = Convert.ToInt32(tbTramID.Text);
                DateTime date = dtpDatum.Value;

                if (MaintenanceRepository.Instance.ScheduleJob(jobSize, userID, tramID, date))
                {
                    MessageBox.Show("De opgegeven reparatie is succesvol ingepland.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Er is een fout opgetreden bij het inplannen van een reparatie: {ex.Message}");
            }
        }

        private void btnMeerdere_Click(object sender, EventArgs e)
        {
            try
            {
                JobSize jobSize = (JobSize)Enum.Parse(typeof(JobSize), cbGrootteBeurt.Text);
                int userID = _user.Id;
                int tramID = Convert.ToInt32(tbTramID.Text);
                DateTime date = dtpDatum.Value;
                DateTime endDate = dtpEindDatum.Value;
                int interval = Convert.ToInt32(nudInterval.Value);

                if (MaintenanceRepository.Instance.ScheduleRecurringJob(jobSize, userID, tramID, date, interval, endDate))
                {
                    MessageBox.Show("Alle opgegeven reparaties zijn succesvol ingepland.");
                }
                else
                {
                    MessageBox.Show("Éen of meer opgegeven reparatie(s) is/zijn niet succesvol ingepland.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show($"Er is een fout opgetreden bij het inplannen van de reparaties: {ex.Message}");
            }
        }
    }
}
