using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        } 
        
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult DownloadMyCV()
        {
            var filePath = Server.MapPath("~/Content/CvFile/MGK_CV.pdf");
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound("Dosya veritabanında bulunamadı.");
            }
            var fileName = "MGK_CV.pdf";
            return File(filePath, "pdf", fileName);
        }


        public ActionResult DownloadCV()
        {
            return View();
        }
    }
}