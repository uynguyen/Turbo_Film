using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Models
{
   
    public class GenreService
    {
        private Bus bus = new Bus();
        public List<DanhMucTheLoai> getAllGener()
        {
            return bus.getAllGeners() ;
        }



        public bool createNew(string name)
        {
            return bus.createNewGenre(name);
        }

        public bool deleteGenre(int id)
        {
            return bus.deleteGenre(id);
        }


    }
}