using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase.SQLContexts
{
    public class MaintenanceSqlContext : IMaintenanceContext
    {
        public List<Tram> GetTramsInMaintenance()
        {
            string query = "SELECT id, tramtype, line_id, forced FROM \"tram\" WHERE status = 'Defect'";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<Tram> list = new List<Tram>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(1));
                    Status status = Status.Schoonmaak;
                    Line line = new Line(reader.GetInt32(2));
                    bool forced = reader.GetInt32(3) == 1;

                    list.Add(new Tram(id, type, status, line, forced));
                }

                return list;
            }
        }

        public List<Job> GetSchedule()
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id " +
                "FROM \"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 0 AND j.job_type = 'Maintenance' " +
                "ORDER BY j.\"date\" ASC";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<Job> list = new List<Job>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    JobSize size = (JobSize) Enum.Parse(typeof (JobSize), reader.GetString(2));

                    int tramId = reader.GetInt32(3);
                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(4));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(5));
                    Line line = new Line(reader.GetInt32(6));
                    bool forced = reader.GetByte(7) == 1;

                    Tram tram = new Tram(tramId, type, status, line, forced);

                    int userId = reader.GetInt32(8);
                    User user = new UserSqlContext().GetUser(userId);

                    list.Add(new Job(id, date, false, JobType.Maintenance, size, tram, user));
                }

                return list;
            }
        }

        public List<Job> GetHistory(int tramId)
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, u.id, t.tramtype, t.status, t.line_id, t.forced " +
                "FROM \"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 1 AND t.id = :id AND j.job_type = 'Maintenance' " +
                "ORDER BY j.\"date\" ASC";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", tramId}};

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                List<Job> list = new List<Job>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    JobSize size = (JobSize) Enum.Parse(typeof (JobSize), reader.GetString(2));

                    int userId = reader.GetInt32(3);
                    User user = new UserSqlContext().GetUser(userId);

                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(4));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(5));
                    Tram tram = new Tram(tramId, type, status, new Line(reader.GetInt32(6)), reader.GetInt32(7) == 1);

                    list.Add(new Job(id, date, false, JobType.Maintenance, size, tram, user));
                }

                return list;
            }
        }

        public List<Job> GetHistory()
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id " +
                "FROM\"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 1 AND j.job_type = 'Maintenance' " +
                "ORDER BY j.\"date\" ASC";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<Job> list = new List<Job>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    JobSize size = (JobSize) Enum.Parse(typeof (JobSize), reader.GetString(2));

                    int tramId = reader.GetInt32(3);
                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(4));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(5));
                    Line line = new Line(reader.GetInt32(6));
                    bool forced = reader.GetByte(7) == 1;

                    Tram tram = new Tram(tramId, type, status, line, forced);

                    int userId = reader.GetInt32(8);
                    User user = new UserSqlContext().GetUser(userId);

                    list.Add(new Job(id, date, false, JobType.Maintenance, size, tram, user));
                }

                return list;
            }
        }

        public void ScheduleJob(JobSize size, int userId, int tramId, DateTime date)
        {
            string query = "INSERT INTO \"job\"(user_id, tram_id, job_type, job_size, \"date\") " +
                           "VALUES(:user_id, :tram_id, 'Maintenance', :job_size, TO_DATE(:job_date, 'DD/MM/YYYY HH24:MI:SS'))";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":user_id", userId},
                {":tram_id", tramId},
                {":job_size", Convert.ToString(size)},
                {":job_date", date.ToString("dd/MM/yyyy HH:mm:ss")}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void RemoveScheduledJob(int jobId)
        {
            string query = "DELETE FROM \"job\" WHERE(id = :id)";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", jobId}};

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public void EditJobStatus(int jobId, bool isDone)
        {
            string query = "UPDATE \"job\" " +
                           "SET finished = :job_finished " +
                           "WHERE id = :cleanup_id";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":job_finished", isDone ? 1 : 0},
                {":cleanup_id", jobId}
            };

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
        }

        public bool CheckJobLimit(DateTime date, JobSize size)
        {
            string query = "SELECT COUNT(j.id) FROM \"job\" j " +
                           "WHERE TRUNC(j.\"date\") = TO_DATE(:job_date, 'DD/MM/YYYY') AND j.job_size = :job_size AND j.job_type = 'Maintenance'";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {":job_date", date.ToString("dd/MM/yyyy")},
                {":job_size", Convert.ToString(size)}
            };

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                int amount = 10;
                while (reader.Read())
                {
                    amount = Convert.ToInt32(reader[0]);
                }
                return size == JobSize.Big ? amount < 1 : amount < 4;
            }
        }
    }
}
