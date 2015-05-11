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
            if (TempData["sortDirection"] == null)
                TempData["sortDirection"] = "true";

            FilmService phimService = new FilmService();
            ViewBag.maxIndexPage = phimService.getMaxIndexPage();


            if(TempData["actionSearch"] != null){
           
     
                switch(TempData["actionSearch"].ToString()){
                    case "searchNameFilm1":
                        {

                            List<PhimViewModels> searchResult = phimService.searchFilm(TempData["filmName"].ToString());

                            ViewBag.maxPage = phimService.countPageSearch(searchResult);

                            return View(searchResult);
                        }
                    case "searchFilm2":
                        {
                            return null;
                        }
                      
                }
            }


         
            ViewBag.maxPage = phimService.countPage();
       

            return View(phimService.getAllFilms(page,TempData["strSort"].ToString(), Boolean.Parse(TempData["sortDirection"].ToString())));
            
         
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


 // Search
        public ActionResult SearchFilm(string filmName)
        {
            TempData["actionSearch"] = "searchNameFilm1";
            TempData["filmName"] = filmName;
            getInfo();
            return RedirectToAction("Index");
        }
    }
}