using System;
using EyeCT4RailsDatabase.Models;
using EyeCT4RailsDatabase.SQLContexts;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using static EyeCT4RailsLogic.Utilities.ExceptionHandler;
using static EyeCT4RailsLogic.Utilities.SectionUtil;

// ReSharper disable MemberCanBeMadeStatic.Local

namespace EyeCT4RailsLogic.Repositories
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
        /// Gets a section for the given tram.
        /// </summary>
        /// <param name="tramId">The id of the tram.</param>
        /// <param name="status">The status of the tram.</param>
        /// <returns>A string with the section id and the track id seperated by a comma.</returns>
        public string GetSection(int tramId, string status)
        {
            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                if (tramId < 0)
                    throw new InvalidIdException("Tram ID mag niet leeg zijn.");

                if (!depot.Trams.Exists(t => t.Id == tramId))
                    throw new InvalidIdException($"Tram met ID: {tramId} bestaat niet.");

                Track track = depot.Tracks.Find(t => t.Sections.Exists(s => s.Tram?.Id == tramId));
                Section section;

                //Tram is already reserved for a certain section.
                if (track != null)
                {
                    section = track.Sections.Find(s => s.Tram?.Id == tramId);

                    switch (status)
                    {
                        case "Maintenance":
                            Instance.ChangeTramStatus(tramId, Status.Defect);
                            break;
                        case "Cleanup":
                            Instance.ChangeTramStatus(tramId, Status.Schoonmaak);
                            break;
                        default:
                            if (section.Tram.Status == Status.Dienst)
                                Instance.ChangeTramStatus(tramId, Status.Remise);
                            break;
                    }
                }
                //If there is no reserved section the driver should wait for instruction.
                else if (status == "Maintenance")
                {
                    Instance.ChangeTramStatus(tramId, Status.Gereserveerd);

                    throw new SpecialActionException("Er is een speciale actie vereist van een beheerder, wacht op instructies.");
                }
                //Else find a new section for the tram.
                else
                {
                    section = GetFreeSection(depot, depot.Trams.Find(t => t.Id == tramId).TramType);
                    track = depot.Tracks.Find(t => t.Sections.Exists(s => s.Id == section.Id));

                    if (track == null)
                        throw new InvalidIdException("Fout bij ophalen van het spoornummer.");

                    DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);
                    Instance.ChangeTramStatus(tramId, status == "None" ? Status.Remise : Status.Schoonmaak);
                }

                return $"{section.Id},{track.Id}";
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                FilterCustomException(e);

                if (e is SpecialActionException)
                    throw;

                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }           
        }

        /// <summary>
        /// Gets an assigned section for the given tram.
        /// </summary>
        /// <param name="tramId">The id of the tram.</param>
        /// <returns>A string with the section id and the track id seperated by a comma.</returns>
        public string GetAssignedSection(int tramId)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Tram tram = depot.Trams.Find(t => t.Id == tramId);

            if (tram == null || tram.Status == Status.Gereserveerd)
                throw new InvalidIdException("Er is nog geen spoor toegewezen.");

            Track track =
                depot.Tracks.Find(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null);
            Section section = track.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId);

            return $"{section.Id},{track.Id}";
        }

        /// <summary>
        /// Changes the status of a tram. Dangerous code!
        /// </summary>
        /// <param name="tramId">The tram to change the status of/</param>
        /// <param name="status">The new status of a tram.</param>
        public void ChangeTramStatus(int tramId, Status status)
        {
            try
            {
                _context.ReportStatusChange(tramId, status);
            }
            catch (Exception e)
            {
                FilterOracleDatabaseException(e);
                throw new UnknownException("FATAL ERROR! EXTERMINATE! EXTERMINATE!");
            }
        }      
    }
}