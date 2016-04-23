using System;
using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
// ReSharper disable MemberCanBeMadeStatic.Local

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

        /// <summary>
        /// The instance of the singleton RideManagementRepository.
        /// </summary>
        public static RideManagementRepository Instance => _instance ?? (_instance = new RideManagementRepository());

        /// <summary>
        /// Changes the status of a tram. Dangerous code!
        /// </summary>
        /// <param name="tram">The tram to change the status of/</param>
        /// <param name="status">The new status of a tram.</param>
        public void ChangeTramStatus(Tram tram, Status status)
        {
            try
            {
                _context.ReportStatusChange(tram, status);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets a free section from a given depot.
        /// </summary>
        /// <param name="depot">The depot in question.</param>
        /// <returns>The first free section it finds.</returns>
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
            //Fetches all sections that have access to the outside world.
            List<Section> freeSections =
                track.Sections.Where(
                    section => CheckSectionFreedom(section, false) || CheckSectionFreedom(section, true)).ToList();

            if (freeSections.Count == 0)
                return null;

            //Tries to get a section next to an already blocked/taken section.
            var ret =
                freeSections.Find(x => (x.NextSection != null && (x.NextSection.Blocked || x.NextSection.Tram != null))
                                       ||
                                       (x.PreviousSection != null &&
                                        (x.PreviousSection.Blocked || x.PreviousSection.Tram != null)));

            //If the whole track is empty, i.e. ret is null then it will place the tram on the last section of the track.
            return ret ?? freeSections.Last();
        }

        /// <summary>
        /// Checks wheter a section is accessible from the outside.
        /// </summary>
        /// <param name="section">The section to check for.</param>
        /// <param name="direction">The direction in which to look.</param>
        /// <returns>A bool that is true, if and only if it can reach the outside.</returns>
        private bool CheckSectionFreedom(Section section, bool direction)
        {
            if (section.Blocked || section.Tram != null)
                return false;
            if (section.NextSection == null || section.PreviousSection == null)
                return true;
            return direction
                ? CheckSectionFreedom(section.NextSection, true)
                : CheckSectionFreedom(section.PreviousSection, false);
        }
    }
}