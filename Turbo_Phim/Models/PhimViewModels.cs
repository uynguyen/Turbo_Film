using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Services;

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

         [Required(ErrorMessage = "Bạn chưa chọn {0}")]
         [Display(Name = "Thể loại")]
        public String TheLoai { get; set; }

         [Required(ErrorMessage = "Bạn chưa chọn {0}")]
         [Display(Name = "Thời lượng")]
        public double? ThoiLuong { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập tên {0}")]
         [Display(Name = "Diễn viên")]
        public string DienVien { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập tên {0}")]
         [Display(Name = "Đạo diễn")]
        public string DaoDien { get; set; }

         [Required(ErrorMessage = "Bạn chưa chọn {0}")]
         [Display(Name = "Nước sản xuất")]
        public String NuocSX { get; set; }

         [Required(ErrorMessage = "Bạn chưa chọn {0}")]
         [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

         [Required(ErrorMessage = "Bạn chưa nhập {0}")]
         [Display(Name = "Ngày phát hành")]
         public DateTime? NgayPhatHanh { get; set; }

         [Required(ErrorMessage = "Bạn chưa chọn {0}")]
         [Display(Name = "Hình banner")]
         public string Banner { get; set; }

         [AllowHtml]
         public String contentPost { get; set; }

         public String title { get; set; }

         public int MaSoBaiNhanXet { get; set; }


         public int MS_NuocSX { get; set; }

         public int MS_TheLoai { get; set; }

         public float DiemDanhGiaTrungBinh { get; set; }

         public int LuotDanhGia { get; set; }


        

        //-----------------------------SẮP XÊP & PHÂN TRANG GIỮA KỲ
         public String strSort { get; set; }


         public int currentPage { get; set; }

         public bool isASC { get; set; }




         public bool IsLikedByUser(string p, int ms_phim)
         {
             FilmLikeService sv = new FilmLikeService();
             return sv.checkList(p, ms_phim);
         }
    }
}