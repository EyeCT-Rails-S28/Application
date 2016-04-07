using System;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib
{
    public class MaintenanceJob : Job
    {
        /// <summary>
        /// The id of the job in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The user that is associated with the job.
        /// </summary>
        public sealed override User User { get; set; }

        /// <summary>
        /// Creates a maintenance job.
        /// </summary>
        /// <param name="id">The id of the job in the database.</param>
        /// <param name="date">The date of the job.</param>
        /// <param name="isDone">Bool depicting wheter the job is done.</param>
        /// <param name="jobSize">The size of the job.</param>
        /// <param name="tram">The tram that is involved with the job.</param>
        /// <param name="user">The user that is associated with the job.</param>
        public MaintenanceJob(int id, DateTime date, bool isDone, JobSize jobSize, Tram tram, User user)
            : base(date, isDone, jobSize, tram)
        {
            Id = id;
            User = user;
        }
    }
}
