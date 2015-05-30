using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turbo_Phim.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminMainController : Controller
    {
        // GET: AdminMain
        public ActionResult Index()
        {
            return View();
        }
    }
}