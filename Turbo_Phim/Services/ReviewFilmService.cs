using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using Turbo_Phim.Models;
namespace Turbo_Phim.Services
{
    public class ReviewFilmService
    {
        internal bool addPost(Business.BaiNhanXet baiNhanXet)
        {
            ReviewFilmsBus bus = new ReviewFilmsBus();
            return bus.addPost(baiNhanXet);
        }

        internal TopReviewModels getTopReview(String IDPhim)
        {
            ReviewFilmsBus bus = new ReviewFilmsBus();
            BaiNhanXet topReview = bus.getTopReview(Int32.Parse(IDPhim));
            if (topReview != null)
            {
                return BaiNhanXet2BaiNhanXetViewModels(topReview);
            }
            else
                return null;
            
        }

        public TopReviewModels BaiNhanXet2BaiNhanXetViewModels(BaiNhanXet topReview)
        {
            
            AccountBus acBus = new AccountBus();
              ReviewFilmsBus bus = new ReviewFilmsBus();
            ThanhVien temp = acBus.getMemberByUserId(topReview.MS_TaiKhoan);

            TopReviewModels result = new TopReviewModels();

            result.UserName = temp.HoTen;
            result.postDate = (DateTime) topReview.NgayDang;

            result.content = topReview.NoiDung;
            result.totalRank = bus.getTotalRank(topReview.MaSo);

            result.title = topReview.TieuDe;
            result.MS_Phim = (int) topReview.MS_Phim;
            result.MS_ReView = (int) topReview.MaSo;




            return result;
        }

        internal List<TopReviewModels> getTop10Review(string IDPhim)
        {
            ReviewFilmsBus bus = new ReviewFilmsBus();
            List<BaiNhanXet> topReview = bus.getTop10Review(Int32.Parse(IDPhim));
            if (topReview != null)
            {

                List<TopReviewModels> result = new List<TopReviewModels>();
                foreach(BaiNhanXet bai in topReview){
                    TopReviewModels temp =  BaiNhanXet2BaiNhanXetViewModels(bai);
                    result.Add(temp);
                }



                return result;
            }
            else
                return null;
        }

        internal TopReviewModels getReview(string IDReview)
        {

            ReviewFilmsBus bus = new ReviewFilmsBus();
            BaiNhanXet Review = bus.getReview(Int32.Parse(IDReview));
            if (Review != null)
            {
                return BaiNhanXet2BaiNhanXetViewModels(Review);
            }
            else
                return null;
        }
    }
}