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

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.aboutTitle = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutDescription = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.aboutImgUrl = context.Abouts.Select(x => x.ImgUrl).FirstOrDefault();
            var value = context.SocialMedias.ToList();
            return PartialView(value);

        }
        public PartialViewResult PartialExperience()
        {

            var values = context.Experiences.ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialEducation()
        {

            var values = context.Educations.ToList();
            return PartialView(values);

        }

        public PartialViewResult PartialSkill()
        {
            var values = context.Skills.Where(x => x.Status == true).ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialPortfolio()
        {
            var values = context.Projects.ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialTestimonial()
        {
            var value = context.Testimonials.ToList();
            return PartialView(value);

        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.title = context.Profiles.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profiles.Select(x => x.Description).FirstOrDefault();
            ViewBag.adress = context.Profiles.Select(x => x.Adres).FirstOrDefault();
            ViewBag.email = context.Profiles.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profiles.Select(x => x.Phone).FirstOrDefault();
            ViewBag.github = context.Profiles.Select(x => x.Github).FirstOrDefault();
            ViewBag.imgUrl = context.Profiles.Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.title2 = context.Profiles.Single().Title;
            var value = context.SocialMedias.ToList();
            return PartialView(value);
        }
    }
}