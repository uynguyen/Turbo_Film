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
using Business;
using System.Collections.Generic;

namespace Turbo_Phim.Controllers
{
    public class ReviewDetailController : Controller
    {
        // GET: ReviewDetail
        public ActionResult Index(String IDPhim, String IDReview = "-1")
        {

            FilmService filmS = new FilmService();
            TempData["MaSoReview"] = IDReview;

            return View(filmS.getFilmByID(IDPhim));
        }
    
        [Authorize]

        public ActionResult CreateNewPost(PhimViewModels phim)
        {
            BaiNhanXet baiNhanXet = new BaiNhanXet();
            baiNhanXet.TinhTrang = true;
            baiNhanXet.MS_Phim = phim.MaSo;
            baiNhanXet.TieuDe = phim.title;
            baiNhanXet.NgayDang = System.DateTime.Now;
            baiNhanXet.NoiDung = phim.contentPost;
            baiNhanXet.MS_TaiKhoan = User.Identity.GetUserId();

            ReviewFilmService reviewS = new ReviewFilmService();

            bool result = reviewS.addPost(baiNhanXet);
            

            return View();
        }

        [Authorize]

        public ActionResult EditPost(String IDReview)
        {
            ReviewFilmService reviewS = new ReviewFilmService();

            TopReviewModels baiNhanXet = reviewS.getReview(IDReview);


            FilmService filmSV = new FilmService();
            PhimViewModels temp = filmSV.getFilmByID(baiNhanXet.MS_Phim.ToString());

            temp.contentPost = baiNhanXet.content;
            temp.title = baiNhanXet.title;





            return View(temp);
        }

        [Authorize]
        public ActionResult EditedPost(PhimViewModels phim)
        {

            FilmService bus = new FilmService();

            BaiNhanXet baiNhanXet = new BaiNhanXet();
            baiNhanXet.TinhTrang = true;
            baiNhanXet.MS_Phim = phim.MaSo;
            baiNhanXet.TieuDe = phim.title;
            baiNhanXet.NgayDang = System.DateTime.Now;
            baiNhanXet.NoiDung = phim.contentPost;
            baiNhanXet.MS_TaiKhoan = User.Identity.GetUserId();

            ReviewFilmService reviewS = new ReviewFilmService();

            bool result = reviewS.editPost(baiNhanXet);


            return View();
        }

        [Authorize]
        public ActionResult CreatePost(String IDPhim)
        {
           
            FilmService bus = new FilmService();
            return View(bus.getFilmByID(IDPhim));
        }


        public ActionResult TopReview(String IDPhim, String IDReview = "-1")
        {
            TopReviewModels result = null;
            ReviewFilmService reviewS = new ReviewFilmService();
            if(IDReview.Equals("-1"))
            {
               
              result   = reviewS.getTopReview(IDPhim);
            }
            else{
                result = reviewS.getReview(IDReview);
            }
            
            

            return View(result);
        }

        public ActionResult Top10Review(String IDPhim)
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            List<TopReviewModels> result = reviewS.getTop10Review(IDPhim);


            return View(result);
        }

    }
}