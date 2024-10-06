using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();  

        // GET: Message
        public ActionResult Inbox()
        {
            var value = context.Contacts.ToList();
            return View(value);
        }
        public ActionResult ChangeToTrue(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult ChangeToFalse(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageDetails(int id)
        {
            var value = context.Contacts.Where(x => x.ContactId == id).FirstOrDefault();
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }
    }
}