using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ProjectsController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult ProjectList()
        {
            var values = db.Projects.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.Projects.Find(id);
            db.Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.Projects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = db.Projects.Find(project.ProjectId);
            value.Title = project.Title;
            value.Subtitle = project.Subtitle;
            value.ImgUrl = project.ImgUrl;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}