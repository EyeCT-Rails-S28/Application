using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Schoonmaaksysteem.UserControls
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

            tbUserID.Text = _user.Id.ToString();
        }

        private void btnEnkel_Click(object sender, EventArgs e)
        {
            try
            {
                JobSize jobSize = (JobSize)Enum.Parse(typeof(JobSize), cbGrootteBeurt.Text);
                int userID = _user.Id;
                int tramID = Convert.ToInt32(tbTramID.Text);
                DateTime date = dtpDatum.Value;

                MaintenanceRepository.Instance.ScheduleJob(jobSize, userID, tramID, date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
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

                MaintenanceRepository.Instance.ScheduleRecurringJob(jobSize, userID, tramID, date, interval, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
