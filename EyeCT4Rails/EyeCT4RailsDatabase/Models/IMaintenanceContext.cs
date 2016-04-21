using System;
using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    interface IMaintenanceContext
    {
        /// <summary>
        /// Gets all current tram in maintenance.
        /// </summary>
        /// <returns>A list of all tram currently in maintenance, can return an empty list, never null.</returns>
        List<Tram> GetTramsInMaintenance();

        /// <summary>
        /// Gets a list of all maintenance jobs which have not yet been finished.
        /// </summary>
        /// <returns>A list of all maintenance jobs which haven't been finished yet, can return an empty list, never null.</returns>
        List<MaintenanceJob> GetSchedule();

        /// <summary>
        /// Gets a list of all maintenance jobs which have been finished for one specific tram.
        /// </summary>
        /// <param name="tram">The to view the history from.</param>
        /// <returns>A list of maintenance jobs which have been finished</returns>
        List<MaintenanceJob> GetHistory(Tram tram);

        /// <summary>
        /// Gets a list of all maintenance jobs which have been finished.
        /// </summary>
        /// <returns>A list of all finished maintenance jobs.</returns>
        List<MaintenanceJob> GetHistory();

        /// <summary>
        /// Adds a maintenance job.
        /// </summary>
        /// <param name="size">The type of maintenance which should be done.</param>
        /// <param name="user">The user who will be performing the job.</param>
        /// <param name="tram">The tram which the job will be done for.</param>
        /// <param name="date">The time when the job will start.</param>
        /// <returns>true if, and only if, this job was succesfully added.</returns>
        bool ScheduleJob(JobSize size, User user, Tram tram, DateTime date);

        /// <summary>
        /// Removes a recurring job.
        /// </summary>
        /// <param name="job">The job to be removed from the schedule.</param>
        /// <returns>true if, and only if, this job was succesfully removed.</returns>
        bool RemoveScheduledJob(MaintenanceJob job);

        /// <summary>
        /// Adds a recurring maintenance job, it will repeat itself in the future.
        /// </summary>
        /// <param name="size">The type of maintenance which should be done.</param>
        /// <param name="user">The user who will be performing the job.</param>
        /// <param name="tram">The tram which the job will be done for.</param>
        /// <param name="date">The time when the job will start.</param>
        /// <param name="interval">The interval at which the job will be repeating itself.</param>
        /// <param name="endDate">The time when the job will end repeating itself.</param>
        /// <returns>true if, and only if, all scheduled jobs were succesfully added.</returns>
        bool ScheduleRecurringJob(JobSize size, User user, Tram tram, DateTime date, DateTime interval, DateTime endDate);

        /// <summary>
        /// Edits the status of job.
        /// </summary>
        /// <param name="job">The job to be edited.</param>
        /// <param name="isDone">Whether the job is finished or not. True should imply that the job is finished.</param>
        /// <returns>true if, and only if, the job was succesfully edited.</returns>
        bool EditJobStatus(MaintenanceJob job, bool isDone);

        /// <summary>
        /// Checks whether there's a free spot for a maintenance job to be done on a specific date.
        /// <param name="date">The time when the job should be added.</param>
        /// <returns>true if, and only if, a maintenance job can be added on the specified date.</returns>
        bool CheckJobLimit(DateTime date);
    }
}
