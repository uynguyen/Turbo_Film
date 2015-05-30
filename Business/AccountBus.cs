using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AccountBus
    {
       
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();
          
        // Cập nhật thông tin tài khoản
        public bool updateProfile(string id, ThanhVien member)
        {
            try
            {
                ThanhVien mem = getMemberByUserId(id);
                if (mem != null)
                {
                    mem.HoTen = member.HoTen;
                    mem.NgaySinh = member.NgaySinh;
                    mem.GioiTinh = member.GioiTinh;
                    mem.DiaChi = member.DiaChi;
                    mem.TinhTrang = member.TinhTrang;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

       // Tạo một profile mới cho user
        public ThanhVien createNewProfile(ThanhVien tv)
        {
            try
            {
                db.ThanhVien.Add(tv);
                db.SaveChanges();
                return tv;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);              
                return null;
            }

        }


        public ThanhVien getMemberByUserId(string Id)
        {
            return db.ThanhVien.SingleOrDefault(e => e.MS_TaiKhoan == Id && e.TinhTrang == true);
        }
    }
}
