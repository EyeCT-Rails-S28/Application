using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Collections.Generic;
using System.Threading;
using EyeCT4RailsLib.Enums;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLogic.Repositories;
using EyeCT4RailsLogic.Utilities;
using Newtonsoft.Json;

namespace EyeCT4RailsASP.Controllers
{
    public class DepotController : Controller
    {
        private const Right RIGHT = Right.ManageDepot;
        private static bool cancelled;

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
        public string AddTram(int trackId = -1, int sectionId = -1, int tramId = -1, bool reserved = false)
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
        public string RemoveTram(int trackId = -1, int sectionId = -1)
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
        public string ReserveTram(int trackId, int sectionId, int tramId)
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

        public ActionResult Simulate()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            cancelled = false;

            Thread thread = new Thread(DoWork);
            thread.Start();

            return RedirectToAction("Index");
        }

        public ActionResult Cancel()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            cancelled = true;

            return RedirectToAction("Index");
        }

        private void DoWork()
        {
            Depot depot = DepotManagementRepository.Instance.GetDepot("Havenstraat");

            List<Section> sections = new List<Section>();
            depot.Tracks.ForEach(t => sections.AddRange(t.Sections));

            List<Tram> parkedTrams = new List<Tram>();
            sections.FindAll(s => s.Tram != null).ForEach(s => parkedTrams.Add(s.Tram));

            List<Tram> unparkedTrams = new List<Tram>(depot.Trams);
            unparkedTrams.RemoveAll(t => parkedTrams.Contains(t));

            int count = unparkedTrams.Count;
            Random random = new Random();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (cancelled)
                    {
                        break;
                    }

                    Tram tram = unparkedTrams[random.Next(unparkedTrams.Count)];
                    Section section = SectionUtil.GetFreeSection(depot, tram.TramType);
                    section.Tram = tram;

                    DepotManagementRepository.Instance.ReserveSection(tram.Id, section.Id);

                    unparkedTrams.Remove(tram);

                    Thread.Sleep(500);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}