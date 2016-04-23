using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Oracle.ManagedDataAccess.Types;

namespace EyeCT4RailsLogic
{
    public class RideManagementRepository
    {
        private static RideManagementRepository _instance;
        private readonly IRideManagementContext _context;

        private RideManagementRepository()
        {
            _context = new RideManagementSqlContext();
        }

        public static RideManagementRepository Instance => _instance ?? (_instance = new RideManagementRepository());

        /// <summary>
        /// Changes the status of a tram.
        /// </summary>
        /// <param name="tram"></param>
        /// <param name="status"></param>
        public void ChangeTramStatus(Tram tram, Status status)
        {      
            try
            {
                _context.ReportStatusChange(tram, status);
            }
            catch (Exception e)
            {
                ExceptionCatch(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        public Section GetFreeSection(Depot depot)
        {
            foreach (Section ret in depot.Tracks.Select(GetFreeSection).Where(ret => ret != null))
            {
                return ret;
            }

            throw new NoFreeSectionException("No section is free");
        }

        /// <summary>
        /// Loops through all sections in a track to get a free section.
        /// </summary>
        /// <param name="track">The track in question.</param>
        /// <returns>A free section.</returns>
        private Section GetFreeSection(Track track)
        {
            bool found = false;
            int sectionCount = 0;
            Section ret = null;

            while (!found)
            {
                if (sectionCount >= track.Sections.Count)
                    return null;

                ret = track.Sections[sectionCount];
                if (CheckSectionFreedom(ret))
                    found = ret != null;
                sectionCount++;
            }

            return ret;
        }

        /// <summary>
        /// Checks wheter a section is accessible from the outside.
        /// </summary>
        /// <param name="section">The section to check for.</param>
        /// <returns>A bool that is true, if and only if it can reach the outside.</returns>
        private bool CheckSectionFreedom(Section section)
        {
            if (section.Blocked || section.Tram != null)
                return false;
            if (section.NextSection == null || section.PreviousSection == null)
                return true;
            return CheckSectionFreedom(section.NextSection) || CheckSectionFreedom(section.PreviousSection);
        }

        private void ExceptionCatch(Exception e)
        {
            Console.WriteLine(e.Message);

            if (e.GetType() == typeof(OracleTypeException) || e.GetBaseException() is OracleTypeException)
                throw new DatabaseException("A database error has occured.", e);
        }
    }
}
