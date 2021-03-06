﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Services
{
   
    public class GenreService
    {
        private FilmBus bus = new FilmBus();
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



        internal bool editGenre(int p, string newName)
        {
            return bus.editGenre(p,newName);
        }
    }
}