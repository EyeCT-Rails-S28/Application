using static EyeCT4RailsASP.Models.UserUtilities;

using System;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using EyeCT4RailsLogic.Repositories;
using Newtonsoft.Json;

namespace EyeCT4RailsASP.Controllers
{
    public class RideController : Controller
    {
        private const Right RIGHT = Right.ManageRide;

        public ActionResult Index()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public string GetSection(string tramnumber, string assist)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" });
            }

            try
            {
                string returned = RideManagementRepository.Instance.GetSection(Convert.ToInt32(tramnumber), assist);

                var section = Convert.ToInt32(returned.Split(',')[0]);
                var track = Convert.ToInt32(returned.Split(',')[1]);

                Session["TramID"] = Convert.ToInt32(tramnumber);
                Session["Assist"] = assist;

                return JsonConvert.SerializeObject(new { status = "success", trackId = track, sectionId = section});
            }
            catch (Exception ex)
            {
                if (ex is SpecialActionException)
                {
                    Session["TramID"] = Convert.ToInt32(tramnumber);
                    Session["Assist"] = assist;
                    return JsonConvert.SerializeObject(new { status = "fail", instruction = true, message = "Er is een speciale actie vereist van een beheerder, wacht op instructies." });
                }
                return JsonConvert.SerializeObject(new { status = "fail", message = $"Fout bij het bevestigen van het tramnummer: {ex.Message}" });
            }
        }

        [HttpPost]
        public string GetAssignedSection(int tramId)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" });
            }

            try
            {
                string returned = RideManagementRepository.Instance.GetAssignedSection(tramId);

                var section = Convert.ToInt32(returned.Split(',')[0]);
                var track = Convert.ToInt32(returned.Split(',')[1]);

                return JsonConvert.SerializeObject(new { status = "success", trackId = track, sectionId = section});
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = e.Message });
            }
        }

        public string GetPreviousTramId()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return JsonConvert.SerializeObject(new { status = "fail", message = "Gebruiker niet ingelogd!" });
            }

            if (Session["TramID"] != null && Session["Assist"] != null)
            {
                return JsonConvert.SerializeObject(new { status = "success", tramId = Session["TramID"], assist = Session["Assist"] });
            }

            return JsonConvert.SerializeObject(new { status = "fail" });
        }
    }
}