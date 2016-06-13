using System;
using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsDatabase.SQLContexts;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using static EyeCT4RailsLogic.Utilities.ExceptionHandler;
using static EyeCT4RailsLogic.Utilities.SectionUtil;

namespace EyeCT4RailsLogic.Repositories
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
        public void SetTrackBlocked(int trackId)
        {
            try
            {
                Depot depot = Instance.GetDepot("Havenstraat");

                bool allFree = depot.Tracks.Find(t => t.Id == trackId).Sections.TrueForAll(s => s.Tram == null);

                if (!allFree)
                {
                    throw new InvalidUserOperationException("Een of meerdere secties binnen deze track kunnen niet geblokkeerd worden.");
                }

                //Be true when there is an unblocked section in the track, be false when all the sections are unblocked. 
                bool blocked =
                    depot.Tracks.Exists(
                        x => x.Id == trackId && x.Sections.Exists(s => s.Blocked == false));


                _context.SetTrackBlocked(trackId, blocked);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Sets the blocked state of a section. Dangerous code!
        /// </summary>
        /// <param name="sectionId">The section in question.</param>
        public void SetSectionBlocked(int sectionId)
        {
            try
            {
                Depot depot = Instance.GetDepot("Havenstraat");

                Track track = depot.Tracks.Find(x => x.Sections.Exists(y => y.Id == sectionId));
                Section section = track?.Sections.Find(x => x.Id == sectionId);

                //If the section does not exist, throw an exception.
                if (section == null)        
                    throw new InvalidIdException("Section ID niet gevonden.");

                //If there is a tram on the section, throw an exception.
                if (section.Tram != null)
                    throw new InvalidUserOperationException("Deze sectie kan niet geblokkeerd worden.");

                //If blocking the section causes a tram that has a reserved spot to be blocked, throw an exception.
                if (!section.Blocked)
                {
                    if(!CheckSectionBlocking(section, track))
                        throw new InvalidUserOperationException("Deze sectie kan niet geblokkeerd worden (vrijheid).");
                }

                //Toggle the blocked status of the section.
                _context.SetSectionBlocked(sectionId, !section.Blocked);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Changes the status of a tram to the given status. Dangerous code!
        /// </summary>
        /// <param name="tramId">The tram in question.</param>
        /// <param name="statusStr">The new status of the tram.</param>
        public void ChangeTramStatus(int tramId, string statusStr)
        {
            try
            {
                Depot depot = Instance.GetDepot("Havenstraat");
                Tram tram = depot.Trams.Find(t => t.Id == tramId);

                //If the tram doesn't exist throw an exception.
                if (tram == null)
                    throw new InvalidIdException("Tram ID niet gevonden.");

                Status status;

                try
                {
                    status = (Status) Enum.Parse(typeof (Status), statusStr);
                }
                catch (Exception)
                {
                    throw new InvalidIdException("Status niet gevonden.");
                }

                _context.ChangeTramStatus(tramId, status);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
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
                Depot depot = Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(x => x.Sections.Exists(y => y.Id == sectionId));

                //Get the section in question.
                Section section = track?.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                    throw new InvalidIdException("Sectie ID niet gevonden.");

                //Get the tram in question.
                Tram tram = depot.Trams.Find(t => t.Id == tramId);
                if(tram == null)
                    throw new InvalidIdException("Tram ID niet gevonden.");

                //Check whether this section isn't already occupied.
                if (section.Tram != null)
                    throw new InvalidUserOperationException("Deze sectie bevat al een tram.");

                //Check whether this section can be reached.
                if (!CheckSectionFreedom(section))
                    throw new InvalidUserOperationException("Op deze sectie kan geen tram geplaatst worden.");

                //Check whether the tram isn't already placed.
                if (depot.Tracks.Any(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null))
                    throw new InvalidUserOperationException($"De tram met nummer {tramId} is al geplaatst.");

                if(tram.Status != Status.Dienst)
                    throw new InvalidUserOperationException("Tram moet in dienst zijn om gereserveerd te worden.");

                //Check whether blocking the section will result in inaccessible reservations.
                if (!CheckSectionBlocking(section, track))
                    throw new InvalidUserOperationException("Deze sectie kan niet geblokkeerd worden (vrijheid).");               

                _context.ReserveSection(tramId, sectionId);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Adds a tram to a section.
        /// </summary>
        /// <param name="tramId">The id of the tram in question.</param>
        /// <param name="sectionId">The id of the section the tram should be placed on.</param>
        public void AddTramToSection(int tramId, int sectionId)
        {
            try
            {
                Depot depot = Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(x => x.Sections.Exists(y => y.Id == sectionId));

                //Get the section in question.
                Section section = track?.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                    throw new InvalidIdException("Sectie ID niet gevonden.");

                //Get the tram in question.
                Tram tram = depot.Trams.Find(t => t.Id == tramId);
                if (tram == null)
                    throw new InvalidIdException("Tram ID niet gevonden.");

                //Check whether this section isn't already occupied.
                if (section.Tram != null)
                    throw new InvalidUserOperationException("Deze sectie bevat al een tram.");

                //Check whether this section can be reached.
                if (!CheckSectionFreedom(section))
                    throw new InvalidUserOperationException("Op deze sectie kan geen tram geplaatst worden.");

                //Check whether the tram isn't already placed.
                if (depot.Tracks.Any(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null))
                    throw new InvalidUserOperationException($"De tram met nummer {tramId} is al geplaatst.");

                //Check whether blocking the section will result in inaccessible reservations.
                if (!CheckSectionBlocking(section, track))
                    throw new InvalidUserOperationException("Deze sectie kan niet geblokkeerd worden (vrijheid).");

                //If the tram was 'In dienst' it should now be 'Remise'.
                if (tram.Status == Status.Dienst)
                    _context.ChangeTramStatus(tramId, Status.Remise);

                _context.ReserveSection(tramId, sectionId);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
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
                Depot depot = Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(t => t.Sections.Exists(s => s.Id == sectionId));

                //Get the section in question.
                Section section = track?.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                    throw new InvalidIdException("Sectie ID niet gevonden.");

                //Check whether the section has a tram.
                if (section.Tram == null)
                    throw new InvalidUserOperationException("Op deze sectie staat geen tram." );

                //Check whether this section can be reached.
                if (!CheckSectionFreedom(section))
                    throw new InvalidUserOperationException("Op deze sectie kan geen tram geplaatst worden.");

                //Check whether the tram can be removed.
                if(section.Tram.Status == Status.Defect || section.Tram.Status == Status.Schoonmaak)
                    throw new InvalidUserOperationException("Een tram die schoonmaak of reparatie nodig heeft mag niet verwijderd worden.");

                ChangeTramStatus(section.Tram.Id, Status.Dienst.ToString());
                _context.RemoveTram(sectionId);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }

        /// <summary>
        /// Adds a tram that needs repair to a certain section.
        /// </summary>
        /// <param name="tramId">The id of the tram in question.</param>
        /// <param name="sectionId">The id of the section the tram should be placed upon.</param>
        public void ReserveSectionForRepair(int tramId, int sectionId)
        {
            try
            {
                AddTramToSection(tramId, sectionId);
                ChangeTramStatus(tramId, Status.Defect.ToString());
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);
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
                FilterOracleDatabaseException(e);
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
                FilterOracleDatabaseException(e);
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
                FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        } 

    }
}
