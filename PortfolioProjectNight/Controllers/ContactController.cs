using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactMap()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactMessage()
        {
            return PartialView();
        }
    }
}