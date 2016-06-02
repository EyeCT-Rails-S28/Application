﻿using System;
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
            User user = Session["user"] as User;

            if (user != null)
            {
                CleanupRepository.Instance.ScheduleJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date));
            }

            return RedirectToAction("Overview", "Cleanup");
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, string userName, string tramId, string date, string endDate, int interval)
        {
            User user = Session["user"] as User;

            if (user != null)
            {
                CleanupRepository.Instance.ScheduleRecurringJob((JobSize)Enum.Parse(typeof(JobSize), jobSize), user.Id, Convert.ToInt32(tramId), Convert.ToDateTime(date), interval, Convert.ToDateTime(endDate));
            }

            return RedirectToAction("Overview", "Cleanup");
        }
    }
}