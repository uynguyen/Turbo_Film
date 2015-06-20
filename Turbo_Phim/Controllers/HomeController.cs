using System.Collections.Generic;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;
using PagedList;
using PagedList.Mvc;

namespace Turbo_Phim.Controllers {
    public class HomeController : Controller {

        public ActionResult Index(bool? homepage)
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("Admin") && (!(homepage ?? false)))
                    return RedirectToAction("Index", "AdminMain");             
            }
            ViewBag.HomeStatus = "active";
            ViewBag.VideoStatus = "inactive";
            ViewBag.ReviewStatus = "inactive";
            ViewBag.ContactStatus = "inactive";
           FilmService phimService = new FilmService();

        


            ViewBag.maxIndexPage = phimService.getMaxIndexPage();

            List<PhimViewModels> result = phimService.filmMax();

            return View(result[0]);
        }

        public ActionResult filmNew(int? page)
        {
            FilmService phimService = new FilmService();

            List<PhimViewModels> result = phimService.findFilmNew();
            int pageNumber = page ?? 1;
            int pageSize = 5;
            return PartialView(result.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult showReview(int? page)
        {
            ReviewFilmService review = new ReviewFilmService();

            List<TopReviewModels> result = review.showReview();
            int pageNumber = page ?? 1;
            int pageSize = 5;
            return PartialView(result.ToPagedList(pageNumber, pageSize));
        }


        [Authorize]
        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Genre()
        {
            GenreService genre = new GenreService();
            return View(genre.getAllGener());
        }

        public ActionResult Country()
        {

            CountryService country = new CountryService();

            return View(country.getAllCountry());
        }
    }
}
