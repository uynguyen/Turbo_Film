using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using Turbo_Phim.Services;

namespace Turbo_Phim.Controllers
{
    public class AdminReviewPostController : Controller
    {
        // GET: AdminReviewPost
        public ActionResult Index()
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            
            return View(reviewS.getAllReviewFilm());
        }
         [HttpPost]
        public string DeletePost(string codeReview)
        {
            ReviewFilmService reviewS = new ReviewFilmService();
            reviewS.deletePost(codeReview);
            return "";
        }
    }
}