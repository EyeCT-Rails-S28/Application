using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    public class DepotManagementSqlContext : IDepotManagementContext
    {
        public void ChangeTramStatus(Tram tram, Status status)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("change_tram_status", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_tram_id", OracleDbType.Int32).Value = tram.Id);
            command.Parameters.Add(new OracleParameter("p_status", OracleDbType.Varchar2).Value = Convert.ToString(status));

            command.ExecuteNonQuery();
        }

        public void SetTrackBlocked(Track track, bool blocked)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("set_track_blocked", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32).Value = track.Id);
            command.Parameters.Add(new OracleParameter("p_blocked", OracleDbType.Int32).Value = blocked ? 1 : 0);

            command.ExecuteNonQuery();
        }

        public void SetSectionBlocked(Section section, bool blocked)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("set_section_blocked", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32).Value = section.Id);
            command.Parameters.Add(new OracleParameter("p_blocked", OracleDbType.Int32).Value = blocked ? 1 : 0);

            command.ExecuteNonQuery();
        }

        public void ReserveSection(Tram tram, Section section)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("reserve_section", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_section_id", OracleDbType.Int32).Value = section.Id);
            command.Parameters.Add(new OracleParameter("p_tram_id", OracleDbType.Int32).Value = tram.Id);

            command.ExecuteNonQuery();
        }

        public Depot GetDepot(string name)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("get_depot", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_name", OracleDbType.Varchar2).Value = name);

            int id = Convert.ToInt32(command.ExecuteScalar());
            Depot depot = new Depot(id, name);

            List<Track> tracks = GetTracks(depot);
            foreach (Track track in tracks)
            {
                List<Section> sections = GetSections(track);
                foreach (Section section in sections)
                {
                    track.AddSection(section);
                }
            }


            return depot;
        }

        private List<Track> GetTracks(Depot depot)
        {
            List<Track> list = new List<Track>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("get_tracks", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_depot_id", OracleDbType.Int32).Value = depot.Id);

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Track track = new Track(reader.GetInt32(0));
                list.Add(track);
            }

            return list;
        }

        private List<Section> GetSections(Track track)
        {
            List<Section> list = new List<Section>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("get_sections", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_track_id", OracleDbType.Int32).Value = track.Id);

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int sectionId = reader.GetInt32(0);
                bool blocked = reader.GetInt32(1) == 1;
                if (reader.IsDBNull(2))
                {
                    Section section = new Section(sectionId, blocked);
                    list.Add(section);
                }
                else
                {
                    int tramId = reader.GetInt32(2);
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(3));
                    Line line = new Line(reader.GetInt32(4));
                    bool forced = reader.GetInt32(5) == 1;

                    Tram tram = new Tram(tramId, status, line, forced);
                    Section section = new Section(sectionId, blocked, tram);
                    list.Add(section);
                }
            }

            return list;
        } 
    }
}
