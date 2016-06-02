using System;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsASP.Controllers
{
    public class RideManagementController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tramnumber, string assist)
        {
            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                int tramId = Convert.ToInt32(tramnumber);
                Track track = depot.Tracks.Find(t => t.Sections.Find(s => s.Tram?.Id == tramId) != null);
                Section section = null;

                if (string.IsNullOrWhiteSpace(tramnumber))
                {
                    ViewBag.Exception = "Tram ID mag niet leeg zijn.";
                }
                else if (!depot.Trams.Exists(t => t.Id == tramId))
                {
                    ViewBag.Exception = $"Tram met ID: {tramId} bestaat niet.";
                }
                else if (track != null)
                {
                    section = track.Sections.Find(s => s.Tram?.Id == tramId);
                    if (section.Tram.Status == Status.Dienst)
                    {
                        RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Remise);
                    }
                }
                else if (assist == "Maintenance")
                {
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Gereserveerd);

                    ViewBag.Exception = "Er is een speciale actie vereist van een beheerder, wacht op instructies.";
                }
                else
                {
                    section = RideManagementRepository.Instance.GetFreeSection(depot, depot.Trams.Find(t => t.Id == tramId).TramType);
                    track = depot.Tracks.Find(t => t.Sections.Find(s => s.Id == section.Id) != null);

                    if (track == null)
                    {
                        ViewBag.Exception = "Fout bij ophalen van het spoornummer.";
                        return View();
                    }

                    DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, assist == "None" ? Status.Remise : Status.Schoonmaak);
                }

                ViewBag.TrackId = track?.Id;
                ViewBag.SectionId = section?.Id;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Fout bij het bevestigen van het tramnummer: {ex.Message}";
                return View();
            }
        }
    }
}