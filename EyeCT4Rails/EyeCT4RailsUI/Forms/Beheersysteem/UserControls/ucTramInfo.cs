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

            AddTrams();
        }

        private void AddTrams()
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            List<Tram> trams = depot.Trams;

            try
            {
                foreach (Tram tram in trams)
                {
                    int lineId = tram.PreferredLine.Id;
                    dataGridView.Rows.Add(tram.Id, lineId == -1 ? "ocv" : Convert.ToString(lineId), tram.TramType.GetDescription(), Convert.ToString(tram.Status), GetTrackForTram(depot, tram)?.Id ?? 0);
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
