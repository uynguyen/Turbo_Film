using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Turbo_Phim.Services;

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


        public ActionResult getStatisticPhimForGenre()
        {

            FilmService filmService = new FilmService();
            Dictionary<string, int> result = filmService.getStatisticPhimForGenre();
  
         
       
            string temp = "[";
            int i = 0;
            foreach(string key in result.Keys)
            {

                string t = "";
              
                t += "['" + key + "', " + result[key] +"]";
                if(i < result.Count - 1)
                {
                    t += ",";
                }
                temp += t;
                i++;
            }
       
            temp += "]";
       
           temp = temp.Replace("\'", "\"");

            return Content(temp);
        }

        public ActionResult getStatisticPhimForCountry()
        {

            FilmService filmService = new FilmService();
            Dictionary<string, int> result = filmService.getStatisticPhimForCountry();
            string temp = "[";
            int i = 0;
            foreach (string key in result.Keys)
            {

                string t = "";

                t += "['" + key + "', " + result[key] + "]";
                if (i < result.Count - 1)
                {
                    t += ",";
                }
                temp += t;
                i++;
            }
            temp += "]";

            temp = temp.Replace("\'", "\"");

            return Content(temp);
        }
    }
}