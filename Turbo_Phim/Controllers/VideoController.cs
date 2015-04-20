using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turbo_Phim.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            ViewBag.HomeStatus = "inactive";
            ViewBag.VideoStatus = "active";
            ViewBag.ReviewStatus = "inactive";
            ViewBag.ContactStatus = "inactive";
            return View();
        }
    }
}