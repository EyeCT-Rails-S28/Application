﻿using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Repositories;
// ReSharper disable PossibleNullReferenceException

namespace EyeCT4RailsASP.Controllers
{
    public class MaintenanceController : Controller
    {
        private const Right RIGHT = Right.ManageRepair;

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
                List<Job> jobs = MaintenanceRepository.Instance.GetSchedule();
                List<User> users = UserRepository.Instance.GetUsers(Role.Mechanic);

                ViewBag.Jobs = jobs;
                ViewBag.Users = users;

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
        public ActionResult AddOne(string jobSize, int userId, string tramId, string date)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                if (string.IsNullOrWhiteSpace(tramId))
                    TempData["Exception"] = "Tram ID moet ingevuld zijn.";
                else if (string.IsNullOrWhiteSpace(date))
                    TempData["Exception"] = "Datum moet ingevuld zijn.";
                else
                {
                    User user = UserRepository.Instance.GetUser(userId);

                    if (user != null)
                    {
                        JobSize size = (JobSize)Enum.Parse(typeof(JobSize), jobSize);

                        bool succes =
                        MaintenanceRepository.Instance.ScheduleJob(size, user, Convert.ToInt32(tramId), Convert.ToDateTime(date));

                        if (!succes)
                            TempData["Exception"] = "Beurt toevoegen is niet gelukt.";
                    }
                    else
                    {
                        TempData["Exception"] = "Gebruiker bestaat niet.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het inplannen van een reparatie: {ex.Message}";
            }

            return RedirectToAction("Overview", "Maintenance");
        }

        [HttpPost]
        public ActionResult AddMore(string jobSize, int userId, string tramId, string date, string endDate, string interval)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
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
                    User user = UserRepository.Instance.GetUser(userId);

                    if (user != null)
                    {
                        JobSize size = (JobSize)Enum.Parse(typeof(JobSize), jobSize);

                        bool succes = MaintenanceRepository.Instance.ScheduleRecurringJob(size, user, Convert.ToInt32(tramId), Convert.ToDateTime(date), Convert.ToInt32(interval), Convert.ToDateTime(endDate));

                        if (!succes)
                            TempData["Exception"] = "Beurt toevoegen is niet gelukt.";
                    }
                    else
                    {
                        TempData["Exception"] = "Gebruiker bestaat niet.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het inplannen van een reparatie: {ex.Message}";
            }

            return RedirectToAction("Overview", "Maintenance");
        }

        public ActionResult HistoryOfJob(int tramId)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            if (tramId == -1)
                return RedirectToAction("Overview", "Maintenance");
            try
            {
                List<Job> history = MaintenanceRepository.Instance.GetHistory(tramId);

                if (history == null || history.Count == 0)
                {
                    TempData["Exception"] = $"Geen geschiedenis gevonden voor tramnummer {tramId}.";

                    return RedirectToAction("Overview", "Maintenance");
                }

                ViewBag.History = history;
                ViewBag.TramId = tramId;
                ViewBag.TramType = history[0].Tram.TramType.GetDescription();

                return View();
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Maintenance");
            }
        }

        public ActionResult AllHistory()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                List<Job> history = MaintenanceRepository.Instance.GetHistory();

                if (history == null || history.Count == 0)
                    ViewBag.Exception = "Er is geen geschiedenis gevonden.";
                else
                    ViewBag.History = history;

                return View();
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het weergeven van de geschiedenis: {ex.Message}";
                return RedirectToAction("Overview", "Maintenance");
            }
        }

        public ActionResult HistorySince(string dateSince = "01-01-2000")
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                List<Job> history = MaintenanceRepository.Instance.GetHistory();

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
                return RedirectToAction("Overview", "Maintenance");
            }
        }

        public ActionResult ChangeToDone(int jobId)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
                return RedirectToAction("Index", "Login");

            try
            {
                MaintenanceRepository.Instance.EditJobStatus(jobId, true);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = $"Er is een fout opgetreden bij het afronden van een beurt: {ex.Message}";
            }

            return RedirectToAction("Overview", "Maintenance");
        }
    }
}