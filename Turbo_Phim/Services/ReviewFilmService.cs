using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
namespace Turbo_Phim.Services
{
    public class ReviewFilmService
    {
        internal bool addPost(Business.BaiNhanXet baiNhanXet)
        {
            ReviewFilmsBus bus = new ReviewFilmsBus();
            return bus.addPost(baiNhanXet);
        }
    }
}