using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using EyeCT4RailsLib;
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
            Line line = new Line(1);
            Tram tram = new Tram(0, TramType.Combino, Status.Remise, line, false);
            Job job = new Job(0, DateTime.Now, false, JobType.Cleanup, JobSize.Small, tram, null);

            
            //List<Job> jobs = CleanupRepository.Instance.GetSchedule();
            List<Job> jobs = new ListStack<Job>();
            jobs.Add(job);
            jobs.Add(job);
            jobs.Add(job);
            jobs.Add(job);
            jobs.Add(job);

            //test dummy jobs

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
            User user = Session["user"] as User;

            if (user != null)
            {
                CleanupRepository.Instance.ScheduleJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date));
            }

            return RedirectToAction("Add", "Cleanup");
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string userName, string tramId, string date, string endDate, int interval)
        {
            User user = Session["user"] as User;

            if (user != null)
            {
                CleanupRepository.Instance.ScheduleRecurringJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date), interval, Convert.ToDateTime(endDate));
            }

            return RedirectToAction("Add", "Cleanup");
        }
    }
}