using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Services
{
    public class RatingFilmServices
    {
        private FilmLikeBus bus = new FilmLikeBus();

        public bool addFilmLike(String ms_thanhVien, int ms_Phim, double rating)
        {
            return bus.addRating(ms_thanhVien, ms_Phim, rating);
        }
    }
}