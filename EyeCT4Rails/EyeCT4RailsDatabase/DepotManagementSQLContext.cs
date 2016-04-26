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
            OracleCommand command = new OracleCommand("SELECT t.id, t.status, t.line_id, t.forced, " +
                                                      "COUNT((SELECT id FROM \"job\" WHERE job_type = 'Cleanup' AND tram_id = t.id)) AS \"Schoonmaak\", " +
                                                      "COUNT((SELECT id FROM \"job\" WHERE job_type = 'Maintenance' AND tram_id = t.id)) AS \"Reparaties\" FROM \"tram\" t " +
                                                      "GROUP by t.id, t.status, t.line_id, t.forced", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(1));
                Tram tram = new Tram(reader.GetInt32(0), status, new Line(reader.GetInt32(2)), reader.GetInt32(3) == 1);

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
                    track.AddSection(section);
                }

                depot.AddTrack(track);
            }


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
            OracleCommand command = new OracleCommand("SELECT s.id, s.blocked, s.tram_id, t.status, t.line_id, t.forced " +
                                                      "FROM \"section\" s, \"tram\" t " +
                                                      "WHERE track_id = :track_id " +
                                                      "AND(s.tram_id IS NULL OR s.tram_id = t.id)", connection);
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

        public void UpdateSections()
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT COUNT(id) FROM \"section\"", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();

            int idCount = 0;

            while (reader.Read())
            {
                idCount = reader.GetInt32(0);
            }

            UpdatePreviousSections(idCount);
            UpdateNextSections(idCount);
        }

        private void UpdatePreviousSections(int idCount)
        {
            for (int i = 1; i <= idCount; i++)
            {
                OracleConnection connection = Database.Instance.Connection;
                OracleCommand command = new OracleCommand("UPDATE \"section\"" +
                                                          "SET previous_id = (SELECT s.id FROM \"section\" s WHERE s.id = (:id - 1) AND s.track_id = (SELECT track_id FROM \"section\" WHERE id = :id))" +
                                                          "WHERE id = :id", connection);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = i;
                command.ExecuteNonQuery();
            }
        }

        private void UpdateNextSections(int idCount)
        {
            for (int i = 1; i <= idCount; i++)
            {
                OracleConnection connection = Database.Instance.Connection;
                OracleCommand command = new OracleCommand("UPDATE \"section\"" +
                                                          "SET next_id = (SELECT s.id FROM \"section\" s WHERE s.id = (:id + 1) AND s.track_id = (SELECT track_id FROM \"section\" WHERE id = :id))" +
                                                          "WHERE id = :id", connection);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32)).Value = i;
                command.ExecuteNonQuery();
            }
        }
    }
}
