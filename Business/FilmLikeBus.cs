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
                DanhSachPhimYeuThich ds = new DanhSachPhimYeuThich();
                ds.MS_Phim = ms_phim;
                ds.MS_ThanhVien = ms_thanhVien;
                db.DanhSachPhimYeuThich.Add(ds);  
                db.SaveChanges();
                return true;
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

        public List<DanhSachPhimYeuThich> showFilmLike()
        {
            List<DanhSachPhimYeuThich> lst = new List<DanhSachPhimYeuThich>();
            lst = db.DanhSachPhimYeuThich.ToList();

            return lst;
        }

    }
}
