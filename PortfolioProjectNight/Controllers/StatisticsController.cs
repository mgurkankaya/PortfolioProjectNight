using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class StatisticsController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.TMC = context.Contacts.Count();
            ViewBag.MRT = context.Contacts.Where(x => x.IsRead == true).Count();
            ViewBag.MRF = context.Contacts.Where(x => x.IsRead == false).Count();
            ViewBag.Skill = context.Skills.Count();
            ViewBag.SkillSum = context.Skills.Sum(x => x.Rate);
            ViewBag.SkillRate = context.Skills.Average(x => x.Rate);
            ViewBag.SkillTop = context.Skills.OrderByDescending(x => x.Rate).Select(x => x.SkillName).FirstOrDefault();
            ViewBag.MsjCountRef = context.Contacts.Where(x => x.Subject == "Referans").Count();
            ViewBag.MsjCountRefName = context.Contacts.Where(x => x.Subject == "Referans").Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.x = context.Contacts.Where(x => x.IsRead == true && x.Email.Contains("h")).Count();
            ViewBag.xx = context.Skills.Where(x => x.Rate == 90).Select(y => y.SkillName).FirstOrDefault();
            //var maxRate = context.Skills.Max(x=>x.Rate);
            //ViewBag.MaxRate = context.Skills.Where(x=>x.Rate == maxRate).Select(y=>y.SkillName).FirstOrDefault();
            return View();
        }
    }
}