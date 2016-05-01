using System;
using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IMaintenanceContext
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
        /// <param name="tramId">The to view the history from.</param>
        /// <returns>A list of maintenance jobs which have been finished</returns>
        List<MaintenanceJob> GetHistory(int tramId);

        /// <summary>
        /// Gets a list of all maintenance jobs which have been finished.
        /// </summary>
        /// <returns>A list of all finished maintenance jobs.</returns>
        List<MaintenanceJob> GetHistory();

        /// <summary>
        /// Adds a maintenance job.
        /// </summary>
        /// <param name="size">The type of maintenance which should be done.</param>
        /// <param name="userId">The user who will be performing the job.</param>
        /// <param name="tramId">The tram which the job will be done for.</param>
        /// <param name="date">The time when the job will start.</param>
        /// <returns>true if, and only if, this job was succesfully added.</returns>
        void ScheduleJob(JobSize size, int userId, int tramId, DateTime date);

        /// <summary>
        /// Removes a recurring job.
        /// </summary>
        /// <param name="jobId">The job to be removed from the schedule.</param>
        /// <returns>true if, and only if, this job was succesfully removed.</returns>
        void RemoveScheduledJob(int jobId);

        /// <summary>
        /// Edits the status of job.
        /// </summary>
        /// <param name="jobId">The job to be edited.</param>
        /// <param name="isDone">Whether the job is finished or not. True should imply that the job is finished.</param>
        /// <returns>true if, and only if, the job was succesfully edited.</returns>
        void EditJobStatus(int jobId, bool isDone);

        /// <summary>
        /// Checks whether there's a free spot for a maintenance job to be done on a specific date.
        /// </summary>
        /// <param name="date">The date when the job should be added.</param>
        /// <param name="size">The size of the job to be performed.</param>
        /// <returns>true if, and only if, a maintenance job can be added on the specified date.</returns>
        bool CheckJobLimit(DateTime date, JobSize size);
    }
}
