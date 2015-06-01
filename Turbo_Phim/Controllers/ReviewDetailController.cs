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

namespace Turbo_Phim.Controllers
{
    public class ReviewDetailController : Controller
    {
        // GET: ReviewDetail
        public ActionResult Index(String IDPhim)
        {

            FilmService filmS = new FilmService();


            return View(filmS.getFilmByID(IDPhim));
        }
    
        [Authorize]

        public ActionResult CreateNewPost(PhimViewModels phim)
        {
            BaiNhanXet baiNhanXet = new BaiNhanXet();
            baiNhanXet.TinhTrang = true;
            baiNhanXet.MS_Phim = phim.MaSo;
            
            baiNhanXet.NgayDang = System.DateTime.Now;
            baiNhanXet.NoiDung = phim.contentPost;
            baiNhanXet.MS_TaiKhoan = User.Identity.GetUserId();

            ReviewFilmService reviewS = new ReviewFilmService();

            bool result = reviewS.addPost(baiNhanXet);
            

            return View();
        }

        [Authorize]
        public ActionResult CreatePost(String IDPhim)
        {
           
            FilmService bus = new FilmService();
            return View(bus.getFilmByID(IDPhim));
        }


        public ActionResult TopReview(String IDPhim)
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            return View(reviewS.getTopReview(IDPhim));
        }

    }
}