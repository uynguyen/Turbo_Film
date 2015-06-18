using System.Globalization;
using Turbo_Phim.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Services;
using System.Collections.Generic;
using Business;
namespace Turbo_Phim.Controllers
{
    public class ReviewController : Controller
    {
      //   GET: Review
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

        [AuthorizeUser]
        [HttpPost]
        public ActionResult Insert_Film_Like(int MS_Phim)
        {
            AccountBus ac = new AccountBus();
            ThanhVien result = ac.getMemberByUserId(User.Identity.GetUserId());
            FilmLikeService film = new FilmLikeService();

            
            // true đã có
            // false chưa có;
            if (film.addFilmLike(result.MS_TaiKhoan, MS_Phim))
                return Content("success");
            else
                return Content("failure");
        }

 
        [HttpPost]
        public ActionResult IsLiked(int MS_Phim)
        {

            // o tren nay se kiem tra no dang nhap hay chua
            if (User == null)
            {
                return Content("");
            }
            else
            {
                // doan nay la no ra dang nhap roi
                AccountBus ac = new AccountBus();
                ThanhVien result = ac.getMemberByUserId(User.Identity.GetUserId());
                FilmLikeService film = new FilmLikeService();

                if (film.checkList(result.MS_TaiKhoan, MS_Phim))
                    return Content("btn-success");
                else
                    return Content("");
            }
        }

        [HttpPost]
        [AuthorizeUser]
        public String DeleteFilm(String IDFilm)
        {
            FilmLikeService filmS = new FilmLikeService();
            bool result = filmS.deleteFilm(IDFilm);

            if (result)
                return "success";
            else
                return "failed";
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