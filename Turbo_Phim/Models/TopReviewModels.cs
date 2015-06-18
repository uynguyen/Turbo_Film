using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turbo_Phim.Models
{
    public class TopReviewModels
    {
      
        public String content { get; set; }


        public String UserName { get; set; }

        public int totalRank { get; set; }

        public String title { get; set; }
      

        public DateTime postDate { get; set; }


        public int MS_Phim { get; set; }

        public int MS_ReView { get; set; }

        public String TenPhim { get; set; }

        



        public String ulr_HinhAnh { get; set; }


        public string MS_TaiKhoan;


        
    }
}