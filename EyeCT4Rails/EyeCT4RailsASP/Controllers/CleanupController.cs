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
        public ActionResult AddOne(string jobSize, string userName, string tramId, string date)
        {
            try
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
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";
                return RedirectToAction("Add", "Cleanup");
            }
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string userName, string tramId, string date, string endDate, int interval)
        {
            try
            {
                User user = Session["User"] as User;

                if (user != null)
                {
                    bool succes = CleanupRepository.Instance.ScheduleRecurringJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date), interval, Convert.ToDateTime(endDate));

                    if (!succes)
                    {
                        ViewBag.Exception = "Beurten toevoegen is niet gelukt.";
                    }
                }

                return RedirectToAction("Overview", "Cleanup");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een schoonmaakbeurt: {ex.Message}";
                return RedirectToAction("Add", "Cleanup");
            }
        }
    }
}