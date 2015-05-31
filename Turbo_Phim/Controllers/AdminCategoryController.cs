using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;

namespace Turbo_Phim.Controllers
{
    [Authorize(Roles = "Admin, Administrator")]
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


        public ActionResult EditGenre(String genreID, String newName)
        {
            GenreService generService = new GenreService();
            generService.editGenre(Int32.Parse(genreID), newName);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGenre(String genreID)
        {
            GenreService generService = new GenreService();
            generService.deleteGenre(Int32.Parse(genreID));
            return RedirectToAction("Index");
        }



        public ActionResult CreateNewCountry(String name)
        {
            CountryService countryService = new CountryService();
            countryService.createNew(name);

            return RedirectToAction("Index");
        }


        public ActionResult EditCountry(String countryID, String newName)
        {
            CountryService countryService = new CountryService();
            countryService.editCountry(Int32.Parse(countryID), newName);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCountry(String countryID)
        {
            CountryService countryService = new CountryService();
            countryService.deleteCountry(Int32.Parse(countryID));
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