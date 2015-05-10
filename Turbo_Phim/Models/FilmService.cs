using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class FilmService
    {
        private Bus bus = new Bus();
        public List<PhimViewModels> getAllFilms(int? page)
        {
            if (page == null)
                page = 1;
            List<PhimViewModels> result = new List<PhimViewModels>();
            List<Phim> lstFilms = bus.getAllFilms((int)page);
            foreach (Phim p in lstFilms)
            {
                PhimViewModels pvm = new PhimViewModels();
                pvm.MaSo = p.MaSo;
                pvm.TenPhim = p.TenPhim;
                pvm.NoiDung = p.NoiDung;
                pvm.URL_Trailer = p.URL_Trailer;
                pvm.DiemDanhGia = p.DiemDanhGia;
                pvm.ThoiLuong = p.ThoiLuong;
                pvm.DienVien = p.DienVien;
                pvm.DaoDien = p.DaoDien;
                pvm.HinhAnh = p.HinhAnh;
                pvm.NgayPhatHanh = p.NgayPhatHanh;
                pvm.TheLoai = bus.getTypeOfFilm(p.MS_TheLoai);
                pvm.NuocSX = bus.getCountryOfFilm(p.MS_NuocSX);
                result.Add(pvm);
            }

            return result;
        }

        //public void createFilm()
        //{
        //    Phim phim = new Phim();

        //    phim.NoiDung = "Nguyễn Long Uy";
        //    phim.HinhAnh = "/Content/images/01.jpg";
        //    phim.DienVien = "Uy Nguyễn";
        //    phim.DaoDien = "Xanh Hồ";
        //    phim.MS_NuocSX = 1;
        //    phim.MS_TheLoai = 0;
        //    phim.TenPhim = "Test";
        //    phim.ThoiLuong = 120;
        //    phim.URL_Trailer = "https://www.youtube.com/watch?v=DlM2CWNTQ84";
        //    phim.NgayPhatHanh = System.DateTime.Now;
        //    phim.DiemDanhGia = 9;

        //    bus.createNewFilm(phim);
        //}

        internal void deletePhim(string codeFilm)
        {
            string temp = codeFilm;
            bus.deleteFilm(codeFilm);
        }

        internal bool addNewFilmd(Phim p)
        {
            return bus.addNewFilmd(p);
        }


    }
}