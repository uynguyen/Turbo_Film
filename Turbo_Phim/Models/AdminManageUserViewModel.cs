using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Models
{
    public class AdminManageUserViewModel
    {
        private AccountBus bus = new AccountBus();
        public AdminManageUserViewModel()
        {
        }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender
        {
            get { return _gender ? "Nam" : "Nữ"; }
            set { _gender = value == "Nam" ? true : false; }
        }


        [Display(Name = "Ngày tháng năm sinh")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Birthday { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Ngày đăng ký")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DayRegister { get; set; }


        [Display(Name = "Phân Quyền")]
        public string Role { get; set; }
        public bool _gender;

        [Display(Name = "#")]
        public string ID { get; set; }

        public string ID_Role { get; set; }

        public int ID_Member { get; set; }

        public System.Web.Mvc.SelectList getRoles()
        {
            List<System.Web.Mvc.SelectListItem> list = new List<System.Web.Mvc.SelectListItem>();
            foreach (var item in bus.getAllRoles())
            {
                list.Add(new System.Web.Mvc.SelectListItem { Value = item.Id, Text = item.Name });
            }
            return new System.Web.Mvc.SelectList(list, "Value", "Text", ID_Role);
        }


    }
}