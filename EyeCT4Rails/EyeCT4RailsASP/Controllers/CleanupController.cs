using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Repositories;
using static EyeCT4RailsASP.Models.UserUtilities;
// ReSharper disable PossibleNullReferenceException
// Null references are already convered by checking the rights of the user.

namespace EyeCT4RailsASP.Controllers
{
    public class CleanupController : Controller
    {
        private const Right RIGHT = Right.ManageCleanup;

        public ActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public ActionResult Overview()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                List<Job> jobs = CleanupRepository.Instance.GetSchedule();

                ViewBag.Jobs = jobs;

                if (TempData["Exception"] != null)
                {
                    ViewBag.Exception = TempData["Exception"].ToString();
                    TempData.Remove("Exception");
                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddOne(string jobSize, string tramId, string date)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                //Catch manually send post request that contain null or whitespaces.
                if (string.IsNullOrWhiteSpace(tramId))
                    TempData["Exception"] = "Tram ID moet ingevuld zijn.";
                else if (string.IsNullOrWhiteSpace(date))
                    TempData["Exception"] = "Datum moet ingevuld zijn.";
                else
                {
                    User user = Session["User"] as User;
                    JobSize size = (JobSize) Enum.Parse(typeof (JobSize), jobSize);

                    bool succes =                                           
                        CleanupRepository.Instance.ScheduleJob(size, user, Convert.ToInt32(tramId), Convert.ToDateTime(date));

                    if (!succes)
                        TempData["Exception"] = "Beurt toevoegen is niet gelukt.";
                }
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";
            }

            return RedirectToAction("Overview", "Cleanup");
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string tramId, string date, string endDate, string interval)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                //Catch manually send post request that contain null or whitespaces.
                if (string.IsNullOrWhiteSpace(tramId))
                    TempData["Exception"] = "Tram ID moet ingevuld zijn.";
                else if (string.IsNullOrWhiteSpace(date))
                    TempData["Exception"] = "Datum moet ingevuld zijn.";
                else if (string.IsNullOrWhiteSpace(endDate))
                    TempData["Exception"] = "Eind datum moet ingevuld zijn.";
                else if (string.IsNullOrWhiteSpace(interval))
                    TempData["Exception"] = "Interval moet ingevuld zijn.";
                else
                {
                    User user = Session["User"] as User;
                    JobSize size = (JobSize)Enum.Parse(typeof(JobSize), jobSize);

                    bool succes = CleanupRepository.Instance.ScheduleRecurringJob(size, user, Convert.ToInt32(tramId), Convert.ToDateTime(date), Convert.ToInt32(interval), Convert.ToDateTime(endDate));

                    if (!succes)
                        TempData["Exception"] = "Beurten toevoegen is niet gelukt.";
                }
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";          
            }

            return RedirectToAction("Overview", "Cleanup");
        }

        public ActionResult HistoryOfJob(int tramId = -1)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            if (tramId == -1)
                return RedirectToAction("Overview");

            try
            {
                List<Job> history = CleanupRepository.Instance.GetHistory(tramId);

                if (history == null || history.Count == 0)
                {
                    TempData["Exception"] = $"Geen geschiedenis gevonden voor tramnummer {tramId}.";
                    return RedirectToAction("Overview", "Cleanup");
                }

                ViewBag.History = history;
                ViewBag.TramId = tramId;
                //Gets the type of the tram, works since the whole list of jobs concerns the same tram.
                ViewBag.TramType = history[0].Tram.TramType;

                return View();
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Cleanup");
            }
        }

        public ActionResult AllHistory()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                List<Job> history = CleanupRepository.Instance.GetHistory();

                if (history == null || history.Count == 0)
                    ViewBag.Exception = "Er is geen geschiedenis gevonden.";
                else
                    ViewBag.History = history;

                return View();
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Cleanup");
            }
        }

        public ActionResult HistorySince(string dateSince = "01-01-2000")
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                List<Job> history = CleanupRepository.Instance.GetHistory();

                if (history == null || history.Count == 0)
                    ViewBag.Exception = "Er is geen geschiedenis gevonden.";
                else
                {
                    ViewBag.History = history.FindAll(h => h.Date > Convert.ToDateTime(dateSince));
                    ViewBag.DateSince = dateSince;
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Cleanup");
            }
        }

        public ActionResult ChangeToDone(int jobId)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                CleanupRepository.Instance.EditJobStatus(jobId, true);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het afronden van een beurt: {ex.Message}";
            }

            return RedirectToAction("Overview", "Cleanup");
        }
    }
}