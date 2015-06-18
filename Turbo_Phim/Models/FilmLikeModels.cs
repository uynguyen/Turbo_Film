using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class FilmLikeModels
    {
        [Display(Name = "ID")]
        public int MaSo { get; set; }

        [Display(Name = "MS Thành Viên")]
        public string ms_thanhVien { get; set; }

        [Display(Name = "MS Phim")]
        public int ms_phim { get; set; }

        public int maso { get; set; }
    }
}