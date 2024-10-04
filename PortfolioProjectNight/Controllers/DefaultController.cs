using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.v = value;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.IsRead = false;
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PartialHead()
        {
            return PartialView();
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult PartialNavBar()
        {
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialExperience()
        {

            var values = context.Experiences.ToList();
            return PartialView(values);

        }

        public PartialViewResult PartialSkill()
        {
            var values = context.Skills.Where(x => x.Status == true).ToList();
            return PartialView(values);

        }

        public ActionResult PartialHeader()
        {
            ViewBag.title = context.Profiles.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profiles.Select(x => x.Description).FirstOrDefault();
            ViewBag.adress = context.Profiles.Select(x => x.Adres).FirstOrDefault();
            ViewBag.email = context.Profiles.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profiles.Select(x => x.Phone).FirstOrDefault();
            ViewBag.github = context.Profiles.Select(x => x.Github).FirstOrDefault();
            ViewBag.imgUrl = context.Profiles.Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.title2 = context.Profiles.Single().Title;
            return PartialView();
        }
    }
}