using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;

namespace Turbo_Phim.Controllers
{
    public class AdminCategoryController : Controller
    {

        

        //
        // GET: /AdminCategory/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNewGenre(String name)
        {
            GenreService generService = new GenreService();
            generService.createNew(name);

            return RedirectToAction("Index");
        }

        public ActionResult deleteGenre(String id)
        {
            //GenreService generService = new GenreService();
           // generService.deleteGenre(Int32.Parse(id));
            return RedirectToAction("Index");
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