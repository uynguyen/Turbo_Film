using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
namespace Turbo_Phim.Models
{
    public class UserAccountService
    {
        Bus bus = new Bus();



        public void AddNewAccount(AccountViewModel account)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.TenDangNhap = account.UserName;
            tk.MatKhau = account.Password;
            tk.Email = account.Email;
            tk.TinhTrang = true;
            tk.MS_PhanQuyen = 1;
            tk.NgayDangKy = DateTime.Today;
            ThanhVien tv = new ThanhVien();
            tv.HoTen = account.UserName;
            tv.DiaChi = account.Address;
            tv.NgaySinh = account.Birthday;
            tv.GioiTinh = account.Sex=="Nam";
            tv.TinhTrang = true;

            bus.AddNewAccount(tk, tv);
        }

        public bool IsExistAccount(string username)
        {
            return bus.IsExistAccount(username);
        }
    }
}