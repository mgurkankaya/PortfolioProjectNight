using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();

        public ActionResult EducationList()
        {
            var values = db.Educations.ToList();
            return View(values);
        }

        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();
            return RedirectToAction("EducationList");

        }
        public ActionResult UpdateEducation(int id)
        {
            var value = db.Educations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = db.Educations.Find(education.EducationId);
            value.Title = education.Title;
            value.Subtitle = education.Subtitle;
            value.Description = education.Description;
            value.Year = education.Year;
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = db.Educations.Find(id);
            db.Educations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }

    }
}