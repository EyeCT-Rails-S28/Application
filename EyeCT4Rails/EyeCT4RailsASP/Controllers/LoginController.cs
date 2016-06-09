using System;
using System.Web.Mvc;
using EyeCT4RailsASP.Models;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic;
using EyeCT4RailsLogic.Exceptions;

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
                if (e is InvalidUserException)
                    ViewBag.UserException = e.Message;
                else
                    ViewBag.Exception = e.Message;

                return View();
            }
            
            Session["User"] = user;

            string actionName = UserUtilities.GetActionName(user);
            string controllerName = UserUtilities.GetControllerName(user);

            return RedirectToAction(actionName, controllerName);
        }
    }
}