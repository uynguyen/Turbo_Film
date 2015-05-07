using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turbo_Phim.Controllers
{
    public class AdminMoviesController : Controller
    {
        // GET: AdminMovies
        public ActionResult Index()
        {
            return View();
        }
    }
}