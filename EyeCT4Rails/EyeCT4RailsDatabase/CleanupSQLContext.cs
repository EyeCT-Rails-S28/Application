using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsDatabase
{
    public class CleanupSqlContext : ICleanupContext
    {
        public List<Tram> GetDiryTrams()
        {
            List<Tram> list = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT id, tramtype, line_id, forced FROM \"tram\" WHERE status = 'Schoonmaak'", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
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

        public List<Cleanup> GetSchedule()
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id, u.name, u.email, u.role " +
                                                      "FROM \"job\" j " +
                                                      "JOIN \"tram\" t ON t.id = j.tram_id " +
                                                      "JOIN \"line\" l ON t.line_id = l.id " +
                                                      "JOIN \"user\" u ON u.id = j.user_id " +
                                                      "WHERE j.finished = 0 AND j.job_type = 'Cleanup'", connection);
            command.CommandType = CommandType.Text;


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                JobSize size = (JobSize) Enum.Parse(typeof (JobSize), reader.GetString(2));

                int tramId = reader.GetInt32(3);
                TramType type = (TramType)Enum.Parse(typeof(TramType), reader.GetString(4));
                Status status = (Status)Enum.Parse(typeof(Status), reader.GetString(5));
                Line line = new Line(reader.GetInt32(6));
                bool forced = reader.GetByte(7) == 1;

                Tram tram = new Tram(tramId, type, status, line, forced);

                int userId = reader.GetInt32(7);
                string name = reader.GetString(8);
                string email = reader.GetString(9);
                Role privilege = (Role) Enum.Parse(typeof (Role), reader.GetString(10));

                User user = new User(userId, name, email, privilege);

                list.Add(new Cleanup(id, date, false, size, tram, user));
            }

            return list;
        }

        public List<Cleanup> GetHistory(int tramId)
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT j.id, j.\"date\", j.job_size, u.id, u.name, u.email, u.role, t.tramtype, t.status, t.line_id, t.forced " +
                                                      "FROM \"job\" j " +
                                                      "JOIN \"tram\" t ON t.id = j.tram_id " +
                                                      "JOIN \"line\" l ON t.line_id = l.id " +
                                                      "JOIN \"user\" u ON u.id = j.user_id " +
                                                      "WHERE j.finished = 0 AND t.id = :id AND j.job_type = 'Cleanup'", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":id", tramId));

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                JobSize size = (JobSize)Enum.Parse(typeof(JobSize), reader.GetString(2));

                int userId = reader.GetInt32(3);
                string name = reader.GetString(4);
                string email = reader.GetString(5);
                Role privilege = (Role)Enum.Parse(typeof(Role), reader.GetString(6));

                User user = new User(userId, name, email, privilege);

                TramType type = (TramType)Enum.Parse(typeof(TramType), reader.GetString(7));
                Status status = (Status) Enum.Parse(typeof(Status), reader.GetString(8));
                Tram tram = new Tram(tramId, type, status, new Line(reader.GetInt32(9)), reader.GetInt32(10) == 1);

                list.Add(new Cleanup(id, date, false, size, tram, user));
            }

            return list;
        }

        public List<Cleanup> GetHistory()
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT j.id, j.\"date\", j.job_size, t.id, t.tramtype, t.status, l.id, t.forced, u.id, u.name, u.email, u.role " +
                                                      "FROM\"job\" j " +
                                                      "JOIN \"tram\" t ON t.id = j.tram_id " +
                                                      "JOIN \"line\" l ON t.line_id = l.id " +
                                                      "JOIN \"user\" u ON u.id = j.user_id " +
                                                      "WHERE j.finished = 1 AND j.job_type = 'Cleanup'", connection);
            command.CommandType = CommandType.Text;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                JobSize size = (JobSize)Enum.Parse(typeof(JobSize), reader.GetString(2));

                int tramId = reader.GetInt32(3);
                TramType type = (TramType)Enum.Parse(typeof(TramType), reader.GetString(4));
                Status status = (Status)Enum.Parse(typeof(Status), reader.GetString(5));
                Line line = new Line(reader.GetInt32(6));
                bool forced = reader.GetByte(7) == 1;

                Tram tram = new Tram(tramId, type, status, line, forced);

                int userId = reader.GetInt32(8);
                string name = reader.GetString(9);
                string email = reader.GetString(10);
                Role privilege = (Role)Enum.Parse(typeof(Role), reader.GetString(11));

                User user = new User(userId, name, email, privilege);

                list.Add(new Cleanup(id, date, false, size, tram, user));
            }

            return list;
        }

        public bool ScheduleCleanupJob(JobSize size, int userId, int tramId, DateTime date)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("INSERT INTO \"job\"(user_id, tram_id, job_type, job_size, \"date\") " +
                                                      "VALUES(:user_id, :tram_id, 'Cleanup', :job_size, TO_DATE(:job_date, 'DD/MM/YYYY HH24:MI:SS'))", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":user_id", userId));
            command.Parameters.Add(new OracleParameter(":tram_id", tramId));
            command.Parameters.Add(new OracleParameter(":job_size", Convert.ToString(size)));
            command.Parameters.Add(new OracleParameter(":job_date", date.ToString("dd/MM/yyyy HH:mm:ss")));

            command.ExecuteNonQuery();
            return true;
        }

        public bool RemoveScheduledJob(int cleanupId)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("DELETE FROM \"job\" WHERE(id = :id)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":id", cleanupId));

            command.ExecuteNonQuery();
            return true;
        }

        public bool EditJobStatus(int cleanupId, bool isDone)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("UPDATE \"job\" " +
                                                      "SET finished = :job_finished " +
                                                      "WHERE id = :cleanup_id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new OracleParameter(":job_finished", OracleDbType.Int32)).Value = (isDone) ? 1 : 0;
            command.Parameters.Add(new OracleParameter(":cleanup_id", OracleDbType.Int32)).Value = cleanupId;

            command.ExecuteNonQuery();
            return true;
        }

        public bool CheckJobLimit(DateTime date, JobSize size)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("SELECT COUNT(j.id) FROM \"job\" j " +
                                                      "WHERE TRUNC(j.\"date\") = TO_DATE(:job_date, 'DD/MM/YYYY') AND j.job_size = :job_size AND j.job_type = 'Cleanup'", connection);
            command.CommandType = CommandType.Text;
            
            command.Parameters.Add(new OracleParameter(":job_date", date.ToString("dd/MM/yyyy")));
            command.Parameters.Add(new OracleParameter(":job_size", Convert.ToString(size)));

            int amount = Convert.ToInt32(command.ExecuteScalar());
            return size == JobSize.Big ? amount < 2 : amount < 3;
        }
    }
}
