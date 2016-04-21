using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    class MaintenanceSqlContext : IMaintenanceContext
    {
        public List<Tram> GetTramsInMaintenance()
        {
            List<Tram> list = new List<Tram>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public List<MaintenanceJob> GetSchedule()
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public List<MaintenanceJob> GetHistory(Tram tram)
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public List<MaintenanceJob> GetHistory()
        {
            List<MaintenanceJob> list = new List<MaintenanceJob>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public bool ScheduleJob(JobSize size, User user, Tram tram, DateTime date)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool RemoveScheduledJob(MaintenanceJob job)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool ScheduleRecurringJob(JobSize size, User user, Tram tram, DateTime date, DateTime interval, DateTime endDate)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool EditJobStatus(MaintenanceJob job, bool isDone)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool CheckJobLimit(DateTime date)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }
    }
}
