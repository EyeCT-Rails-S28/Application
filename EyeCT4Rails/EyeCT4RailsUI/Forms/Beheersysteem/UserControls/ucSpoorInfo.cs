using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcSpoorInfo : UserControl
    {

        public UcSpoorInfo()
        {
            InitializeComponent();
        }

        public void SetSelection(Depot depot, Track track)
        {
            lblSpoornummer.Text += $" {track.Id}";

            try
            {
                foreach (Section section in track.Sections)
                {
                    dataGridView.Rows.Add(track.Id, section.Id, section.Blocked ? "Ja" : "Nee", section.Tram?.Id ?? 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
