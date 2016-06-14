using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Repositories;
using EyeCT4RailsLogic.Utilities;
using Newtonsoft.Json;

namespace EyeCT4RailsASP.Controllers
{
    public class RideController : Controller
    {
        private const Right RIGHT = Right.ManageRide;

        public ActionResult Index()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public string GetSection(string tramnumber, string assist)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" });
            }

            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                if (string.IsNullOrWhiteSpace(tramnumber))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Tram ID mag niet leeg zijn." });
                }

                int tramId = Convert.ToInt32(tramnumber);
                Track track = depot.Tracks.Find(t => t.Sections.Find(s => s.Tram?.Id == tramId) != null);

                if (!depot.Trams.Exists(t => t.Id == tramId))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = $"Tram met ID: {tramId} bestaat niet." });
                }

                Section section;
                if (track != null)
                {
                    section = track.Sections.Find(s => s.Tram?.Id == tramId);
                    Session["TramID"] = tramId;
                    Session["Assist"] = assist;

                    if (assist == "Maintenance")
                    {
                        RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Defect);
                    }
                    else if (assist == "Cleanup")
                    {
                        RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Schoonmaak);
                    }
                    else if (section.Tram.Status == Status.Dienst)
                    {
                        RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Remise);
                    }
                }
                else if (assist == "Maintenance")
                {
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, Status.Gereserveerd);
                    Session["TramID"] = tramId;
                    Session["Assist"] = assist;

                    return JsonConvert.SerializeObject(new { status = "fail", instruction = true, message = "Er is een speciale actie vereist van een beheerder, wacht op instructies." });
                }
                else
                {
                    section = SectionUtil.GetFreeSection(depot, depot.Trams.Find(t => t.Id == tramId).TramType);
                    track = depot.Tracks.Find(t => t.Sections.Find(s => s.Id == section.Id) != null);

                    if (track == null)
                    {
                        return JsonConvert.SerializeObject(new { status = "fail", message = "Fout bij ophalen van het spoornummer." });
                    }

                    DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);
                    RideManagementRepository.Instance.ChangeTramStatus(tramId, assist == "None" ? Status.Remise : Status.Schoonmaak);

                    Session["TramID"] = tramId;
                    Session["Assist"] = assist;
                }

                return JsonConvert.SerializeObject(new { status = "success", trackId = track?.Id, sectionId = section?.Id});
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = $"Fout bij het bevestigen van het tramnummer: {ex.Message}" });
            }
        }

        [HttpPost]
        public string GetAssignedSection(int tramId)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" }); ;
            }

            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Tram tram = depot.Trams.Find(t => t.Id == tramId);

                if (tram != null && tram.Status != Status.Gereserveerd)
                {
                    Track track =
                        depot.Tracks.Find(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null);
                    Section section = track.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId);

                    return JsonConvert.SerializeObject(new { status = "success", trackId = track.Id, sectionId = section.Id});
                }

                return JsonConvert.SerializeObject(new { status = "fail", message = "Not assigned yet"});
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        public string GetPreviousTramId()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" }); ;
            }

            if (Session["TramID"] != null && Session["Assist"] != null)
            {
                return JsonConvert.SerializeObject(new { status = "success", tramId = Session["TramID"], assist = Session["Assist"] });
            }

            return JsonConvert.SerializeObject(new { status = "fail" });
        }
    }
}