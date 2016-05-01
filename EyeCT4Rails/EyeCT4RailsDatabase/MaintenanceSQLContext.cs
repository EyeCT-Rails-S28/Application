using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
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

        public List<MaintenanceJob> GetSchedule()
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id, u.name, u.email, u.role " +
                "FROM \"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 0 AND j.job_type = 'Maintenance'";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<MaintenanceJob> list = new List<MaintenanceJob>();
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
                    string name = reader.GetString(9);
                    string email = reader.GetString(10);
                    Role privilege = (Role) Enum.Parse(typeof (Role), reader.GetString(11));

                    User user = new User(userId, name, email, privilege);

                    list.Add(new MaintenanceJob(id, date, false, size, tram, user));
                }

                return list;
            }
        }

        public List<MaintenanceJob> GetHistory(int tramId)
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, u.id, u.name, u.email, u.role, t.tramtype, t.status, t.line_id, t.forced " +
                "FROM \"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 1 AND t.id = :id AND j.job_type = 'Maintenance'";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", tramId}};

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, parameters, QueryType.Query))
            {
                List<MaintenanceJob> list = new List<MaintenanceJob>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime date = reader.GetDateTime(1);
                    JobSize size = (JobSize) Enum.Parse(typeof (JobSize), reader.GetString(2));

                    int userId = reader.GetInt32(3);
                    string name = reader.GetString(4);
                    string email = reader.GetString(5);
                    Role privilege = (Role) Enum.Parse(typeof (Role), reader.GetString(6));

                    User user = new User(userId, name, email, privilege);

                    TramType type = (TramType) Enum.Parse(typeof (TramType), reader.GetString(7));
                    Status status = (Status) Enum.Parse(typeof (Status), reader.GetString(8));
                    Tram tram = new Tram(tramId, type, status, new Line(reader.GetInt32(9)), reader.GetInt32(10) == 1);

                    list.Add(new MaintenanceJob(id, date, false, size, tram, user));
                }

                return list;
            }
        }

        public List<MaintenanceJob> GetHistory()
        {
            string query =
                "SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id, u.name, u.email, u.role " +
                "FROM\"job\" j " +
                "JOIN \"tram\" t ON t.id = j.tram_id " +
                "JOIN \"line\" l ON t.line_id = l.id " +
                "JOIN \"user\" u ON u.id = j.user_id " +
                "WHERE j.finished = 1 AND j.job_type = 'Maintenance'";

            using (OracleDataReader reader = Database.Instance.ExecuteQuery(query, QueryType.Query))
            {
                List<MaintenanceJob> list = new List<MaintenanceJob>();
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
                    string name = reader.GetString(9);
                    string email = reader.GetString(10);
                    Role privilege = (Role) Enum.Parse(typeof (Role), reader.GetString(11));

                    User user = new User(userId, name, email, privilege);

                    list.Add(new MaintenanceJob(id, date, false, size, tram, user));
                }

                return list;
            }
        }

        public bool ScheduleJob(JobSize size, int userId, int tramId, DateTime date)
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
            return true;
        }

        public bool RemoveScheduledJob(int jobId)
        {
            string query = "DELETE FROM \"job\" WHERE(id = :id)";

            Dictionary<string, object> parameters = new Dictionary<string, object> {{":id", jobId}};

            Database.Instance.ExecuteQuery(query, parameters, QueryType.NonQuery);
            return true;
        }

        public bool EditJobStatus(int jobId, bool isDone)
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
            return true;
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
