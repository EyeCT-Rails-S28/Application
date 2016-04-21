using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsDatabase
{
    class CleanupSqlContext : ICleanupContext
    {
        public List<Tram> GetDiryTrams()
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

        public List<Cleanup> GetSchedule()
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public List<Cleanup> GetHistory(Tram tram)
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public List<Cleanup> GetHistory()
        {
            List<Cleanup> list = new List<Cleanup>();

            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //
            }

            return list;
        }

        public bool AddCleanupJob(JobSize size, User user, Tram tram, DateTime date)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool RemoveScheduledJob(Cleanup cleanup)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool ScheduleRecurringJob(Cleanup cleanup, User user, Tram tram, DateTime date, DateTime interval, DateTime endDate)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool EditJobStatus(Cleanup cleanup, bool isDone)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool CheckJobLimit(Cleanup cleanup)
        {
            OracleConnection connection = Database.Instance.Connection;
            OracleCommand command = new OracleCommand("", connection);
            //

            return true;
        }
    }
}
