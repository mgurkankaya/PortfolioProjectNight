using PortfolioProjectNight.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var skills = db.Skills.ToList();
            ViewBag.sName = skills.Select(s => s.SkillName).ToList();
            ViewBag.sRate = skills.Select(s => s.Rate).ToList();
            return View();
        }
    }
}