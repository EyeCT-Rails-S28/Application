using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;

namespace EyeCT4RailsDatabase.Models
{
    public interface IDepotManagementContext
    {
        /// <summary>
        /// Changes the status of a tram to the given status.
        /// </summary>
        /// <param name="tram">The tram in question.</param>
        /// <param name="status">The new status of the tram.</param>
        void ChangeTramStatus(Tram tram, Status status);

        /// <summary>
        /// Sets the blocked state of a track. Changes all the sections of a track to this state.
        /// </summary>
        /// <param name="track">The track in question.</param>
        /// <param name="blocked"></param>
        void SetTrackBlocked(Track track, bool blocked);

        /// <summary>
        /// Sets the blocked state of a section.
        /// </summary>
        /// <param name="section">The section in question.</param>
        /// <param name="blocked">The state of it's blockedness</param>
        void SetSectionBlocked(Section section, bool blocked);

        /// <summary>
        /// Reserves a section for a tram.
        /// </summary>
        /// <param name="tram">Tram that is involved in the reservation.</param>
        /// <param name="section">Section that is being reserved.</param>
        void ReserveSection(Tram tram, Section section);
    }
}
