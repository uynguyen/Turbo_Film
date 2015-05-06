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
            return db.Phim.ToList();
        }



        public string getTypeOfFilm(int? id)
        {
            return db.DanhMucTheLoai.Find(id).TenTheLoai;
        }
        public string getCountry(int? id)
        {
            return db.DanhMucNuocSanXuat.Find(id).TenNuoc;
        }
    }
}
