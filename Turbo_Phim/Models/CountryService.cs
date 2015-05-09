using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{

    public class CountryService
    {
        private FilmBus bus = new FilmBus();
        public List<DanhMucNuocSanXuat> getAllCountry()
        {
            return bus.getAllCountry();
        }

    }
}