﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DatabaseLevel;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using DataCommunication.Interfaces;


namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}