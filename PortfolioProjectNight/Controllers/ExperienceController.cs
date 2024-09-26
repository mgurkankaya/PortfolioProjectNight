using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ExperienceController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        // GET: Experience
        public ActionResult ExperienceList()
        {
            var values = db.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExperience(Experience experiences)
        {
            db.Experiences.Add(experiences);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public ActionResult DeleteExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = db.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience experiences)
        {
            var value = db.Experiences.Find(experiences.ExperienceId);
          
            value.Title = experiences.Title;
            value.Description = experiences.Description;
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}