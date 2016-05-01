using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string query = "UPDATE \"tram\" " +
                           "SET status = :status " +
                           "WHERE id = :id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":status", Convert.ToString(status)},
                {":id", tramId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void SetTrackBlocked(int trackId, bool blocked)
        {
            string query = "UPDATE \"section\" " +
                                                      "SET blocked = :blocked " +
                                                      "WHERE track_id = :id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":blocked", blocked ? 1 : 0},
                {":id", trackId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void SetSectionBlocked(int sectionId, bool blocked)
        {
            string query = "UPDATE \"section\" " +
                                                      "SET blocked = :blocked " +
                                                      "WHERE id = :id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":blocked", blocked ? 1 : 0},
                {":id", sectionId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void ReserveSection(int tramId, int sectionId)
        {
            string query = "UPDATE \"section\" " +
                                                      "SET tram_id = :tram_id " +
                                                      "WHERE id = :section_id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":tram_id", tramId},
                {":section_id", sectionId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void RemoveTram(int sectionId)
        {
            string query = "UPDATE \"section\" " +
                                                      "SET tram_id = NULL " +
                                                      "WHERE id = :section_id";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":section_id", sectionId}};

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public List<Tram> GetTramsWithReservedFlag()
        {
            string query = "SELECT id, tramtype, status, line_id, forced " +
                                                      "FROM \"tram\" " +
                                                      "WHERE (status = :status)";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":status", "Gereserveerd"}};

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                List<Tram> trams = new List<Tram>();
                while (reader.Read())
                {
                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(1));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(2));
                    Tram tram = new Tram(reader.GetInt32(0), type, status, new Line(reader.GetInt32(3)),
                        reader.GetInt32(4) == 1);

                    trams.Add(tram);
                }

                return trams;
            }
        } 

        public List<Tram> GetAllTrams()
        {
            string query = "SELECT t.id, t.tramtype, t.status, t.line_id, t.forced FROM \"tram\" t";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<Tram> trams = new List<Tram>();
                while (reader.Read())
                {
                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(1));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(2));
                    Tram tram = new Tram(reader.GetInt32(0), type, status, new Line(reader.GetInt32(3)),
                        reader.GetInt32(4) == 1);

                    trams.Add(tram);
                }

                return trams;
            }
        } 

        public Depot GetDepot(string name)
        {
            Depot depot;
            string query = "SELECT id " +
                                                      "FROM \"depot\" " +
                                                      "WHERE name = :name";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":name", name}};

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                int id = -1;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                }
                depot = new Depot(id, name);
            }

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
                    Section next = track.Sections.Find(s => s.Id == current.Id + 1);
                    if (next != null)
                    {
                        sections.Find(x => x.Id == current.Id).AddNextSection(sections.Find(y => y.Id == next.Id));
                    }

                    Section previous = track.Sections.Find(s => s.Id == current.Id - 1);
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
            string query = "SELECT id " +
                                                      "FROM \"track\" " +
                                                      "WHERE depot_id = :depot_id";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":depot_id", depot.Id}};

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                List<Track> list = new List<Track>();
                while (reader.Read())
                {
                    Track track = new Track(reader.GetInt32(0));
                    list.Add(track);
                }

                return list;
            }
        }

        /// <summary>
        /// Gets all the sections in the database and adds them to the track that exists in the given list of tracks.
        /// </summary>
        /// <param name="trams">The trams that could be parked on the sections.</param>
        /// <param name="tracks">The tracks the section can be part of.</param>
        /// <returns>All the sections in the database.</returns>
        private List<Section> GetSections(List<Tram> trams, List<Track> tracks)
        {
            string query = "SELECT s.id, s.blocked, s.tram_id, s.track_id FROM \"section\" s";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<Section> list = new List<Section>();
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
}
