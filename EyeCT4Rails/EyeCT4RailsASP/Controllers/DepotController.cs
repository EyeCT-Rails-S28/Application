using System;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EyeCT4RailsLogic;

namespace EyeCT4RailsASP.Controllers
{
    public class DepotController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ReservedTrams = DepotManagementRepository.Instance.GetTramsWithReservedFlag();
            ViewBag.Tracks = DepotManagementRepository.Instance.GetDepot("Havenstraat").Tracks;

            return View();
        }

        [HttpPost]
        public string SetSectionBlocked(int trackId = -1, int sectionId = -1)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Track track = depot.Tracks.Find(t => t.Id == trackId);
            if (track == null)
            {
                return "Track ID niet gevonden.";
            }

            Section section = track.Sections.Find(s => s.Id == sectionId);
            if (section == null)
            {
                return "Section ID niet gevonden.";
            }

            if (!(RideManagementRepository.Instance.CheckSectionFreedom(section, false) ||
                  RideManagementRepository.Instance.CheckSectionFreedom(section, true)) && section.Tram != null)
            {
                return "Deze sectie kan niet geblokkeerd worden!";
            }

            DepotManagementRepository.Instance.SetSectionBlocked(sectionId, !section.Blocked);
            return "success";
        }

        [HttpPost]
        public string SetTrackBlocked(int trackId = -1)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            bool allFree = depot.Tracks.Find(t => t.Id == trackId).Sections.TrueForAll(s => s.Tram == null);
            if (!allFree)
            {
                return "Een of meerdere secties binnen deze track kunnen niet geblokkeerd worden.";
            }

            bool allBlocked = depot.Tracks.Find(t => t.Id == trackId).Sections.TrueForAll(s => s.Blocked);
            DepotManagementRepository.Instance.SetTrackBlocked(trackId, !allBlocked);

            return "success";
        }

        [HttpPost]
        public string AddTram(int trackId = -1, int sectionId = -1, int tramId = -1, bool reserved = false)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Track track = depot.Tracks.Find(t => t.Id == trackId);
            if (track == null)
            {
                return "Track ID niet gevonden.";
            }

            Section section = track.Sections.Find(s => s.Id == sectionId);
            if (section == null)
            {
                return "Section ID niet gevonden.";
            }

            if (section.Tram != null)
            {
                return "Deze sectie bevat al een tram.";
            }

            if (!(RideManagementRepository.Instance.CheckSectionFreedom(section, false) ||
                    RideManagementRepository.Instance.CheckSectionFreedom(section, true)))
            {
                return "Op deze sectie kan geen tram geplaatst worden.";
            }

            if (depot.Tracks.Any(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null))
            {
                return $"De tram met nummer {tramId} is al geplaatst.";
            }

            Tram tram = depot.Trams.Find(t => t.Id == tramId);
            if (tram == null)
            {
                return "Tram ID niet gevonden.";
            }

            DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);

            Status status = tram.Status;
            if (tram.Status != Status.Defect && tram.Status != Status.Schoonmaak)
            {
                DepotManagementRepository.Instance.ChangeTramStatus(tramId, status = reserved ? Status.Dienst : Status.Remise);
            }

            return "success:" + status;
        }

        public string RemoveTram(int trackId = -1, int sectionId = -1)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Track track = depot.Tracks.Find(t => t.Id == trackId);
            if (track == null)
            {
                return "Track ID niet gevonden.";
            }

            Section section = track.Sections.Find(s => s.Id == sectionId);
            if (section == null)
            {
                return "Section ID niet gevonden.";
            }

            if (section.Tram == null)
            {
                return "Op deze sectie staat geen tram.";
            }

            if (!(RideManagementRepository.Instance.CheckSectionFreedom(section.NextSection, true) ||
                          RideManagementRepository.Instance.CheckSectionFreedom(section.PreviousSection, false)))
            {
                return "Deze tram kan niet verwijderd worden.";
            }

            DepotManagementRepository.Instance.RemoveTram(section.Id);
            return "success";
        }

        public string ChangeStatus(int tramId = -1, string status = null)
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
            Tram tram = depot.Trams.Find(t => t.Id == tramId);
            if (tram == null)
            {
                return "Tram ID niet gevonden.";
            }

            Status _status;

            try
            {
                _status = (Status) Enum.Parse(typeof (Status), status);
            }
            catch (Exception e)
            {
                return "Status niet gevonden.";
            }

            DepotManagementRepository.Instance.ChangeTramStatus(tram.Id, _status);
            return "success";
        }
    }
}