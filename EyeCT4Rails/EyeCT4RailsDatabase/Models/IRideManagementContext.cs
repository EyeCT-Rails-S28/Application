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
        void ReportStatusChange(Tram tram, Status status);

        Section GetFreeSection(Track track);
    }
}
