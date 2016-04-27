using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsUI.Forms.Beheersysteem.UserControls
{
    public partial class UcTramInfo : UserControl
    {
        public UcTramInfo()
        {
            InitializeComponent();
        }

        public void AddFromDepot(Depot depot)
        {
            List<Tram> trams = depot.Trams;

            try
            {
                foreach (Tram tram in trams)
                {
                    dataGridView.Rows.Add(tram.Id, tram.PreferredLine.Id, tram.TramType.GetDescription(), Convert.ToString(tram.Status), GetTrackForTram(depot, tram)?.Id ?? 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private Track GetTrackForTram(Depot depot, Tram tram)
        {
            List<Track> tracks = depot.Tracks;
            return (from t in tracks let sections = t.Sections from s in sections where s.Tram != null && s.Tram.Id == tram.Id select t).FirstOrDefault();
        }
    }
}
