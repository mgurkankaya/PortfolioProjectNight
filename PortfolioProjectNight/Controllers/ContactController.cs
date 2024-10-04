using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContact()
        {
            ViewBag.adress = context.Profiles.Single().Adres;
            ViewBag.description = context.Profiles.Single().Description;
            ViewBag.phone = context.Profiles.Single().Phone;
            ViewBag.email = context.Profiles.Single().Email;
            return PartialView();
        }

        public PartialViewResult PartialContactMap()
        {
            ViewBag.map = context.Profiles.Single().MAp;
            return PartialView();
        }

    }
}