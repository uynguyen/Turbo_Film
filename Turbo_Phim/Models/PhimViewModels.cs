using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class PhimViewModels
    {

        public string TenPhim { get; set; }
        public string NoiDung { get; set; }
        public string URL_Trailer { get; set; }
        public double? DiemDanhGia { get; set; }
        public String TheLoai { get; set; }
        public double? ThoiLuong { get; set; }
        public string DienVien { get; set; }
        public string DaoDien { get; set; }
        public String NuocSX { get; set; }
        public string HinhAnh { get; set; }
        public DateTime? NgayPhatHanh { get; set; }

        private Bus bus = new Bus();
        public List<PhimViewModels> getAllFilms()
        {
            List<PhimViewModels> result = new List<PhimViewModels>();
            List<Phim> lstFilms = bus.getAllFilms();
            foreach (Phim p in lstFilms)
            {
                PhimViewModels pvm = new PhimViewModels();
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
                pvm.NuocSX = bus.getCountry(p.MS_NuocSX);
                result.Add(pvm);
            }

            return result;
        }
      
    }
}