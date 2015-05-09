using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Turbo_Phim.Models
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
        }

        [Required(ErrorMessage="Vui lòng nhập tên đăng nhập!")]
        [Display(Name="Tên đăng nhập")]
        [System.Web.Mvc.Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "Tên đăng nhập đã tồn tại. Vui lòng nhập tên khác!")]
      
        public string UserName { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [MaxLength(20, ErrorMessage = "Độ dài mật khẩu tối đa 20 kí tự!")]
        [MinLength(6, ErrorMessage = "Độ dài mật khẩu tối thiểu 6 kí tự!")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

       
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không trùng khớp!")]
        [MaxLength(20, ErrorMessage = "Độ dài mật khẩu tối đa 20 kí tự!")]
        [MinLength(6, ErrorMessage = "Độ dài mật khẩu tối thiểu 6 kí tự!")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage="Vui lòng nhập lại mật khẩu!")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email!")]
        [EmailAddress(ErrorMessage="Định dạng email sai!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        [Display(Name = "Họ và tên:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        [Display(Name = "Giới tính")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày tháng năm sinh!")]
        [Display(Name = "Ngày tháng năm sinh")]
        [DataType(DataType.Date, ErrorMessage="Định dạng ngày tháng không đúng!"), 
        DisplayFormat(DataFormatString = "dd/MM/yyyy",
            ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Birthday { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn!")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        public System.Web.Mvc.SelectList getSex()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            list.Add(new System.Web.Mvc.SelectListItem { Value = "Nam", Text = "Nam" });
            list.Add(new System.Web.Mvc.SelectListItem { Value = "Nữ", Text = "Nữ" });
            return new System.Web.Mvc.SelectList(list, "Value", "Text", Sex);
        }

    }
}