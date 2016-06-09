using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Collections.Generic;
using EyeCT4RailsLib.Enums;
using System.Linq;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLogic;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace EyeCT4RailsASP.Controllers
{
    public class DepotController : Controller
    {
        private const Right RIGHT = Right.ManageDepot;

        public ActionResult Index()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public string SetSectionBlocked(int trackId = -1, int sectionId = -1)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(t => t.Id == trackId);
                if (track == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Track ID niet gevonden." });
                }

                Section section = track.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Section ID niet gevonden." });
                }

                if (!(RideManagementRepository.Instance.CheckSectionFreedom(section, false) ||
                      RideManagementRepository.Instance.CheckSectionFreedom(section, true)) && section.Tram != null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Deze track kan niet geblokkeerd worden." });
                }

                DepotManagementRepository.Instance.SetSectionBlocked(sectionId, !section.Blocked);
                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string SetTrackBlocked(int trackId = -1)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                bool allFree = depot.Tracks.Find(t => t.Id == trackId).Sections.TrueForAll(s => s.Tram == null);
                if (!allFree)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Een of meerdere secties binnen deze track kunnen niet geblokkeerd worden." });
                }

                bool allBlocked = depot.Tracks.Find(t => t.Id == trackId).Sections.TrueForAll(s => s.Blocked);
                DepotManagementRepository.Instance.SetTrackBlocked(trackId, !allBlocked);

                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string AddTram(int trackId = -1, int sectionId = -1, int tramId = -1, bool reserved = false)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(t => t.Id == trackId);
                if (track == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Track ID niet gevonden." });
                }

                Section section = track.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Sectie ID niet gevonden." });
                }

                if (section.Tram != null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Deze sectie bevat al een tram." });
                }

                if (!(RideManagementRepository.Instance.CheckSectionFreedom(section, false) ||
                      RideManagementRepository.Instance.CheckSectionFreedom(section, true)))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Op deze sectie kan geen tram geplaatst worden." });
                }

                if (depot.Tracks.Any(t => t.Sections.Find(s => s.Tram != null && s.Tram.Id == tramId) != null))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = $"De tram met nummer {tramId} is al geplaatst." });
                }

                Tram tram = depot.Trams.Find(t => t.Id == tramId);
                if (tram == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Tram ID niet gevonden." });
                }

                DepotManagementRepository.Instance.ReserveSection(tramId, section.Id);

                Status status = tram.Status;
                if (tram.Status != Status.Defect && tram.Status != Status.Schoonmaak)
                {
                    DepotManagementRepository.Instance.ChangeTramStatus(tramId,
                        status = reserved ? Status.Dienst : Status.Remise);
                }

                return JsonConvert.SerializeObject(new { status = "success", message = status });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string RemoveTram(int trackId = -1, int sectionId = -1)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(t => t.Id == trackId);
                if (track == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Track ID niet gevonden." });
                }

                Section section = track.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Sectie ID niet gevonden." });
                }

                if (section.Tram == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Op deze sectie staat geen tram." });
                }

                if (!(RideManagementRepository.Instance.CheckSectionFreedom(section.NextSection, true) ||
                      RideManagementRepository.Instance.CheckSectionFreedom(section.PreviousSection, false)))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Deze tram kan niet verwijderd worden." });
                }

                DepotManagementRepository.Instance.RemoveTram(section.Id);
                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string ChangeStatus(int tramId = -1, string status = null)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Tram tram = depot.Trams.Find(t => t.Id == tramId);
                if (tram == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Tram ID niet gevonden." });
                }

                if (string.IsNullOrWhiteSpace(status))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Status niet gevonden." });
                }

                Status _status;

                try
                {
                    _status = (Status)Enum.Parse(typeof(Status), status);
                }
                catch (Exception)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Status niet gevonden." });
                }

                DepotManagementRepository.Instance.ChangeTramStatus(tram.Id, _status);
                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string GetTracks()
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                return JsonConvert.SerializeObject(new { status = "success", tracks = depot.Tracks },
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Converters = new List<JsonConverter>
                        {
                            new Newtonsoft.Json.Converters.StringEnumConverter()
                        }
                    });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string GetReservedTrams()
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                return JsonConvert.SerializeObject(new { status = "success", trams = DepotManagementRepository.Instance.GetTramsWithReservedFlag() },
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Converters = new List<JsonConverter>
                        {
                            new Newtonsoft.Json.Converters.StringEnumConverter()
                        }
                    });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string ReserveTram(int trackId, int sectionId, int tramId)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");
                Track track = depot.Tracks.Find(t => t.Id == trackId);
                if (track == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Track ID niet gevonden." });
                }

                Section section = track.Sections.Find(s => s.Id == sectionId);
                if (section == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Sectie ID niet gevonden." });
                }

                Tram tram = depot.Trams.Find(t => t.Id == tramId);
                if (tram == null)
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Tram ID niet gevonden." });
                }


                if (!RideManagementRepository.Instance.CheckSectionFreedom(section, true) &&
                    !RideManagementRepository.Instance.CheckSectionFreedom(section, false))
                {
                    return JsonConvert.SerializeObject(new { status = "fail", message = "Het is niet mogelijk om de geselecteerde tram op de geselecteerde sectie te plaatsen." });
                }


                DepotManagementRepository.Instance.ReserveSection(tram.Id, section.Id);
                DepotManagementRepository.Instance.ChangeTramStatus(tram.Id, Status.Defect);

                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }
    }
}