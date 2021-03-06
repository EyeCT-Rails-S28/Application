﻿using System;
using System.Web.Mvc;
using static EyeCT4RailsASP.Models.UserUtilities;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Repositories;

namespace EyeCT4RailsASP.Controllers
{
    public class UserController : Controller
    {
        private const Right RIGHT = Right.ManageUser;

        public ActionResult Index()
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string email, string password, string passwordRepeat, string role)
        {
            if (!CheckRight(RIGHT, Session["User"] as User))
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordRepeat))
                {
                    throw new Exception("Jij bent een stoute jonge, niet zelf proberen te posten!");
                }

                if (password != passwordRepeat)
                {
                    throw new Exception("Wachtwoorden komen niet overeen!");
                }

                Role roleEnum = (Role)Enum.Parse(typeof(Role), role);
                UserRepository.Instance.CreateUser(name, password, email, roleEnum);

                ViewBag.Success = $"Gebruiker {name} is succesvol toegevoegd.";
            }
            catch (Exception e)
            {
                ViewBag.Name = name;
                ViewBag.Email = email;
                ViewBag.Role = role;
                ViewBag.Exception = e.Message;
            }

            return View();
        }
    }
}