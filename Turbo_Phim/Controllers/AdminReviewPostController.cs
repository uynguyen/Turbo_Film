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
     [Authorize(Roles = "Admin, Administrator")]
    public class AdminReviewPostController : Controller
    {
        // GET: AdminReviewPost
        public ActionResult Index()
        {    
            return View();
        }

        public ActionResult PagingIndex(int? page)
        {
            ReviewFilmService reviewS = new ReviewFilmService();

            return PartialView(reviewS.getAllReviewFilm().ToPagedList(page ?? 1, 10));
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