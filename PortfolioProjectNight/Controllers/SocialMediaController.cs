using Newtonsoft.Json.Linq;
using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{

    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values = db.SocialMedias.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            db.SocialMedias.Add(socialMedia);
            socialMedia.Status = true;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = db.SocialMedias.Find(socialMedia.SocialMediaId);
            value.Title = socialMedia.Title;
            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;
            value.Status = socialMedia.Status;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            var value = db.SocialMedias.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            var value = db.SocialMedias.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}