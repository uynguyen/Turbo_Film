using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Services
{

    public class CountryService
    {
        private FilmBus bus = new FilmBus();
        public List<DanhMucNuocSanXuat> getAllCountry()
        {
            return bus.getAllCountry();
        }


        internal bool createNew(string name)
        {
            return bus.createNewCountry(name);
        }

        internal bool editCountry(int p, string newName)
        {
            return bus.editCountry(p, newName);
        }

        internal bool deleteCountry(int p)
        {
            return bus.deleteCountry(p);
        }
    }
}