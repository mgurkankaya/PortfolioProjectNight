using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult TestimonialList()
        {
            var values = db.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            if (Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                testimonial.ImgUrl = "/Image/" + fileName + extension;

            }
            db.Testimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = db.Testimonials.Find(testimonial.TestimonailId);
            value.NameSurname = testimonial.NameSurname;
            value.Location = testimonial.Location;
            value.Comment = testimonial.Comment;
            value.ImgUrl = testimonial.ImgUrl;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}