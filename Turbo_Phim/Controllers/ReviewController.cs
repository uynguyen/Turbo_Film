using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;

namespace Turbo_Phim.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index(int? page)
        {
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
            


            FilmService phimService = new FilmService();


            ViewBag.maxPage = phimService.countPage();
            ViewBag.maxIndexPage = phimService.getMaxIndexPage();


            return View(phimService.getAllFilms(page, (String)TempData["strSort"], false));
        }



        public ActionResult SortByName()
        {
            TempData["strSort"] = "Name";
            getInfo();
            return RedirectToAction("Index");

        }

        public ActionResult SortByDate()
        {
            TempData["strSort"] = "Date";
            getInfo();
            return RedirectToAction("Index");

        }

        //Hàm lấy các thông tin lưu trữ hiện tại trạng thái của page
        private void getInfo()
        {
            TempData["currentPage"] = TempData["indexPage"];
        }

        public ActionResult SortByRank()
        {
            TempData["strSort"] = "Rank";
            getInfo();
            return RedirectToAction("Index");

        }

        public ActionResult SortByGenre()
        {
            TempData["strSort"] = "Genre";
            getInfo();
            return RedirectToAction("Index");

        }

        public ActionResult SortByDuration()
        {
            TempData["strSort"] = "Duration";
            getInfo();
            return RedirectToAction("Index");

        }

        public ActionResult ReviewDetail()
        {
            ViewBag.ReviewStatus = "active";
            return View();
        }

        public ActionResult Genre()
        {
            GenreService genre = new GenreService();
            return View(genre.getAllGener());
        }



        public ActionResult ViewForGenre(String genreID, int? page, String strSort)
        {
            TempData["strSort"] = strSort;
            if(genreID == null) //Nếu không xem them thể loại thì xem tất cả các phim
            {
                return RedirectToAction("Index");
            }

            ViewBag.ViewForGenre = true;
            ViewBag.genreID = genreID;


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
        
            FilmService phimService = new FilmService();
            ViewBag.maxIndexPage = phimService.getMaxIndexPage();

        

            List<PhimViewModels> lstPhim = phimService.findByGenre(genreID, page, TempData["strSort"].ToString(), false);
            ViewBag.maxPage = phimService.countPageSearch(lstPhim);
          

            return View("Index", lstPhim);
        }


    }
}