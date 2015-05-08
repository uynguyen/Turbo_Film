using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{

    public class CountryService
    {
        private Bus bus = new Bus();
        public List<DanhMucNuocSanXuat> getAllCountry()
        {
            return bus.getAllCountry();
        }

    }
}