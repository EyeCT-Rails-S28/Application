using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsASP.Controllers
{
    public class MaintenanceController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Overview");
        }

        public ActionResult Overview()
        {
            List<Job> jobs = MaintenanceRepository.Instance.GetSchedule();

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
                User user = Session["user"] as User;

                if (user != null)
                {
                    bool succes = MaintenanceRepository.Instance.ScheduleJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date));

                    if (!succes)
                    {
                        ViewBag.Exception = "Beurt toevoegen is niet gelukt.";
                    }
                }

                return RedirectToAction("Overview", "Maintenance");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een reparatie: {ex.Message}";
                return RedirectToAction("Add", "Maintenance");
            }
            
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string userName, string tramId, string date, string endDate, int interval)
        {
            try
            {
                User user = Session["user"] as User;

                if (user != null)
                {
                    bool succes = MaintenanceRepository.Instance.ScheduleRecurringJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date), interval, Convert.ToDateTime(endDate));

                    if (!succes)
                    {
                        ViewBag.Exception = "Beurte toevoegen is niet gelukt.";
                    }
                }

                return RedirectToAction("Add", "Maintenance");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = $"Er is een fout opgetreden bij het inplannen van een reparatie: {ex.Message}";
                return RedirectToAction("Add", "Maintenance");
            }
        }
    }
}