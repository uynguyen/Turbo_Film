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
using PagedList;

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



        public ActionResult CommentsOfTopReview(int? page, String IDPhim, String IDReview = "-1")
        {          
            List<CommentViewModels> result = new List<CommentViewModels>();
            ReviewFilmService reviewS = new ReviewFilmService();
            TopReviewModels top = null;
            ViewBag.IDPhim = IDPhim;
            ViewBag.IDReview = IDReview;
            if(IDReview.Equals("-1")) // Bài Review nổi bật nhất
            {
                top = reviewS.getTopReview(IDPhim);
            }
            else
            {
                top = reviewS.getReview(IDReview);
            }
            
            if(top != null)
            {
                result = reviewS.getComment(top.MS_ReView.ToString());

                TempData["IDPost"] = top.MS_ReView;
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;
            
            return PartialView(result.ToPagedList(pageNumber, pageSize));
        }



        [AuthorizeUser]

        public ActionResult CreateNewPost(PhimViewModels phim)
        {
            BaiNhanXet baiNhanXet = new BaiNhanXet();
            baiNhanXet.TinhTrang = true;
            baiNhanXet.MS_Phim = phim.MaSo;
            baiNhanXet.TieuDe = phim.title;
            baiNhanXet.NgayDang = System.DateTime.Now;
            if (phim.contentPost == null)
                phim.contentPost = "";
            baiNhanXet.NoiDung = phim.contentPost;
            baiNhanXet.MS_TaiKhoan = User.Identity.GetUserId();

            ReviewFilmService reviewS = new ReviewFilmService();

            bool result = reviewS.addPost(baiNhanXet);
            

            return View();
        }

        [AuthorizeUser]

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

        [AuthorizeUser]
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
        [AuthorizeUser]
        public String DeletePost(String IDPost)
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            bool result = reviewS.deletePost(IDPost);

            if (result)
                return "success";
            else
                return "failed";
        }

        [AuthorizeUser]
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

        [Authorize]
       
        public ActionResult AddComment(String CommentContent , String IDPost)
        {
            ReviewFilmService reviewS = new ReviewFilmService();

            string IDUser = User.Identity.GetUserId();
            CommentViewModels result = reviewS.addComment(CommentContent, IDPost, IDUser);

            return PartialView(result);
        }
    }
}