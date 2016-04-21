using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase
{
    public class DepotManagementSqlContext : IDepotManagementContext
    {
        public void ChangeTramStatus(Tram tram, Status status)
        {
            throw new NotImplementedException();
        }

        public void SetTrackBlocked(Track track, bool blocked)
        {
            throw new NotImplementedException();
        }

        public void SetSectionBlocked(Section section, bool blocked)
        {
            throw new NotImplementedException();
        }

        public void ReserveSection(Tram tram, Section section)
        {
            throw new NotImplementedException();
        }

        public Depot GetDepot(string name)
        {
            throw new NotImplementedException();
        }
    }
}
