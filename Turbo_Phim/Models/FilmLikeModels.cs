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
        public string thanhVien { get; set; }

        [Display(Name = "MS Phim")]
        public string tenPhim { get; set; }
    }
}