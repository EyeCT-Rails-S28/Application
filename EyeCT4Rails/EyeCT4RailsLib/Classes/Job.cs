using System;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLib.Classes
{
    public class Job
    {
        /// <summary>
        /// The id of the cleanup in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The date of the job.
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Bool dictating wheter the job is done.
        /// </summary>
        public bool IsDone { get; }
        /// <summary>
        /// The size of the job.
        /// </summary>
        public JobSize JobSize { get; }
        /// <summary>
        /// The type of job.
        /// </summary>
        public JobType JobType { get; }
        /// <summary>
        /// The tram that is involved in the job.
        /// </summary>
        public Tram Tram { get; }
        /// <summary>
        /// The user that is associated with the job.
        /// </summary>
        public User User { get;}

        /// <summary>
        /// Creates a job.
        /// </summary>
        /// <param name="id">The id of the job.</param>
        /// <param name="date">Date of the job.</param>
        /// <param name="isDone">Bool dictating wheter the job is done.</param>
        /// <param name="jobType">The type of job.</param>
        /// <param name="jobSize">The size of the job.</param>
        /// <param name="tram">The tram that is involved in the job.</param>
        /// <param name="user">The user that performed the job.</param>
        public Job(int id, DateTime date, bool isDone, JobType jobType, JobSize jobSize, Tram tram, User user)
        {
            Id = id;
            Date = date;
            IsDone = isDone;
            JobType = jobType;
            JobSize = jobSize;
            Tram = tram;
            User = user;
        }

        /// <summary>
        /// ToString method of the job class.
        /// </summary>
        /// <returns>Returns in a string in the format: 'MT: 11-06-2016 - Done - Size: Big - Tram: 2001 - User: Henk'</returns>
        public override string ToString()
        {
            string job = GetType().Name == "Cleanup" ? "CL" : "MT";
            string done = IsDone ? "Done" : "Not Done";
            string tram = "None";
            string user = "None";

            if (Tram != null)
                tram = Tram.Id.ToString();
            if (User != null)
                user = User.Name;

            return $"{job}: {Date} - {done} - Size: {JobSize} - Tram: {tram} - User: {user}";
        }
    }
}
