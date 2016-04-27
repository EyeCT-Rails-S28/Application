using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public List<Tram> GetTramsWithReservedFlag()
        {
            List<Tram> trams = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT id, tramtype, status, line_id, forced " +
                                                      "FROM \"tram\" " +
                                                      "WHERE (status = :status)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":status", OracleDbType.Varchar2)).Value = "Gereserveerd";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TramType type = (TramType)Enum.Parse(typeof(TramType), reader.GetString(1));
                Status status = (Status)Enum.Parse(typeof(Status), reader.GetString(2));
                Tram tram = new Tram(reader.GetInt32(0), type, status, new Line(reader.GetInt32(3)), reader.GetInt32(4) == 1);

                trams.Add(tram);
            }

            return trams;
        } 

        public List<Tram> GetAllTrams()
        {
            List<Tram> trams = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT t.id, t.tramtype, t.status, t.line_id, t.forced FROM \"tram\" t", connection);
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

            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Track> tracks = GetTracks(depot);
            tracks.ForEach(t => depot.AddTrack(t));
            Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to get all the tracks from the db");

            watch.Restart();
            List<Tram> trams = GetAllTrams();
            trams.ForEach(t => depot.AddTram(t));
            Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to get all the trams from the db");

            watch.Restart();
            List<Section> sections = GetSections(trams, tracks);
            foreach (var track in tracks)
            {
                foreach (var current in track.Sections)
                {
                    Section next = sections.Find(s => s.Id == current.Id + 1);
                    if (next != null)
                    {
                        sections.Find(x => x.Id == current.Id).AddNextSection(sections.Find(y => y.Id == next.Id));
                    }

                    Section previous = sections.Find(s => s.Id == current.Id - 1);
                    if (previous != null)
                    {
                        sections.Find(x => x.Id == current.Id).AddPreviousSection(sections.Find(y => y.Id == previous.Id));
                    }
                }
            }
            Console.WriteLine($"It took {watch.ElapsedMilliseconds} ms to get all the sections from the db");

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

        /// <summary>
        /// Gets all the sections in the database and adds them to the track that exists in the given list of tracks.
        /// </summary>
        /// <param name="trams">The trams that could be parked on the sections.</param>
        /// <param name="tracks">The tracks the section can be part of.</param>
        /// <returns>All the sections in the database.</returns>
        private List<Section> GetSections(List<Tram> trams, List<Track> tracks)
        {
            List<Section> list = new List<Section>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT s.id, s.blocked, s.tram_id, s.track_id FROM \"section\" s", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int sectionId = reader.GetInt32(0);
                bool blocked = reader.GetInt32(1) == 1;
                Section section;
                if (reader.IsDBNull(2))
                {
                    section = new Section(sectionId, blocked);                   
                }
                else
                {
                    //Finds the tram that is parked on this section.
                    Tram tram = trams.Find(t => t.Id == reader.GetInt32(2));
                    section = new Section(sectionId, blocked, tram);                   
                }

                list.Add(section);
                //Adds the section to the track.
                tracks.Find(x => x.Id == reader.GetInt32(3)).AddSection(section);
            }

            return list;
        }
    }
}
