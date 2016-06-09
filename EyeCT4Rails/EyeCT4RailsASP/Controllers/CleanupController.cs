using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsASP.Controllers
{
    public class CleanupController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public ActionResult Overview()
        {
            List<Job> jobs = CleanupRepository.Instance.GetSchedule();

            ViewBag.Jobs = jobs;

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOne(string jobSize, string tramId, string date)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tramId))
                {
                    ViewBag.Exception = "Tram ID moet ingevuld zijn.";
                }
                else if (string.IsNullOrWhiteSpace(date))
                {
                    ViewBag.Exception = "Datum moet ingevuld zijn.";
                }
                else
                {
                    User user = Session["User"] as User;

                    if (user != null)
                    {
                        bool succes = CleanupRepository.Instance.ScheduleJob((JobSize)Enum.Parse(typeof(JobSize), jobSize),
                            user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date));

                        if (!succes)
                        {
                            ViewBag.Exception = "Beurt toevoegen is niet gelukt.";
                        }
                    }

                    return RedirectToAction("Overview", "Cleanup");
                }

                return RedirectToAction("Add", "Cleanup");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";
                return RedirectToAction("Add", "Cleanup");
            }
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string tramId, string date, string endDate, string interval)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tramId))
                {
                    ViewBag.Exception = "Tram ID moet ingevuld zijn.";
                }
                else if (string.IsNullOrWhiteSpace(date))
                {
                    ViewBag.Exception = "Datum moet ingevuld zijn.";
                }
                else if (string.IsNullOrWhiteSpace(endDate))
                {
                    ViewBag.Exception = "Eind datum moet ingevuld zijn.";
                }
                else if (string.IsNullOrWhiteSpace(interval))
                {
                    ViewBag.Exception = "Interval moet ingevuld zijn.";
                }
                else
                {
                    User user = Session["User"] as User;

                    if (user != null)
                    {
                        bool succes = CleanupRepository.Instance.ScheduleRecurringJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date), Convert.ToInt32(interval), Convert.ToDateTime(endDate));

                        if (!succes)
                        {
                            ViewBag.Exception = "Beurten toevoegen is niet gelukt.";
                        }
                    }

                    return RedirectToAction("Overview", "Cleanup");
                }

                return RedirectToAction("Add", "Cleanup");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";
                return RedirectToAction("Add", "Cleanup");
            }
        }

        public ActionResult HistoryOfJob(int tramId)
        {
            try
            {
                List<Job> history = CleanupRepository.Instance.GetHistory(tramId);

                if (history == null || history.Count == 0) return RedirectToAction("Overview", "Cleanup");

                ViewBag.History = history;
                ViewBag.TramId = tramId;
                ViewBag.TramType = history[0].Tram.TramType;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Cleanup");
            }
        }

        public ActionResult ChangeToDone(int jobId)
        {
            try
            {
                CleanupRepository.Instance.EditJobStatus(jobId, true);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het afronden van een beurt: {ex.Message}";
            }

            return RedirectToAction("Overview", "Cleanup");
        }
    }
}