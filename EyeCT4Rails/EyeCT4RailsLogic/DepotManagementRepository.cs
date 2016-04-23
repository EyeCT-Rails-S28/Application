using System;
using EyeCT4RailsDatabase;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;

namespace EyeCT4RailsLogic
{
    public class DepotManagementRepository
    {
        private static DepotManagementRepository _instance;
        private readonly IDepotManagementContext _context;

        private DepotManagementRepository()
        {
            _context = new DepotManagementSqlContext();
        }

        /// <summary>
        /// The instance of the singleton DepotManagementRepository.
        /// </summary>
        public static DepotManagementRepository Instance => _instance ?? (_instance = new DepotManagementRepository());

        /// <summary>
        /// Sets the blocked state of a track. Changes all the sections of a track to this state. Dangerous code!
        /// </summary>
        /// <param name="track">The track in question.</param>
        /// <param name="blocked">The blocked state of the track.</param>
        public void SetTrackBlocked(Track track, bool blocked)
        {
            try
            {
               _context.SetTrackBlocked(track, blocked);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Sets the blocked state of a section. Dangerous code!
        /// </summary>
        /// <param name="section">The section in question.</param>
        /// <param name="blocked">The blocked state of the section.</param>
        public void SetSectionBlocked(Section section, bool blocked)
        {
            try
            {
                _context.SetSectionBlocked(section, blocked);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Changes the status of a tram to the given status. Dangerous code!
        /// </summary>
        /// <param name="tram">The tram in question.</param>
        /// <param name="status">The new status of the tram.</param>
        public void ChangeTramStatus(Tram tram, Status status)
        {
            try
            {
                _context.ChangeTramStatus(tram, status);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Reserves a section for a tram. Dangerous code!
        /// </summary>
        /// <param name="tram">Tram that is involved in the reservation.</param>
        /// <param name="section">Section that is being reserved.</param>
        public void ReserveSection(Tram tram, Section section)
        {
            try
            {
                _context.ReserveSection(tram, section);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets the information of the depot. Dangerous code!
        /// </summary>
        /// <param name="name">Name of the depot.</param>
        /// <returns>The depot object.</returns>
        public Depot GetDepot(string name)
        {
            try
            {
                return _context.GetDepot(name);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }
    }
}
