using System;
using System.Collections.Generic;
using System.Data;
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
            List<Tram> list = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("dirty_trams", connection);
            command.CommandType = CommandType.StoredProcedure;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                Status status = Status.Schoonmaak;
                Line line = new Line(reader.GetInt32(2));
                bool forced = reader.GetByte(3) == 1;

                list.Add(new Tram(id, status, line, forced));
            }

            return list;
        }

        public List<MaintenanceJob> GetSchedule()
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("job_schedule", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                JobSize size = (JobSize)Enum.Parse(typeof(JobSize), reader.GetString(2));

                int tramId = reader.GetInt32(3);
                Status status = (Status)Enum.Parse(typeof(Status), reader.GetString(4));
                Line line = new Line(reader.GetInt32(5));
                bool forced = reader.GetByte(6) == 1;

                Tram tram = new Tram(tramId, status, line, forced);

                int userId = reader.GetInt32(7);
                string name = reader.GetString(8);
                string email = reader.GetString(9);
                Role privilege = (Role)Enum.Parse(typeof(Role), reader.GetString(10));

                User user = new User(userId, name, email, privilege);

                list.Add(new MaintenanceJob(id, date, false, size, tram, user));
            }

            return list;
        }

        public List<MaintenanceJob> GetHistory(Tram tram)
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("job_history_tram", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32).Value = tram.Id);
            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");

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

                list.Add(new MaintenanceJob(id, date, false, size, tram, user));
            }

            return list;
        }

        public List<MaintenanceJob> GetHistory()
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("job_history", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                JobSize size = (JobSize)Enum.Parse(typeof(JobSize), reader.GetString(2));

                int tramId = reader.GetInt32(3);
                Status status = (Status)Enum.Parse(typeof(Status), reader.GetString(4));
                Line line = new Line(reader.GetInt32(5));
                bool forced = reader.GetByte(6) == 1;

                Tram tram = new Tram(tramId, status, line, forced);

                int userId = reader.GetInt32(7);
                string name = reader.GetString(8);
                string email = reader.GetString(9);
                Role privilege = (Role)Enum.Parse(typeof(Role), reader.GetString(10));

                User user = new User(userId, name, email, privilege);

                list.Add(new MaintenanceJob(id, date, false, size, tram, user));
            }

            return list;
        }

        public bool ScheduleJob(JobSize size, User user, Tram tram, DateTime date)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("add_job", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_user_id", OracleDbType.Int32).Value = user.Id);
            command.Parameters.Add(new OracleParameter("p_tram_id", OracleDbType.Int32).Value = tram.Id);
            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");
            command.Parameters.Add(new OracleParameter("p_job_size", OracleDbType.Varchar2).Value = Convert.ToString(size));
            command.Parameters.Add(new OracleParameter("p_date", OracleDbType.Date).Value = date);

            command.ExecuteNonQuery();
            return true;
        }

        public bool RemoveScheduledJob(MaintenanceJob job)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("remove_job", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_id", OracleDbType.Int32).Value = job.Id);

            command.ExecuteNonQuery();
            return true;
        }

        public bool EditJobStatus(MaintenanceJob job, bool isDone)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("edit_job_status", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_cleanup_id", OracleDbType.Int32).Value = job.Id);
            command.Parameters.Add(new OracleParameter("p_finished", OracleDbType.Int32).Value = isDone ? 1 : 0);
            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");

            command.ExecuteNonQuery();
            return true;
        }

        public bool CheckJobLimit(DateTime date, JobSize size)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("check_jobs_amount", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new OracleParameter("p_job_type", OracleDbType.Varchar2).Value = "Maintenance");
            command.Parameters.Add(new OracleParameter("p_date", OracleDbType.Date).Value = date);
            command.Parameters.Add(new OracleParameter("p_size", OracleDbType.Varchar2).Value = Convert.ToString(size));

            int amount = Convert.ToInt32(command.ExecuteScalar());
            return size == JobSize.Big ? amount < 1 : amount < 4;
        }
    }
}
