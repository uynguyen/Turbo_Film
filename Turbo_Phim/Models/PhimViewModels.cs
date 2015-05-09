using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class PhimViewModels
    {
        [Display(Name = "ID")]
        
        public int MaSo { get; set; }


       
        [Required(ErrorMessage = "Bạn chưa nhập {0}")]
        [Display(Name = "Tên phim")]
        public string TenPhim { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Trailer")]
        public string URL_Trailer { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Điểm")]
        public double? DiemDanhGia { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Thể loại")]
        public String TheLoai { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Thời lượng")]
        public double? ThoiLuong { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Diễn viên")]
        public string DienVien { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Đạo diễn")]
        public string DaoDien { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Nước sản xuất")]
        public String NuocSX { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Ngày phát hành")]
        public DateTime? NgayPhatHanh { get; set; }

       
      
    }
}