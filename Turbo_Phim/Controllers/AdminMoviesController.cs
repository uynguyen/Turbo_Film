using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;

namespace Turbo_Phim.Controllers
{
    public class AdminMoviesController : Controller
    {
        // GET: AdminMovies
        public ActionResult Index()
        {


            FilmService phimService = new FilmService();




            return View(phimService.getAllFilms());
        }


        public ActionResult Delete(String codeFilm)
        {
            FilmService phimService = new FilmService();
            phimService.deletePhim(codeFilm);
            return RedirectToAction("Index");
        }
    }
}