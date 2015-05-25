using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AccountBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();

      

        // Kiểm tra tên đăng nhập có tồn tại hay chưa?
        public bool IsExistAccount(string username)
        {
            return db.AspNetUsers.Where(e => e.Email == username).Count() > 0;
        }

        // Lấy một số thành viên theo phân trang
        public List<ThanhVien> getSomeMembers(int page, int MemPerPage)
        {
            if (page == 0 && MemPerPage == 0)
                return db.ThanhVien.Where(e => e.TinhTrang == true).ToList();

            return db.ThanhVien.Where(x => x.TinhTrang == true).OrderBy(x => x.MaSo)
                .Skip(page * MemPerPage - MemPerPage).Take(MemPerPage).ToList();
        }

        // Lấy thông tin tài khoản của thành viên
        public AspNetUsers getAccount(string id)
        {
            return db.AspNetUsers.SingleOrDefault(e => e.Id == id);
        }

        // Lấy thông tin thành viên
        public ThanhVien getMember(int? id)
        {
            return db.ThanhVien.SingleOrDefault(e => e.MaSo == id && e.TinhTrang == true);
        }

        // Lấy quyền của tài khoản
        public AspNetRoles getPermission(string id)
        {
            return db.AspNetRoles.SingleOrDefault(e => e.Id == id);
        }

        // Thay đổi quyền của một tài khoản
        public bool changePermission(int idAccount, int idPermission)
        {
            try
            {
                
            }
            catch (Exception)
            {
                return false;

            }
            return false;
        }

        // Cập nhật thông tin tài khoản
        public bool updateProfile(int idMember, ThanhVien member)
        {
            try
            {
                ThanhVien mem = getMember(idMember);
                if (mem != null)
                {
                    mem.HoTen = member.HoTen;
                    mem.NgaySinh = member.NgaySinh;
                    mem.GioiTinh = member.GioiTinh;
                    mem.DiaChi = member.DiaChi;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }




        public bool AddNewAccount(ThanhVien tv)
        {
            try
            {
                db.ThanhVien.Add(tv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public List<AspNetRoles> getAllRoles()
        {
            return db.AspNetRoles.ToList();
        }

        public string getEmail(ThanhVien mem)
        {
            var user = db.AspNetUsers.SingleOrDefault(e => e.Id == mem.MS_TaiKhoan);
            if (user != null) return user.Email;
            return "";
        }

        public string getRoleID(ThanhVien mem)
        {
            var userrole = db.AspNetUserRoles.SingleOrDefault(e => e.UserId == mem.MS_TaiKhoan);
            if (userrole != null)
                return userrole.RoleId;
            return "";
        }

        public string getUserID(ThanhVien mem)
        {
            return mem.MS_TaiKhoan;
        }

        public void changePermission(string p, string id_pm)
        {
            AspNetUserRoles r = new AspNetUserRoles();
            r.RoleId = id_pm;
            r.UserId = p;
            r.Id = "nope";
            db.AspNetUserRoles.Add(r);
            db.SaveChanges();

        }
    }
}
