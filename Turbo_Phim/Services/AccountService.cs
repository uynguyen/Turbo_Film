using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using Turbo_Phim.Models;

namespace Turbo_Phim.Services
{
    public class AccountService   
    {
        private AccountBus bus = new AccountBus();

        public bool CreateProfile(ApplicationUser user, RegisterViewModel model)
        {
            ThanhVien member = new ThanhVien();
            member.TinhTrang = true;
            member.HoTen = model.Name;
            member.NgaySinh = model.Birthday;
            member.DiaChi = model.Address;
            member.GioiTinh = model.IsMale;
            member.MS_TaiKhoan = user.Id;
            member = bus.createNewProfile(member);
            if (member != null)
            {             
                return true;
            }
            return false;
        }

        public UpdateProfileViewModal GetUpdateProfileViewModal(string Id)
        {
            ThanhVien member = bus.getMemberByUserId(Id);
            if (member == null) return null;
            UpdateProfileViewModal model = new UpdateProfileViewModal();
            model.IsMale = member.GioiTinh ?? true;
            model.Name = member.HoTen;
            model.Birthday = member.NgaySinh;
            model.Address = member.DiaChi;

            return model;
        }

        public bool UpdateAccount(string id, UpdateProfileViewModal model)
        {
            ThanhVien tv = new ThanhVien();
            tv.HoTen = model.Name;
            tv.NgaySinh = model.Birthday;
            tv.GioiTinh = model.IsMale;
            tv.DiaChi = model.Address;
            return bus.updateProfile(id, tv);
        }
    }
}