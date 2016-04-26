using System;
using System.Collections.Generic;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
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

        /// <summary>
        /// Instance of the singleton CleanupRepository.
        /// </summary>
        public static CleanupRepository Instance => _instance ?? (_instance = new CleanupRepository());

        /// <summary>
        /// Gets all tram that currently have the dirty status. Dangerous code!
        /// </summary>
        /// <returns>A list of tram that have the dirty status.</returns>
        public List<Tram> GetDirtyTrams()
        {
            try
            {
                return _context.GetDiryTrams();
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets all cleanups that are scheduled for the future. Dangerous code!
        /// </summary>
        /// <returns>A list of cleanups that are scheduled for the future.</returns>
        public List<Cleanup> GetSchedule()
        {
            try
            {
                return _context.GetSchedule();
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets the history of all cleanups done. Dangerous code!
        /// </summary>
        /// <returns>A list of cleanups that have been done.</returns>
        public List<Cleanup> GetHistory()
        {
            try
            {
                return _context.GetHistory();
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets the history of all cleanups done for a specific tram. Dangerous code!
        /// </summary>
        /// <param name="tram">The tram in question.</param>
        /// <returns>A list of cleanups that have been done.</returns>
        public List<Cleanup> GetHistory(int tramId)
        {
            try
            {
                return _context.GetHistory(tramId);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Removes a job from the schedule. Dangerous code!
        /// </summary>
        /// <param name="cleanupId">The scheduled cleanup that should be removed.</param>
        /// <returns>A bool indicating wheter it was successfully removed.</returns>
        public bool RemoveScheduledJob(int cleanupId)
        {
            try
            {
                return _context.RemoveScheduledJob(cleanupId);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Schedules a new job. Dangerous code!
        /// </summary>
        /// <param name="size">Size of the job.</param>
        /// <param name="userId">The user involved in the job.</param>
        /// <param name="tramId">Tram involved in the job.</param>
        /// <param name="date">Date of the job.</param>
        /// <returns>A bool that is true, if and only if, the job was successfully scheduled.</returns>
        public bool ScheduleJob(JobSize size, int userId, int tramId, DateTime date)
        {
            try
            {
                if (_context.CheckJobLimit(date, size))
                {
                    _context.ScheduleCleanupJob(size, userId, tramId, date);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Schedules a job for till a certain day with a given interval. Schedules everything it can. Dangerous code!
        /// </summary>
        /// <param name="size">Size of the job.</param>
        /// <param name="userId">User involved in the job.</param>
        /// <param name="tramId">Tram involved in the job.</param>
        /// <param name="date">Date of the job.</param>
        /// <param name="interval">Interval between schedules.</param>
        /// <param name="endDate">The end date of the recurring schedule.</param>
        /// <returns>A bool that is true, if and only if, all jobs were scheduled.</returns>
        public bool ScheduleRecurringJob(JobSize size, int userId, int tramId, DateTime date, int interval,
            DateTime endDate)
        {
            LogicExceptionHandler.CheckForInvalidDateException(date, endDate, interval);

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
                if (!ScheduleJob(size, userId, tramId, x))
                    success = false;
            }

            //Only return true if every job could be scheduled.
            return success;
        }

        /// <summary>
        /// Edits the status of a job to the given status. Dangerous code!
        /// </summary>
        /// <param name="cleanupId">The job in question.</param>
        /// <param name="isDone">The new status of the job.</param>
        /// <returns>A bool that is true, if and only if, the status was successfully changed.</returns>
        public bool EditJobStatus(int cleanupId, bool isDone)
        {
            try
            {
                return _context.EditJobStatus(cleanupId, isDone);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }
    }
}