using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsLogic.Utilities
{
    /// <summary>
    /// Utility class for all translation code.
    /// </summary>
    public class TranslationUtil
    {
        /// <summary>
        /// Translates a jobType enum to Dutch.
        /// </summary>
        /// <param name="jobType">The jobType.</param>
        /// <returns>A Dutch string.</returns>
        public static string TranslateJobType(JobType jobType)
        {
            Dictionary<JobType, string> translation = new Dictionary<JobType, string>
            {
                {JobType.Cleanup, "Schoonmaak"},
                {JobType.Maintenance, "Reparatie"}
            };

            return translation[jobType];
        }

        /// <summary>
        /// Translates a jobSize enum to a Dutch string.
        /// </summary>
        /// <param name="jobSize">The jobsize that should be translated.</param>
        /// <returns>A Dutch string.</returns>
        public static string TranslateJobSize(JobSize jobSize)
        {
            Dictionary<JobSize, string> translation = new Dictionary<JobSize, string>
            {
                {JobSize.Small, "Klein"},
                {JobSize.Big, "Groot" }
            };

            return translation[jobSize];
        }

        private TranslationUtil()
        {
            
        }
    }
}