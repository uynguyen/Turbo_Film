using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Bus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();

        public List<Phim> getAllFilms(int page)
        {
            return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.MaSo).Skip(page * 3 - 3).Take(3).ToList();
        }



        public string getTypeOfFilm(int? id)
        {
            return db.DanhMucTheLoai.Find(id).TenTheLoai;
        }
        public string getCountryOfFilm(int? id)
        {
            return db.DanhMucNuocSanXuat.Find(id).TenNuoc;
        }


        //public bool createNewFilm(Phim p)
        //{
        //    db.Phim.Add(p);

        //    db.SaveChanges();
        //    return true;
        //}

        /// <summary>
        /// Chỉ đánh dấu trạng thái thành false chứ không xóa thật sự
        /// </summary>
        /// <param name="codeFilm"></param>
        /// <returns></returns>
        public bool deleteFilm(string codeFilm)
        {
            int id = Int32.Parse(codeFilm);
            //Đánh dấu xóa phim
            Phim temp = db.Phim.Find(id);

            temp.TinhTrang = false;

            //Đánh dấu xóa những bài nhận xét liên quan

            List<BaiNhanXet> lstReview = db.BaiNhanXet.Where(x => x.MS_Phim == id).ToList();
            foreach (BaiNhanXet item in lstReview)
            {
                item.TinhTrang = false;
            }


            db.SaveChanges();



            return true;
        }



        public List<DanhMucTheLoai> getAllGeners()
        {
            return db.DanhMucTheLoai.Where(x => x.TinhTrang == true).ToList();
        }
        public List<DanhMucNuocSanXuat> getAllCountry()
        {
            return db.DanhMucNuocSanXuat.ToList();
        }

        public bool createNewGenre(string name)
        {
            DanhMucTheLoai genre = new DanhMucTheLoai();
            genre.TenTheLoai = name;
            genre.TinhTrang = true;
            db.DanhMucTheLoai.Add(genre);
            db.SaveChanges();
            return true;
        }
        public bool deleteGenre(int id)
        {
            DanhMucTheLoai genre = db.DanhMucTheLoai.Find(id);
            genre.TinhTrang = false;

            //Đổi thể loại của các bộ phim liên quan thành "khác"

            List<DanhMucTheLoai> diffGenre = db.DanhMucTheLoai.Where(x => x.TenTheLoai.Equals("Khác") ).ToList();

            List<Phim> lstFilms = db.Phim.Where(x => x.MS_TheLoai == id).ToList();
            foreach (Phim item in lstFilms)
            {
                item.MS_TheLoai = diffGenre[0].MaSo;
            }


            db.SaveChanges();



            return true;


        }

        public bool addNewFilmd(Phim p)
        {
            db.Phim.Add(p);

            db.SaveChanges();
            return true;
        }


 
     
    }
}
