using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IRideManagementContext
    {
        /// <summary>
        /// Changes the status of a tram, for example if it needs cleaning or maintenance.
        /// </summary>
        /// <param name="tram">The tram to change the status of/</param>
        /// <param name="status">The new status of a tram.</param>
        void ReportStatusChange(Tram tram, Status status);
    }
}
