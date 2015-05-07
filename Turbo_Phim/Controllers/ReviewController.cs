using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;

namespace Turbo_Phim.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {

            ViewBag.HomeStatus = "inactive";
            ViewBag.VideoStatus = "inactive";
            ViewBag.ReviewStatus = "active";
            ViewBag.ContactStatus = "inactive";


            FilmService phimService = new FilmService();

            return View(phimService.getAllFilms());
         
        }

        public ActionResult ReviewDetail()
        {
            ViewBag.ReviewStatus = "active";
            return View();
        }
    }
}