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
    





        

        public ActionResult CommentsOfTopReview(String IDPhim)
        {

            
            List<CommentViewModels> result = new List<CommentViewModels>();
            ReviewFilmService reviewS = new ReviewFilmService();


            TopReviewModels top = reviewS.getTopReview(IDPhim);
            if(top != null)
            {
                result = reviewS.getComment(top.MS_ReView.ToString());

                TempData["IDPost"] = top.MS_ReView;
            }
        
      


            return View(result);
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
            temp.MaSoBaiNhanXet = baiNhanXet.MS_ReView;
            



            return View(temp);
        }

        [Authorize]
        public ActionResult EditedPost(PhimViewModels phim)
        {

            FilmService bus = new FilmService();

            BaiNhanXet baiNhanXet = new BaiNhanXet();
            baiNhanXet.MaSo = phim.MaSoBaiNhanXet;
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

      
        [HttpPost]
        [Authorize]
        public String DeletePost(String IDPost)
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            bool result = reviewS.deletePost(IDPost);

            if (result)
                return "success";
            else
                return "failed";
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

       
        public String AddComment(String CommentContent , String IDPost)
        {
            ReviewFilmService reviewS = new ReviewFilmService();

            string IDUser = User.Identity.GetUserId();
            reviewS.addComment(CommentContent, IDPost, IDUser);


            String result = "<div class='comments-section-grids'>" +
               "<div class='comments-section-grid'>" +
               "<div class='col-md-2 comments-section-grid-image'>" +
                  " <img src='~/Content/images/eye-brow.jpg' class='img-responsive'/>" +
               "</div>" +
               "<div class='col-md-10 comments-section-grid-text'>" +
                   "<h4>123</h4>" +
                   "<label>p.datePost.ToString()</label>" +
                   "<p>XYZ</p>" +
               "</div>" +
              " <div class='clearfix'></div>" +
           "</div></div>";

            return result;
        }
    }
}