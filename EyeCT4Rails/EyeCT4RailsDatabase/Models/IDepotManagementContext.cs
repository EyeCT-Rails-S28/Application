using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IDepotManagementContext
    {
        /// <summary>
        /// Changes the status of a tram to the given status.
        /// </summary>
        /// <param name="tramId">The tram in question.</param>
        /// <param name="status">The new status of the tram.</param>
        void ChangeTramStatus(int tramId, Status status);

        /// <summary>
        /// Sets the blocked state of a track. Changes all the sections of a track to this state.
        /// </summary>
        /// <param name="trackId">The track in question.</param>
        /// <param name="blocked"></param>
        void SetTrackBlocked(int trackId, bool blocked);

        /// <summary>
        /// Sets the blocked state of a section.
        /// </summary>
        /// <param name="sectionId">The section in question.</param>
        /// <param name="blocked">The state of it's blockedness</param>
        void SetSectionBlocked(int sectionId, bool blocked);

        /// <summary>
        /// Reserves a section for a tram.
        /// </summary>
        /// <param name="tramId">Tram that is involved in the reservation.</param>
        /// <param name="sectionId">Section that is being reserved.</param>
        void ReserveSection(int tramId, int sectionId);

        /// <summary>
        /// Removes a tram on a section.
        /// </summary>
        /// <param name="sectionId">The section id to remove the tram from.</param>
        void RemoveTram(int sectionId);

        /// <summary>
        /// Gets a list of all current trams in the system.
        /// </summary>
        /// <returns>A list of all trams.</returns>
        List<Tram> GetAllTrams();

        /// <summary>
        /// Gets the information of the depot.
        /// </summary>
        /// <param name="name">Name of the depot.</param>
        /// <returns>The depot object.</returns>
        Depot GetDepot(string name);

        /// <summary>
        /// Gets all the trams that need manual assistance from the depot manager.
        /// </summary>
        /// <returns>A list of tram that need manual assistance.</returns>
        List<Tram> GetTramsWithReservedFlag();
    }
}
