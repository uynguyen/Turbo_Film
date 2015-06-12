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

        public bool checkList(String ms_thanhVien, int ms_phim)
        {
            try
            {
                List<DanhSachPhimYeuThich> lst = new List<DanhSachPhimYeuThich>();
                lst = db.DanhSachPhimYeuThich.ToList();
                for (int i = 1; i < lst.Count(); i++)
                {
                    if (lst[i].MS_ThanhVien == ms_thanhVien && lst[i].MS_Phim == ms_phim)
                        return true;
                }
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
