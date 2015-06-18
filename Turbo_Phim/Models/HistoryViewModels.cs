using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class HistoryViewModels
    {
        public string action { get; set; }
        public string content { get; set; }

        public DateTime dateAction { get; set; }

        public String tenPhim { get; set; }
        public int MS_Phim {get; set;}
        public String tenBaiNhanXet {get; set;}
        public int MS_BaiNhanXet {get;set;}
        public String Hoten { get; set; }



    }
}