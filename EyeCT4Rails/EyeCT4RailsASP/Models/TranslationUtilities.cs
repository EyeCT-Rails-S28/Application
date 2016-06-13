using System.Collections.Generic;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsASP.Models
{
    public class TranslationUtilities
    {
        public static string TranslateJobType(JobType jobType)
        {
            Dictionary<JobType, string> translation = new Dictionary<JobType, string>
            {
                {JobType.Cleanup, "Schoonmaak"},
                {JobType.Maintenance, "Reparatie"}
            };

            return translation[jobType];
        }

        public static string TranslateJobSize(JobSize jobSize)
        {
            Dictionary<JobSize, string> translation = new Dictionary<JobSize, string>
            {
                {JobSize.Small, "Klein"},
                {JobSize.Big, "Groot" }
            };

            return translation[jobSize];
        }

        private TranslationUtilities()
        {
            
        }
    }
}