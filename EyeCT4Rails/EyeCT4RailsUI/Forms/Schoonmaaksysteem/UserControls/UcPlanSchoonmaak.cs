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

namespace EyeCT4RailsUI.Forms.Reparatiesysteem.UserControls
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

                CleanupRepository.Instance.ScheduleJob(jobSize, userID, tramID, date);
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

                CleanupRepository.Instance.ScheduleRecurringJob(jobSize, userID, tramID, date, interval, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        private void UcPlanSchoonmaak_Load(object sender, EventArgs e)
        {

        }
    }
}
