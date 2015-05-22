using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;

namespace Turbo_Phim.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleSearch(int?page, String filmName)
        {
            ViewBag.filmName = filmName;

            ViewBag.HomeStatus = "inactive";
            ViewBag.VideoStatus = "inactive";
            ViewBag.ReviewStatus = "active";
            ViewBag.ContactStatus = "inactive";
            if (page == null)
            {
                if (TempData["currentPage"] != null)
                {
                    page = Int32.Parse(TempData["currentPage"].ToString()); 
                }
                else
                {
                    page = 1;
                    TempData["currentPage"] = page;
                }
            }
            else
                TempData["currentPage"] = page;
            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";

            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";

            FilmService phimService = new FilmService();

            int maxPage;

            ViewBag.maxIndexPage = phimService.getMaxIndexPage();

            List<PhimViewModels> searchResult = phimService.searchFilm(filmName,(int) page, out maxPage);
            ViewBag.maxPage = maxPage;

            return View(searchResult);
        }

        public ActionResult AdvanceSearch(int? page, String actor, String directer, String country, String type)
        {
            ViewBag.actor = actor;
            ViewBag.directer = directer;
            ViewBag.country = country;
            ViewBag.type = type;

            ViewBag.HomeStatus = "inactive";
            ViewBag.VideoStatus = "inactive";
            ViewBag.ReviewStatus = "active";
            ViewBag.ContactStatus = "inactive";
            if (page == null)
            {
                if (TempData["currentPage"] != null)
                {
                    page = Int32.Parse(TempData["currentPage"].ToString()); //Chuyển hướng từ action delete
                }
                else
                {
                    page = 1;
                    TempData["currentPage"] = page;
                }
            }
            else
                TempData["currentPage"] = page;
            if (TempData["strSort"] == null)
                TempData["strSort"] = "ID";
            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";



            FilmService phimService = new FilmService();
            int maxPage;
            ViewBag.maxIndexPage = phimService.getMaxIndexPage();

            List<PhimViewModels> searchResult = phimService.searchFilm4(actor, directer, country, type, (int)page, out maxPage);
            ViewBag.maxPage = maxPage;
            
            return View(searchResult);

    
        }



	}
}