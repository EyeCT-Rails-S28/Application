using System;
using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsDatabase.SQLContexts;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using EyeCT4RailsLogic.Utilities;

// ReSharper disable UnusedParameter.Local

namespace EyeCT4RailsLogic.Repositories
{
    public class MaintenanceRepository
    {
        private static MaintenanceRepository _instance;
        private readonly IMaintenanceContext _context;

        private MaintenanceRepository()
        {
            _context = new MaintenanceSqlContext();
        }

        /// <summary>
        /// The instance of the singleton MaintenanceRepository. 
        /// </summary>
        public static MaintenanceRepository Instance => _instance ?? (_instance = new MaintenanceRepository());

        /// <summary>
        /// Gets all current tram in maintenance. Dangerous code!
        /// </summary>
        /// <returns>A list of all tram currently in maintenance, can return an empty list, never null.</returns>
        public List<Tram> GetTramsInMaintenance()
        {
            try
            {
                return _context.GetTramsInMaintenance();
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets a list of all maintenance jobs which have not yet been finished. Dangerous code!
        /// </summary>
        /// <returns>A list of all maintenance jobs which haven't been finished yet, can return an empty list, never null.</returns>
        public List<Job> GetSchedule()
        {
            try
            {
                return _context.GetSchedule();
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets a list of all maintenance jobs which have been finished. Dangerous code!
        /// </summary> 
        /// <returns>A list of all finished maintenance jobs.</returns>
        public List<Job> GetHistory()
        {
            try
            {
                return _context.GetHistory();
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets a list of all maintenance jobs which have been finished for one specific tram. Dangerous code!
        /// </summary>
        /// <param name="tramId">The to view the history from.</param>
        /// <returns>A list of maintenance jobs which have been finished</returns>
        public List<Job> GetHistory(int tramId)
        {
            try
            {
                return _context.GetHistory(tramId);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Removes a recurring job. Dangerous code!
        /// </summary>
        /// <param name="jobId">The job to be removed from the schedule.</param>
        /// <returns>true if, and only if, this job was succesfully removed.</returns>
        public void RemoveScheduledJob(int jobId)
        {
            try
            {
                _context.RemoveScheduledJob(jobId);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Adds a maintenance job. Dangerous code!
        /// </summary>
        /// <param name="size">The type of maintenance which should be done.</param>
        /// <param name="user">The user who will be performing the job.</param>
        /// <param name="tramId">The tram which the job will be done for.</param>
        /// <param name="date">The time when the job will start.</param>
        /// <param name="mail">Whether a mail should be sent, or not.</param>
        /// <returns>true if, and only if, this job was succesfully added.</returns>
        public bool ScheduleJob(JobSize size, User user, int tramId, DateTime date, bool mail = true)
        {
            try
            {
                if (_context.CheckJobLimit(date, size))
                {
                    _context.ScheduleJob(size, user.Id, tramId, date);


                    if (mail)
                    {
                        MailUtil.SendMail(user.Email, "Er is een nieuwe reparatiebeurt toegewezen.",
                            $"Beste {user.Name},\n" +
                            "\n" +
                            $"Er is een nieuwe reparatiebeurt ingepland.\n" +
                            "Het gaat hier om de volgende beurt:\n" +
                            "\n" +
                            $"Type: {TranslationUtil.TranslateJobSize(size)}\n" +
                            $"Tramnummer: {tramId}\n" +
                            $"Datum: {date.ToShortDateString()}\n" +
                            "\n" +
                            $"Let op, de eerstvolgende reparatiebeurt begint op {date.ToShortDateString()}.\n" +
                            "\n" +
                            "Met vriendelijke groet,\n" +
                            "Systeembeheer");
                    }

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Schedules a job for till a certain day with a given interval. Schedules everything it can.
        /// </summary>
        /// <param name="size">Size of the job.</param>
        /// <param name="user">User involved in the job.</param>
        /// <param name="tramId">Tram involved in the job.</param>
        /// <param name="date">Date of the job.</param>
        /// <param name="interval">Interval between schedules.</param>
        /// <param name="endDate">The end date of the recurring schedule.</param>
        /// <param name="mail">Whether a mail should be sent, or not.</param>
        /// <returns>A bool that is true, if and only if, all jobs were scheduled.</returns>
        public bool ScheduleRecurringJob(JobSize size, User user, int tramId, DateTime date, int interval,
            DateTime endDate, bool mail = true)
        {
            ExceptionHandler.CheckForInvalidDateException(date, endDate, interval);

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
                if (!ScheduleJob(size, user, tramId, x, false))
                    success = false;
            }

            if (mail)
            {
                MailUtil.SendMail(user.Email, "Er zijn nieuwe reparatiebeurten toegewezen.",
                    $"Beste {user.Name},\n" +
                    "\n" +
                    $"Er zijn {dates.Count} nieuwe reparatiebeurten ingepland.\n" +
                    "Het gaat hier om de volgende beurten:\n" +
                    "\n" +
                    $"Type: {TranslationUtil.TranslateJobSize(size)}\n" +
                    $"Tramnummer: {tramId}\n" +
                    $"Aantal beurten: {dates.Count}\n" +
                    $"Interval: {interval}\n" +
                    "\n" +
                    $"Let op, de eerstvolgende reparatiebeurt begint op {dates.First().ToShortDateString()}.\n" +
                    "\n" +
                    "Met vriendelijke groet,\n" +
                    "Systeembeheer");
            }

            //Only return true if every job could be scheduled.
            return success;
        }

        /// <summary>
        /// Edits the status of job. Dangerous code!
        /// </summary>
        /// <param name="jobId">The job to be edited.</param>
        /// <param name="isDone">Whether the job is finished or not. True should imply that the job is finished.</param>
        /// <returns>true if, and only if, the job was succesfully edited.</returns>
        public void EditJobStatus(int jobId, bool isDone)
        {
            try
            {
                _context.EditJobStatus(jobId, isDone);
            }
            catch (Exception e)
            {
                ExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }
    }
}
