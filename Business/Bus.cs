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
        
        public List<Phim> getAllFilms()
        {
            return db.Phim.Where(x => x.TinhTrang == true ).OrderBy(x => x.MaSo).Skip(3).Take(3).ToList();
        }



        public string getTypeOfFilm(int? id)
        {
            return db.DanhMucTheLoai.Find(id).TenTheLoai;
        }
        public string getCountry(int? id)
        {
            return db.DanhMucNuocSanXuat.Find(id).TenNuoc;
        }

        public bool createNewFilm(Phim p)
        {
            db.Phim.Add(p);
         
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Chỉ đánh dấu trạng thái thành false chứ không xóa thật sự
        /// </summary>
        /// <param name="codeFilm"></param>
        /// <returns></returns>
        public bool deleteFilm(string codeFilm)
        {
            int id = Int32.Parse(codeFilm);
            Phim temp = db.Phim.Find(id);

            temp.TinhTrang = false;

            db.SaveChanges();
            
          

            return true;  
        }


    }
}
