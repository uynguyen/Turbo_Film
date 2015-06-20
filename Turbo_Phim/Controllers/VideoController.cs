using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Services;
using PagedList;

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

        public ActionResult PagingIndex(int? page)
        {
            FilmService filmService = new FilmService();

            return PartialView(filmService.getNewFilms().ToPagedList(page ?? 1 , 8));
        }
    }
}