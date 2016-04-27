using System;
using System.Collections.Generic;
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
        /// <param name="trackId">The track in question.</param>
        /// <param name="blocked">The blocked state of the track.</param>
        public void SetTrackBlocked(int trackId, bool blocked)
        {
            try
            {
               _context.SetTrackBlocked(trackId, blocked);
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
        /// <param name="sectionId">The section in question.</param>
        /// <param name="blocked">The blocked state of the section.</param>
        public void SetSectionBlocked(int sectionId, bool blocked)
        {
            try
            {
                _context.SetSectionBlocked(sectionId, blocked);
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
        /// <param name="tramId">The tram in question.</param>
        /// <param name="status">The new status of the tram.</param>
        public void ChangeTramStatus(int tramId, Status status)
        {
            try
            {
                _context.ChangeTramStatus(tramId, status);
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
        /// <param name="tramId">Tram that is involved in the reservation.</param>
        /// <param name="sectionId">Section that is being reserved.</param>
        public void ReserveSection(int tramId, int sectionId)
        {
            try
            {
                _context.ReserveSection(tramId, sectionId);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Removes a tram from a section. Dangerous code!
        /// </summary>
        /// <param name="sectionId">The id to remove a tram from.</param>
        public void RemoveTram(int sectionId)
        {
            try
            {
                _context.RemoveTram(sectionId);
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Gets all trams in the system. Dangerous code!
        /// </summary>
        /// <returns>A list of all trams.</returns>
        public List<Tram> GetAllTrams()
        {
            try
            {
                return _context.GetAllTrams();
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

        /// <summary>
        /// Gets all trams that currently have the status Reserved.
        /// </summary>
        /// <returns>A list of all the trams with the status Reserved.</returns>
        public List<Tram> GetTramsWithReservedFlag()
        {
            try
            {
                return _context.GetTramsWithReservedFlag();
            }
            catch (Exception e)
            {
                LogicExceptionHandler.FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        } 
    }
}
