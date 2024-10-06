using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ServicesController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult ServiceList()
        {
            var values = db.Services.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.Services.Find(id);
            db.Services.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = db.Services.Find(service.ServiceId);

            value.Title = service.Title;
            value.Icon = service.Icon;
            value.description = service.description;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}