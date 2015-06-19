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
            model.Avatar = member.Avatar;
            return model;
        }

        public bool UpdateAccount(string id, UpdateProfileViewModal model)
        {
            ThanhVien tv = new ThanhVien();
            tv.HoTen = model.Name;
            tv.NgaySinh = model.Birthday;
            tv.GioiTinh = model.IsMale;
            tv.DiaChi = model.Address;
            tv.TinhTrang = true;
            tv.Avatar = model.Avatar;
            return bus.updateProfile(id, tv);
        }

        public List<HistoryViewModels> getActivitiesLog(string IDUser)
        {
            //ReviewFilmsBus reviewFilmsBus = new ReviewFilmsBus();
            List<HistoryViewModels> result = new List<HistoryViewModels>();

            CommentBus commentBus = new CommentBus();

            ReviewFilmsBus reviewBus = new ReviewFilmsBus();
            AccountBus accBus = new AccountBus();
            FilmBus filmBus = new FilmBus();
            ThanhVien thanhVien = accBus.getMemberByUserId(IDUser);

            List<BinhLuan> lstBinhLuan = commentBus.getMyComments(IDUser);

          


            foreach (BinhLuan binhLuan in lstBinhLuan)
            {

                HistoryViewModels temp = new HistoryViewModels();

                BaiNhanXet baiNhanXet = reviewBus.getReview((int)binhLuan.MS_BaiNhanXet);
                Phim phim = filmBus.getFilmByID(baiNhanXet.MS_Phim.ToString());

                temp.tenBaiNhanXet = baiNhanXet.TieuDe;
                temp.MS_BaiNhanXet = (int)binhLuan.MS_BaiNhanXet;
                temp.tenPhim = phim.TenPhim;
                temp.MS_Phim = (int)phim.MaSo;
                temp.action = "Comment";
                temp.Hoten = thanhVien.HoTen;
                temp.content = binhLuan.NoiDung;
                temp.dateAction = (DateTime)  binhLuan.NgayDang;
                result.Add(temp);


            }

            FilmLikeBus filmLikeBus = new FilmLikeBus();

            List<DanhSachPhimYeuThich> lstPhimYeuThich = filmLikeBus.getMyListFilmLike(IDUser);

         
            foreach (DanhSachPhimYeuThich phimYeuThich in lstPhimYeuThich)
            {

                HistoryViewModels temp = new HistoryViewModels();

                Phim p = filmBus.getFilmByID(phimYeuThich.MS_Phim.ToString());
                temp.tenPhim = p.TenPhim;
                temp.MS_Phim = p.MaSo;
                temp.Hoten = thanhVien.HoTen;
                temp.action = "Like";
                temp.content = thanhVien.HoTen + " đã thích " + p.TenPhim;
                temp.dateAction = (DateTime)phimYeuThich.ThoiGian;
                result.Add(temp);


            }

         
            List<BaiNhanXet> lstNhanXet = reviewBus.getMyListReview(IDUser);

            foreach (BaiNhanXet baiNhanXet in lstNhanXet)
            {

                HistoryViewModels temp = new HistoryViewModels();
                Phim p = filmBus.getFilmByID(baiNhanXet.MS_Phim.ToString());
                temp.tenPhim = p.TenPhim;
                temp.MS_Phim = p.MaSo;
                temp.tenBaiNhanXet = baiNhanXet.TieuDe;
                temp.MS_BaiNhanXet = baiNhanXet.MaSo;
                temp.Hoten = thanhVien.HoTen;
                temp.action = "Post";
                temp.content = thanhVien.HoTen + " đã thêm bài nhận xét ...." + baiNhanXet.MS_Phim;
                temp.dateAction = (DateTime)baiNhanXet.NgayDang;
                result.Add(temp);


            }

            result.Sort((x, y) => y.dateAction.CompareTo(x.dateAction));
            

            return result;
           
        }

    }
}