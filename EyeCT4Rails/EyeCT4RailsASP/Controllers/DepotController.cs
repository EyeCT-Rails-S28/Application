using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLogic.Repositories;
using EyeCT4RailsLogic.Utilities;
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
        public string SetSectionBlocked(int sectionId = -1)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                DepotManagementRepository.Instance.SetSectionBlocked(sectionId);
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

                DepotManagementRepository.Instance.SetTrackBlocked(trackId);

                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string AddTram(int sectionId = -1, int tramId = -1, bool reserved = false)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                if (reserved)
                    DepotManagementRepository.Instance.ReserveSection(tramId, sectionId);
                else
                    DepotManagementRepository.Instance.AddTramToSection(tramId, sectionId);

                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        [HttpPost]
        public string RemoveTram(int sectionId)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                DepotManagementRepository.Instance.RemoveTram(sectionId);

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

                DepotManagementRepository.Instance.ChangeTramStatus(tramId, status);

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
        public string GetTramInfo(int tramId)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                Dictionary<string, object> dictionary = DepotManagementRepository.Instance.GetTramInfo(tramId);
                Track track = dictionary["Track"] as Track;
                Section section = dictionary["Section"] as Section;
                Job cleanup = dictionary["Cleanup"] as Job;
                Job maintenance = dictionary["Maintenance"] as Job;

                return JsonConvert.SerializeObject(new
                {
                    status = "success",
                    trackId = track?.Id,
                    sectionId = section?.Id,
                    tramStatus = section?.Tram?.Status,
                    tramType = section?.Tram?.TramType.GetDescription(),

                    cleanup = new
                    {
                        size = cleanup == null ? null : TranslationUtil.TranslateJobSize(cleanup.JobSize),
                        user = cleanup?.User,
                        date = cleanup?.Date.ToShortDateString()
                    },
                    maintenance = new
                    {
                        size = maintenance == null ? null : TranslationUtil.TranslateJobSize(maintenance.JobSize),
                        user = maintenance?.User,
                        date = maintenance?.Date.ToShortDateString()
                    }
                },
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
        public string ReserveTram(int sectionId, int tramId)
        {
            try
            {
                if (!CheckRight(RIGHT, Session["User"] as User))
                {
                    throw new Exception("User not logged in!");
                }

                DepotManagementRepository.Instance.ReserveSectionForRepair(tramId, sectionId);

                return JsonConvert.SerializeObject(new { status = "success" });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        public ActionResult Trams()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

                List<Tram> trams = depot.Trams;
                List<Track> tracks = depot.Tracks;

                ViewBag.Trams = trams;
                ViewBag.Tracks = tracks;
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.Message;
            }

            return View();
        }

        public ActionResult Simulate()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            DepotManagementRepository.Instance.StartSimulation();

            return RedirectToAction("Index");
        }

        public ActionResult Cancel()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            DepotManagementRepository.Instance.StopSimulation();

            return RedirectToAction("Index");
        }
    }
}