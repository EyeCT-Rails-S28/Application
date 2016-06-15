using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;

namespace EyeCT4RailsLogic.Utilities
{
    /// <summary>
    /// Utility class for all section related code.
    /// </summary>
    public class SectionUtil
    {
        /// <summary>
        /// Gets a free section from a given depot.
        /// </summary>
        /// <param name="depot">The depot in question.</param>
        /// <param name="type">The type of tram.</param>
        /// <returns>The first free section it finds.</returns>
        public static Section GetFreeSection(Depot depot, TramType type)
        {
            var tracks = depot.Tracks;

            switch (type)
            {
                case TramType.DCombino:
                case TramType.Trainer:
                    var track57 = tracks.Find(t => t.Id == 57);
                    if (track57 != null)
                    {
                        tracks.Remove(track57);
                        tracks.Add(track57);
                    }
                    break;
            }

            var track40 = tracks.Find(t => t.Id == 40);
            if (track40 != null)
            {
                tracks.Remove(track40);
                tracks.Add(track40);
            }

            var track58 = tracks.Find(t => t.Id == 58);
            if (track58 != null)
            {
                tracks.Remove(track58);
                tracks.Add(track58);
            }

            foreach (Section ret in tracks.Select(GetFreeSection).Where(ret => ret != null))
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
        private static Section GetFreeSection(Track track)
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
        /// Checks whether a section is accessible from the outside.
        /// </summary>
        /// <param name="section">The section to check for.</param>
        /// <returns>A bool that is true, if and only if it can reach the outside.</returns>
        public static bool CheckSectionFreedom(Section section) => CheckSectionFreedom(section.PreviousSection, false) || CheckSectionFreedom(section.NextSection, true);

        /// <summary>
        /// Checks whether a section is accessible from the outside.
        /// </summary>
        /// <param name="section">The section to check for.</param>
        /// <param name="direction">The direction in which to look. True is next.</param>
        /// <returns>A bool that is true, if and only if it can reach the outside.</returns>
        private static bool CheckSectionFreedom(Section section, bool direction)
        {
            if (section == null)
                return true;
            if (section.Blocked || section.Tram != null)
                return false;
            if (section.NextSection == null || section.PreviousSection == null)
                return true;
            return direction
                ? CheckSectionFreedom(section.NextSection, true)
                : CheckSectionFreedom(section.PreviousSection, false);
        }

        /// <summary>
        /// Checks whether blocking the given section, either by placing a tram or blocking the section, will result in errors.
        /// </summary>
        /// <param name="section">The section in question.</param>
        /// <param name="track">The track the section belongs to.</param>
        /// <returns>A bool that is true when there will be no errors, false when there will be errors.</returns>
        public static bool CheckSectionBlocking(Section section, Track track)
        {
            section.Blocked = true;

            List<Section> sectionsWithTrams =
                track.Sections.FindAll(s => s.Tram != null && s.Tram.Status == Status.Dienst);

            if (sectionsWithTrams.Any(s => !CheckSectionFreedom(s)))
            {
                section.Blocked = false;
                return false;
            }

            section.Blocked = false;
            return true;
        }

        private SectionUtil() {}
    }
}
