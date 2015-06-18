using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FilmLikeBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();

        public bool addFilmLike(String ms_thanhVien, int ms_phim)
        {
            try
            {
                DanhSachPhimYeuThich check = db.DanhSachPhimYeuThich.Where(
                e => e.MS_ThanhVien == ms_thanhVien && e.MS_Phim == ms_phim && e.TinhTrang == false).FirstOrDefault();

                if (check != null)
                {
                    check.TinhTrang = true;
                    check.ThoiGian = System.DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    DanhSachPhimYeuThich ds = new DanhSachPhimYeuThich();
                    ds.MS_Phim = ms_phim;
                    ds.MS_ThanhVien = ms_thanhVien;
                    ds.TinhTrang = true;
                    ds.ThoiGian = System.DateTime.Now;
                    db.DanhSachPhimYeuThich.Add(ds);

                    db.SaveChanges();
                    return true;
                }


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool checkList(string username, int ms_phim)
        {
            AspNetUsers user = db.AspNetUsers.SingleOrDefault(e=>e.UserName == username);
            if (user == null) return false;           

            try
            {
                DanhSachPhimYeuThich ds = db.DanhSachPhimYeuThich.Where(
                    e => e.MS_ThanhVien == user.Id && e.MS_Phim == ms_phim && e.TinhTrang == true).FirstOrDefault();
                if (ds != null)
                    return true;
                else
                    return false;
            } 
            catch (Exception e)
            {
                return false;
            }
        }

        public bool checkRate(string username, int ms_phim)
        {
            AspNetUsers user = db.AspNetUsers.SingleOrDefault(e => e.UserName == username);
            if (user == null) return false;

            try
            {
                DanhGia ds = db.DanhGia.Where(
                    e => e.MS_ThanhVien == user.Id && e.MS_Phim == ms_phim).FirstOrDefault();
                if (ds != null)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //public List<DanhSachPhimYeuThich> showFilmLike()
        //{
        //    List<DanhSachPhimYeuThich> lst = new List<DanhSachPhimYeuThich>();
        //    lst = db.DanhSachPhimYeuThich.ToList();
        //    return lst;
        //}

        public List<DanhSachPhimYeuThich> getMyListFilmLike(string IDUser)
        {
          return db.DanhSachPhimYeuThich.Where(x => x.MS_ThanhVien.Equals(IDUser) && x.TinhTrang == true).ToList();
         //   return db.DanhSachPhimYeuThich.Where(x => x.MS_ThanhVien.Equals(IDUser)).ToList();
        }

        public bool deleteFilm(int IDFilm)
        {
            try
            {
                DanhSachPhimYeuThich temp = db.DanhSachPhimYeuThich.Where(x => x.MS_Phim == IDFilm).FirstOrDefault();
                temp.TinhTrang = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public double getRating(string username, int ms_phim)
        {
            if (username == null) return -1;
            AspNetUsers user = db.AspNetUsers.SingleOrDefault(e => e.UserName == username);
            if (user == null) return -1;

            try
            {
                DanhGia ds = db.DanhGia.Where(
                    e => e.MS_ThanhVien == user.Id && e.MS_Phim == ms_phim).FirstOrDefault();
                if (ds != null)
                    return ds.DiemDanhGia ?? -1;
                else
                    return -1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool addRating(string ms_thanhVien, int ms_Phim, double rating)
        {
            try
            {
                DanhGia check = db.DanhGia.Where(
                e => e.MS_ThanhVien == ms_thanhVien && e.MS_Phim == ms_Phim).FirstOrDefault();

                if (check != null)
                {
                    return false;
                }
                else
                {
                    DanhGia dg = new DanhGia();
                    dg.MS_ThanhVien = ms_thanhVien;
                    dg.MS_Phim = ms_Phim;
                    dg.ThoiGian = System.DateTime.Now;
                    dg.DiemDanhGia = rating;
                    db.DanhGia.Add(dg);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
