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

        // Thêm một tài khoản mới
        public bool AddNewAccount(TaiKhoan tk, ThanhVien tv)
        {
            
            try
            {
                tk = db.TaiKhoan.Add(tk);
                tv.MS_TaiKhoan = tk.MaSo;
                db.ThanhVien.Add(tv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Kiểm tra tên đăng nhập có tồn tại hay chưa?
        public bool IsExistAccount(string username)
        {
            return db.TaiKhoan.Where(e => e.TenDangNhap == username && e.TinhTrang == true).Count() > 0;
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
        public TaiKhoan getAccount(int? id)
        {
            return db.TaiKhoan.SingleOrDefault(e => e.MaSo == id && e.TinhTrang == true);
        }

        // Lấy thông tin thành viên
        public ThanhVien getMember(int? id)
        {
            return db.ThanhVien.SingleOrDefault(e => e.MaSo == id && e.TinhTrang == true);
        }

        // Lấy quyền của tài khoản
        public PhanQuyen getPermission(int? id)
        {
            return db.PhanQuyen.SingleOrDefault(e => e.MaSo == id);
        }

        // Thay đổi quyền của một tài khoản
        public bool changePermission(int idAccount, int idPermission)
        {
            try
            {
                TaiKhoan tk = getAccount(idAccount);
                if (tk != null)
                {
                    tk.MS_PhanQuyen = idPermission;
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



        public List<PhanQuyen> getAllPermissions()
        {
            return db.PhanQuyen.ToList();
        }
    }
}
