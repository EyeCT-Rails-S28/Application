using System;
using System.Web.Mvc;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;

namespace EyeCT4RailsASP.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            User user;

            try
            {
                user = UserRepository.Instance.LoginUser(email, password);
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.Message;
                return View();
            }
            
            Session["User"] = user;

            switch (user.Function.Role)
            {
                case Role.Administrator:                
                case Role.DepotManager:
                    return RedirectToAction("Index", "Depot");
                case Role.Mechanic:
                    return RedirectToAction("Index", "Maintenance");
                case Role.Cleanup:
                    return RedirectToAction("Index", "Cleanup");
                case Role.Driver:
                    return RedirectToAction("Index", "Ride");
                default:
                    return Redirect("http://man-man-man.nl/");
            }

        }
    }
}