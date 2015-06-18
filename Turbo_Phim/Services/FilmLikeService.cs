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

        public bool checkRate(string username, int ms_phim)
        {
            return bus.checkRate(username, ms_phim);
        }

        public FilmLikeModels DanhSachPhimYeuThich2DanhSachPhimYeuThichFilmModel(DanhSachPhimYeuThich p)
        {
            FilmLikeModels result = new FilmLikeModels();
            result.MaSo = p.MaSo;
            result.ms_thanhVien = p.MS_ThanhVien;
            int temp = (int)p.MS_Phim;           
            result.ms_phim = temp;


            return result;
        }


        internal List<FilmLikeModels> getMyListFilmLike(string IDUser)
        {
            List<FilmLikeModels> lst = new List<FilmLikeModels>();

            FilmLikeBus bus = new FilmLikeBus();
            List<DanhSachPhimYeuThich> film = bus.getMyListFilmLike(IDUser);

            if(film != null)
            {
                foreach(DanhSachPhimYeuThich ds in film)
                {
                    lst.Add(DanhSachPhimYeuThich2DanhSachPhimYeuThichFilmModel(ds));
                }
                return lst;
            }
            else
                return null;
        }

        public bool deleteFilm(string IDFilm)
        {
            FilmLikeBus bus = new FilmLikeBus();
            return bus.deleteFilm(Int32.Parse(IDFilm));
        }



    }
}