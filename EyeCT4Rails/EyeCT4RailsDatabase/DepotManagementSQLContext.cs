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
        public void ChangeTramStatus(int tramId, Status status)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"tram\" " +
                                                      "SET status = :status " +
                                                      "WHERE id = :id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":status", OracleDbType.Varchar2)).Value = Convert.ToString(status);
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = tramId;

            command.ExecuteNonQuery();
        }

        public void SetTrackBlocked(int trackId, bool blocked)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"section\" " +
                                                      "SET blocked = :blocked " +
                                                      "WHERE track_id = :id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":blocked", OracleDbType.Int32)).Value = blocked ? 1 : 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = trackId;

            command.ExecuteNonQuery();
        }

        public void SetSectionBlocked(int sectionId, bool blocked)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"section\" " +
                                                      "SET blocked = :blocked " +
                                                      "WHERE id = :id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":blocked", OracleDbType.Int32)).Value = blocked ? 1 : 0;
            command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = sectionId;

            command.ExecuteNonQuery();
        }

        public void ReserveSection(int tramId, int sectionId)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"section\" " +
                                                      "SET tram_id = :tram_id " +
                                                      "WHERE id = :section_id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":tram_id", OracleDbType.Int32)).Value = tramId;
            command.Parameters.Add(new OracleParameter(":section_id", OracleDbType.Int32)).Value = sectionId;

            command.ExecuteNonQuery();
        }

        public void RemoveTram(int sectionId)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"section\" " +
                                                      "SET tram_id = NULL " +
                                                      "WHERE id = :section_id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":section_id", OracleDbType.Int32)).Value = sectionId;

            command.ExecuteNonQuery();
        }

        public List<Tram> GetAllTrams()
        {
            List<Tram> trams = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT t.id, t.tramtype, t.status, t.line_id, t.forced, " +
                                                      "COUNT((SELECT id FROM \"job\" WHERE job_type = 'Cleanup' AND tram_id = t.id)) AS \"Schoonmaak\", " +
                                                      "COUNT((SELECT id FROM \"job\" WHERE job_type = 'Maintenance' AND tram_id = t.id)) AS \"Reparaties\" FROM \"tram\" t " +
                                                      "GROUP by t.id, t.tramtype, t.status, t.line_id, t.forced", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TramType type = (TramType)Enum.Parse(typeof(TramType), reader.GetString(1));
                Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(2));
                Tram tram = new Tram(reader.GetInt32(0), type, status, new Line(reader.GetInt32(3)), reader.GetInt32(4) == 1);

                trams.Add(tram);
            }

            return trams;
        } 

        public Depot GetDepot(string name)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT id " +
                                                      "FROM \"depot\" " +
                                                      "WHERE name = :name", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2)).Value = name;

            int id = Convert.ToInt32(command.ExecuteScalar());
            Depot depot = new Depot(id, name);

            List<Track> tracks = GetTracks(depot);
            foreach (Track track in tracks)
            {
                List<Section> sections = GetSections(track);
                foreach (Section section in sections)
                {
                    Section next = sections.Find(s => s.Id == section.Id + 1);
                    if (next != null)
                    {
                        section.AddNextSection(next);
                    }

                    Section previous = sections.Find(s => s.Id == section.Id - 1);
                    if (previous != null)
                    {
                        section.AddPreviousSection(previous);
                    }

                    track.AddSection(section);
                }

                depot.AddTrack(track);
            }

            List<Tram> trams = GetAllTrams();
            trams.ForEach(t => depot.AddTram(t));

            return depot;
        }

        private List<Track> GetTracks(Depot depot)
        {
            List<Track> list = new List<Track>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT id " +
                                                      "FROM \"track\" " +
                                                      "WHERE depot_id = :depot_id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":depot_id", OracleDbType.Int32)).Value = depot.Id;

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
            OracleCommand command = new OracleCommand("SELECT s.id, s.blocked, s.tram_id " +
                                                      "FROM \"section\" s " +
                                                      "WHERE track_id = :track_id ", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":track_id", OracleDbType.Int32)).Value = track.Id;

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
                    Tram tram = GetAllTrams().Find(t => t.Id == reader.GetInt32(2));
                    Section section = new Section(sectionId, blocked, tram);
                    list.Add(section);
                }
            }

            return list;
        }    
    }
}
