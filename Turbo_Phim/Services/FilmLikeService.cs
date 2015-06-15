using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Turbo_Phim.Models;

namespace Turbo_Phim.Services
{
    public class FilmLikeService
    {
        private FilmLikeBus bus = new FilmLikeBus();

        public bool addFilmLike(String ms_thanhVien, int ms_Phim)
        {
            return bus.addFilmLike(ms_thanhVien, ms_Phim);
        }

        public bool checkList(string username, int ms_phim)
        {
            return bus.checkList(username, ms_phim);
        }

        public FilmLikeModels showFilmLike(DanhSachPhimYeuThich p)
        {
            FilmLikeModels result = new FilmLikeModels();
            

            return result;
        }
        
    }
}