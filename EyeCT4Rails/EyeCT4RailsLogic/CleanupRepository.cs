using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
// ReSharper disable UnusedParameter.Local

namespace EyeCT4RailsLogic
{
    public class CleanupRepository
    {
        private static CleanupRepository _instance;
        private readonly ICleanupContext _context;

        private CleanupRepository()
        {
            _context = new CleanupSqlContext();
        }

        public static CleanupRepository Instance => _instance ?? (_instance = new CleanupRepository());

        public List<Tram> GetDirtyTrams()
        {
            try
            {
                return _context.GetDiryTrams();
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public List<Cleanup> GetSchedule()
        {
            try
            {
                return _context.GetSchedule();
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public List<Cleanup> GetHistory()
        {
            try
            {
                return _context.GetHistory();
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public List<Cleanup> GetHistory(Tram tram)
        {
            try
            {
                return _context.GetHistory(tram);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public bool RemoveScheduledJob(Cleanup cleanup)
        {
            try
            {
                return _context.RemoveScheduledJob(cleanup);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public bool ScheduleJob(JobSize size, User user, Tram tram, DateTime date)
        {
            try
            {
                if (_context.CheckJobLimit(date, size))
                {
                    _context.ScheduleCleanupJob(size, user, tram, date);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Schedules a job for till a certain day with a given interval. Schedules everything it can.
        /// </summary>
        /// <param name="size">Size of the job.</param>
        /// <param name="user">User involved in the job.</param>
        /// <param name="tram">Tram involved in the job.</param>
        /// <param name="date">Date of the job.</param>
        /// <param name="interval">Interval between schedules.</param>
        /// <param name="endDate">The end date of the recurring schedule.</param>
        /// <returns>A bool that is true, if and only if, all jobs were scheduled.</returns>
        public bool ScheduleRecurringJob(JobSize size, User user, Tram tram, DateTime date, int interval,
            DateTime endDate)
        {
            CheckException(date, endDate, interval);

            //bool used to determine wheter every job could be scheduled.
            bool success = true;
            //List of all the dates between the start and the end date.
            var dates = new List<DateTime>();
            //Temp date for looping through all dates.
            DateTime tempDate = date;

            while (tempDate.Date <= endDate.Date)
            {
                dates.Add(tempDate);
                tempDate = tempDate.AddDays(interval);
            }

            //Schedule the same job at each date.
            foreach (var x in dates)
            {
                if (!ScheduleJob(size, user, tram, x))
                    success = false;
            }

            //Only return true if every job could be scheduled.
            return success;
        }

        public bool EditJobStatus(Cleanup cleanup, bool isDone)
        {
            try
            {
                return _context.EditJobStatus(cleanup, isDone);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        //public bool EditJobUser(Cleanup cleanup, User user)
        //{

        //}

        private void CheckException(DateTime startDate, DateTime endDate, int interval)
        {
            if (endDate < startDate)
                throw new InvalidDateException("End date is before start date.");

            if (interval < 1)
                throw new InvalidDateException("Interval has to be greater than 1.");
        }

        private void ExceptionCatch(Exception e)
        {
            Console.WriteLine(e.Message);

            if (e.GetType() == typeof (OracleException) || e.GetBaseException() is OracleException)
                throw new DatabaseException("A database error has occured.", e);
        }
    }
}