using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IRideManagementContext
    {
        /// <summary>
        /// Changes the status of a tram, for example if it needs cleaning or maintenance.
        /// </summary>
        /// <param name="tramId">The tram to change the status of/</param>
        /// <param name="status">The new status of a tram.</param>
        void ReportStatusChange(int tramId, Status status);
    }
}
