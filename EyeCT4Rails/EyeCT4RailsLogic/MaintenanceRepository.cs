using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Types;
// ReSharper disable UnusedParameter.Local

namespace EyeCT4RailsLogic
{
    public class MaintenanceRepository
    {
        private static MaintenanceRepository _instance;
        private readonly IMaintenanceContext _context;

        private MaintenanceRepository()
        {
            _context = new MaintenanceSqlContext();
        }

        public static MaintenanceRepository Instance => _instance ?? (_instance = new MaintenanceRepository());

        public List<Tram> GetTramsInMaintenance()
        {
            try
            {
                return _context.GetTramsInMaintenance();
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public List<MaintenanceJob> GetSchedule()
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

        public List<MaintenanceJob> GetHistory()
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

        public List<MaintenanceJob> GetHistory(Tram tram)
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

        public bool RemoveScheduledJob(MaintenanceJob job)
        {
            try
            {
                return _context.RemoveScheduledJob(job);
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
                    _context.ScheduleJob(size, user, tram, date);
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

        public bool EditJobStatus(MaintenanceJob job, bool isDone)
        {
            try
            {
                return _context.EditJobStatus(job, isDone);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        private void CheckException(DateTime startDate, DateTime endDate, int interval)
        {
            if (endDate < startDate)
                throw new InvalidDateException("End date is before start date.");

            if (interval < 1)
                throw new InvalidDateException("Interval has to be greater than 1.");
        }

        private void ExceptionCatch(Exception e)
        {
            Console.WriteLine(e.StackTrace);

            if (e.GetType() == typeof (OracleTypeException) || e.GetBaseException() is OracleTypeException)
                throw new DatabaseException("A database error has occured.");
        }
    }
}
