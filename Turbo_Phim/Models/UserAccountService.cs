using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
namespace Turbo_Phim.Models
{
    public class UserAccountService
    {
        AccountBus bus = new AccountBus();


        // Thêm một tài khoản và thành viên
        public void AddNewAccount(ApplicationUser user, RegisterViewModel account)
        {           
            ThanhVien tv = new ThanhVien();
            tv.HoTen = account.Name;
            tv.DiaChi = account.Address;
            tv.NgaySinh = account.Birthday;
            tv.MS_TaiKhoan = user.Id;
            tv.TinhTrang = true;
            tv.NgayDangKy = DateTime.Today;
            bus.AddNewAccount(tv);
        }


        // Kiểm tra một tài khoản có tồn tại hay không?
        public bool IsExistAccount(string username)
        {
            return bus.IsExistAccount(username);
        }


        // Lấy một số tài khoản
        public List<AdminManageUserViewModel> getAdminManageUserViewModels(int page, int AccPerPage)
        {
            List<AdminManageUserViewModel> result = new List<AdminManageUserViewModel>();
            var members = bus.getSomeMembers(page, AccPerPage);
            foreach (ThanhVien mem in members)
            {              
                AdminManageUserViewModel viewModal = new AdminManageUserViewModel();
                viewModal.Address = mem.DiaChi;
                viewModal.Name = mem.HoTen;
                viewModal.Birthday = mem.NgaySinh;
                viewModal.Email = bus.getEmail(mem);
                viewModal.DayRegister = mem.NgayDangKy;
                viewModal.ID = bus.getUserID(mem);
                viewModal.ID_Role = bus.getRoleID(mem);
                viewModal._gender = mem.GioiTinh ?? true;            
                viewModal.ID_Member = mem.MaSo;
                result.Add(viewModal);
            }
           
            return result;
        }

        public void ChangeRole(int id_member, string id_pm)
        {
            ThanhVien mem = bus.getMember(id_member);

            bus.changePermission(mem.MS_TaiKhoan, id_pm);          
        }


        public List<AdminManageUserViewModel> Filter(List<AdminManageUserViewModel> Accounts, string SearchField, string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                switch (SearchField)
                {
                    case "Tên đăng nhập": Accounts = Accounts.Where(s => s.Email.Contains(SearchString)).ToList(); break;
                    case "Email": Accounts = Accounts.Where(s => s.Email.Contains(SearchString)).ToList(); break;
                    case "Họ và tên": Accounts = Accounts.Where(s => s.Name.Contains(SearchString)).ToList(); break;
                    case "Ngày đăng ký": Accounts = Accounts.Where(s => s.DayRegister.Value
                        .ToShortDateString().Contains(SearchString)).ToList(); break;
                    default:
                        break;
                }
            }
            return Accounts;
        }

        public List<AdminManageUserViewModel> Sort(List<AdminManageUserViewModel> Accounts, string sortOrder)
        {
            switch (sortOrder)
            {
                case "ID_desc": Accounts = Accounts.OrderByDescending(c => c.ID_Member).ToList(); break;
                case "UserName": Accounts = Accounts.OrderBy(c => c.Email).ToList(); break;
                case "UserName_desc": Accounts = Accounts.OrderByDescending(c => c.Email).ToList(); break;
                case "Email": Accounts = Accounts.OrderBy(c => c.Email).ToList(); break;
                case "Email_desc": Accounts = Accounts.OrderByDescending(c => c.Email).ToList(); break;
                case "Name": Accounts = Accounts.OrderBy(c => c.Name).ToList(); break;
                case "Name_desc": Accounts = Accounts.OrderByDescending(c => c.Name).ToList(); break;
                case "Sex": Accounts = Accounts.OrderBy(c => c.Gender).ToList(); break;
                case "Sex_desc": Accounts = Accounts.OrderByDescending(c => c.Gender).ToList(); break;
                case "Birthday": Accounts = Accounts.OrderBy(c => c.Birthday).ToList(); break;
                case "Birthday_desc": Accounts = Accounts.OrderByDescending(c => c.Role).ToList(); break;
                case "Permission": Accounts = Accounts.OrderBy(c => c.Birthday).ToList(); break;
                case "Permission_desc": Accounts = Accounts.OrderByDescending(c => c.Role).ToList(); break;
                case "DayRegister": Accounts = Accounts.OrderBy(c => c.DayRegister).ToList(); break;
                case "DayRegister_desc": Accounts = Accounts.OrderByDescending(c => c.DayRegister).ToList(); break;

                default: Accounts = Accounts.OrderBy(c => c.ID_Member).ToList(); break;
            }
            return Accounts;
        }

        public void UpdateAccount(string id, UpdateProfileViewModal model)
        {
            ThanhVien tv = new ThanhVien();
            tv.HoTen = model.Name;
            tv.NgaySinh = model.Birthday;
            tv.GioiTinh = model.IsMale;
            tv.DiaChi = model.Address;
            bus.updateProfile(id, tv);
        }

        public UpdateProfileViewModal GetUpdateProfileViewModal(string userID)
        {
            var tv = bus.getMemberFromUserID(userID);
            UpdateProfileViewModal model = new UpdateProfileViewModal();
            model.Email = bus.getAccount(userID).Email;
            model.IsMale = tv.GioiTinh ?? true;
            model.Name = tv.HoTen;
            model.Birthday = tv.NgaySinh;
            model.Address = tv.DiaChi;

            return model;
        }
    }
}