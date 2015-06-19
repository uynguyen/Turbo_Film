using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;
using PagedList;

namespace Turbo_Phim.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleSearch(int? page, String filmName)
        {
            ViewBag.filmName = filmName;

           
            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";

            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";
            FilmService phimService = new FilmService();

            List<PhimViewModels> searchResult = phimService.searchFilm(filmName);
            return View(searchResult);
        }

        public ActionResult PagingSimpleSearch(int? page, String filmName)
        {
            ViewBag.filmName = filmName;
            
            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";

            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";

            FilmService phimService = new FilmService();

            ViewBag.maxIndexPage = phimService.getMaxIndexPage();

            List<PhimViewModels> searchResult = phimService.searchFilm(filmName);

            return PartialView(searchResult.ToPagedList(page ?? 1,10));
        }

        public ActionResult AdvanceSearch(int? page, String actor, String directer, String country, String type)
        {
            ViewBag.actor = actor;
            ViewBag.directer = directer;
            ViewBag.country = country;
            ViewBag.type = type;

            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";
            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";



            FilmService phimService = new FilmService();
 
     

            List<PhimViewModels> searchResult = phimService.searchFilm4(actor, directer, country, type);
        

            return View(searchResult);


        }

        public ActionResult PagingAdvanceSearch(int? page, String actor, String directer, String country, String type)
        {
            ViewBag.actor = actor;
            ViewBag.directer = directer;
            ViewBag.country = country;
            ViewBag.type = type;

          
            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";
            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";



            FilmService phimService = new FilmService();

            List<PhimViewModels> searchResult = phimService.searchFilm4(actor, directer, country, type);


            return PartialView(searchResult.ToPagedList(page??1, 10));


        }
    }
}