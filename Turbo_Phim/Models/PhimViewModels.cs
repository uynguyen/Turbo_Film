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
        [Display(Name = "Mã phim")]
        public int MaSo { get; set; }


        [Display(Name = "Tên phim")]
        public string TenPhim { get; set; }


         [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

         [Display(Name = "Trailer")]
        public string URL_Trailer { get; set; }

         [Display(Name = "Điểm đánh giá")]
        public double? DiemDanhGia { get; set; }

         [Display(Name = "Thể loại")]
        public String TheLoai { get; set; }

         [Display(Name = "Thời lượng")]
        public double? ThoiLuong { get; set; }

         [Display(Name = "Diễn viên")]
        public string DienVien { get; set; }

         [Display(Name = "Đạo diễn")]
        public string DaoDien { get; set; }

         [Display(Name = "Nước sản xuất")]
        public String NuocSX { get; set; }

         [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

         [Display(Name = "Ngày phát hành")]
        public DateTime? NgayPhatHanh { get; set; }

       
      
    }
}