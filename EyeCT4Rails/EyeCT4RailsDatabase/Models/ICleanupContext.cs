using System;
using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    interface ICleanupContext
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
        /// <param name="tram">The tram to get all previously finished cleanups from.</param>
        /// <returns>A list of cleanups which have already been finished in the past, for one specific tram.</returns>
        List<Cleanup> GetHistory(Tram tram);

        /// <summary>
        /// Gets a list of cleanups which have been finished.
        /// </summary>
        /// <returns>A list of all cleanups which have already been finished in the past.</returns>
        List<Cleanup> GetHistory();

        /// <summary>
        /// Adds a clean up job.
        /// </summary>
        /// <param name="size">The size of the job.</param>
        /// <param name="user">The user who will be performing the job.</param>
        /// <param name="tram">The tram the job will be performed on.</param>
        /// <param name="date">The date the job will be performed on.</param>
        /// <returns>True if, and only if, this job was succesfully added.</returns>
        bool AddCleanupJob(JobSize size, User user, Tram tram, DateTime date);

        /// <summary>
        /// Removes a clean up job.
        /// </summary>
        /// <param name="cleanup">The job to be removed.</param>
        /// <returns>True if, and only if, this job was succesfully removed.</returns>
        bool RemoveScheduledJob(Cleanup cleanup);

        /// <summary>
        /// Adds a recurring cleanup job, it will repeat itself in the future.
        /// </summary>
        /// <param name="size">The size of the job.</param>
        /// <param name="user">The user who will be performing the job.</param>
        /// <param name="tram">The tram the job will be performed on.</param>
        /// <param name="date">The first date the job will be performed on.</param>
        /// <param name="interval">The interval at which future jobs will take place.</param>
        /// <param name="endDate">The date when the job should end.</param>
        /// <returns>True if, and only if, all jobs were scheduled correctly.</returns>
        bool ScheduleRecurringJob(JobSize size, User user, Tram tram, DateTime date, DateTime interval, DateTime endDate);

        /// <summary>
        /// Edits a status of a job.
        /// </summary>
        /// <param name="cleanup">The cleanup to edit.</param>
        /// <param name="isDone">Whether the job is finished or not, true for finished.</param>
        /// <returns>True if, and only if, this job status was succesfully edited.</returns>
        bool EditJobStatus(Cleanup cleanup, bool isDone);

        /// <summary>
        /// Checks whether or not a cleanup job can be done on this day.
        /// </summary>
        /// <param name="cleanup">The cleanup to check.</param>
        /// <returns>True if, and only if, the specified cleanup can be performed on this day.</returns>
        bool CheckJobLimit(Cleanup cleanup);
    }
}
