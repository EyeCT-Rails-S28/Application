using System;
using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface ICleanupContext
    {
        /// <summary>
        /// Gets a list of all trams which should be cleaned.
        /// </summary>
        /// <returns>A list of trams which are ready for cleanup.</returns>
        List<Tram> GetDiryTrams();

        /// <summary>
        /// Gets a list of all cleanups which have not yet been finished.
        /// </summary>
        /// <returns>A list of cleanups which still need to be finished.</returns>
        List<Cleanup> GetSchedule();

        /// <summary>
        /// Gets a list of cleanups which have been finished, for one specific tram.
        /// </summary>
        /// <param name="tramId">The tram to get all previously finished cleanups from.</param>
        /// <returns>A list of cleanups which have already been finished in the past, for one specific tram.</returns>
        List<Cleanup> GetHistory(int tramId);

        /// <summary>
        /// Gets a list of cleanups which have been finished.
        /// </summary>
        /// <returns>A list of all cleanups which have already been finished in the past.</returns>
        List<Cleanup> GetHistory();

        /// <summary>
        /// Adds a clean up job.
        /// </summary>
        /// <param name="size">The size of the job.</param>
        /// <param name="userId">The user who will be performing the job.</param>
        /// <param name="tramId">The tram the job will be performed on.</param>
        /// <param name="date">The date the job will be performed on.</param>
        /// <returns>True if, and only if, this job was succesfully added.</returns>
        bool ScheduleCleanupJob(JobSize size, int userId, int tramId, DateTime date);

        /// <summary>
        /// Removes a clean up job.
        /// </summary>
        /// <param name="cleanupId">The job to be removed.</param>
        /// <returns>True if, and only if, this job was succesfully removed.</returns>
        bool RemoveScheduledJob(int cleanupId);

        /// <summary>
        /// Edits a status of a job.
        /// </summary>
        /// <param name="cleanupId">The cleanup to edit.</param>
        /// <param name="isDone">Whether the job is finished or not, true for finished.</param>
        /// <returns>True if, and only if, this job status was succesfully edited.</returns>
        bool EditJobStatus(int cleanupId, bool isDone);

        /// <summary>
        /// Checks whether or not a cleanup job can be done on this day.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="size">The size of the job to be performed.</param>
        /// <returns>True if, and only if, the specified cleanup can be performed on this day.</returns>
        bool CheckJobLimit(DateTime date, JobSize size);
    }
}
