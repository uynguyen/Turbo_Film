using System.Collections.Generic;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;

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

    //    public ActionResult filmMaxPoint()
    //    {      
    //        ViewBag.HomeStatus = "inactive";
    //        ViewBag.VideoStatus = "inactive";
    //        ViewBag.ReviewStatus = "active";
    //        ViewBag.ContactStatus = "inactive";
 

            
    //    }
    }
}
