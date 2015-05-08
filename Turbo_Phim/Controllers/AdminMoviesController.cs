using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;

namespace Turbo_Phim.Controllers
{
    public class AdminMoviesController : Controller
    {
        // GET: AdminMovies
        public ActionResult Index(int? page)
        {

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

            ViewBag.currentPage = TempData["currentPage"];
            
            FilmService phimService = new FilmService();



            return View(phimService.getAllFilms(page));
        }


        public ActionResult Delete(String codeFilm)
        {
            TempData["currentPage"] = 2;
            FilmService phimService = new FilmService();
            phimService.deletePhim(codeFilm);
            return RedirectToAction("Index");
        }

       
        public ActionResult CreateNewFilm()
        {
            return View();
        }


        public ActionResult AddNewFilm(HttpPostedFileBase file, String name, String rank, String actor,
            String director, String duration, String reissue, String genre, String country, String content, String trailer)
        {
            String fileName = "";
            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
            }


            Phim p = new Phim();

            p.NoiDung = content;
            p.NgayPhatHanh = System.DateTime.Now;
            p.TenPhim = name;
            p.TinhTrang = true;
            p.ThoiLuong = double.Parse(duration);
            p.DaoDien = director;
            p.DienVien = actor;
            p.MS_TheLoai = Int32.Parse( genre);
            p.MS_NuocSX = Int32.Parse(country);
            p.URL_Trailer = trailer;
            p.HinhAnh =  "/Images/" + fileName;

            FilmService filmsv = new FilmService();
            filmsv.addNewFilmd(p);
    



            return RedirectToAction("CreateNewFilm");
        }



        public ActionResult Genre()
        {
            GenreService genre = new GenreService();
            return View(genre.getAllGener());
        }

        public ActionResult Country()
        {

            CountryService country = new CountryService();

            return View(country.getAllCountry());
        }
    }
}