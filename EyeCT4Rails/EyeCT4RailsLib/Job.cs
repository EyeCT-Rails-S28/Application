using System;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib
{
    public abstract class Job
    {
        /// <summary>
        /// The date of the job.
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Bool dictating wheter the job is done.
        /// </summary>
        public bool IsDone { get; set; }
        /// <summary>
        /// The size of the job.
        /// </summary>
        public JobSize JobSize { get; }
        /// <summary>
        /// The tram that is involved in the job.
        /// </summary>
        public Tram Tram { get; }
        /// <summary>
        /// The user that is associated with the job.
        /// </summary>
        public abstract User User { get; set; }

        /// <summary>
        /// Creates a job.
        /// </summary>
        /// <param name="date">Date of the job.</param>
        /// <param name="isDone">Bool dictating wheter the job is done.</param>
        /// <param name="jobSize">The size of the job.</param>
        /// <param name="tram">The tram that is involved in the job.</param>
        protected Job(DateTime date, bool isDone, JobSize jobSize, Tram tram)
        {
            Date = date;
            IsDone = isDone;
            JobSize = jobSize;
            Tram = tram;
        }

        public override string ToString()
        {
            string job = GetType().Name == "Cleanup" ? "CL" : "MT";
            string done = IsDone ? "Done" : "Not Done";
            string tram = "None";
            string user = "None";

            if (Tram != null)
                tram = Tram.Id.ToString();
            if (User != null)
                user = User?.Name;

            return $"{job}: {Date} - {done} - Size: {JobSize} - Tram: {tram} - User: {user}";
        }
    }
}
