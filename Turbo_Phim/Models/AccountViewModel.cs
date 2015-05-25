using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Models
{
    public class AccountViewModel
    {
        private AccountBus bus = new AccountBus();
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
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        [Display(Name = "Giới tính")]
        public string Gender { 
            get{return _gender?"Nam":"Nữ";}
            set { _gender = value == "Nam" ? true : false; }
        }

        [Required(ErrorMessage = "Vui lòng chọn ngày tháng năm sinh!")]
        [Display(Name = "Ngày tháng năm sinh")]
        [DataType(DataType.Date, ErrorMessage="Định dạng ngày tháng không đúng!"), 
        DisplayFormat(DataFormatString = "dd/MM/yyyy",
            ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Birthday { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn!")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name="Ngày đăng ký")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DayRegister { get; set; }
        [Display(Name="Phân Quyền")]
        public string Permission { get; set; }


        [Display(Name="#")]
        public int ID_Member { get; set; }

        public int ID_Account { get; set; }

        public int ID_Permission { get; set; }

        public System.Web.Mvc.SelectList getPermissions()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
           
            return new System.Web.Mvc.SelectList(list, "Value", "Text", ID_Permission);
        }

        public bool _gender;
    }
}