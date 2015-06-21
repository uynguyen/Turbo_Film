using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class LikeReviewPostBus
    {
       private TURBO_PHIMEntities db = new TURBO_PHIMEntities();
       public bool addLikeReviewPost(string ms_thanhvien, int ms_review)
       {
           try {
               BinhChon bc = db.BinhChon.Where(e => e.MS_ThanhVien == ms_thanhvien && e.MS_BaiNhanXet == ms_review && e.TinhTrang == true).FirstOrDefault();
               if (bc == null)
               {
                   bc = new BinhChon();
                   bc.TinhTrang = true;
                   bc.MS_BaiNhanXet = ms_review;
                   bc.MS_ThanhVien = ms_thanhvien;
                   bc.ThoiGian = DateTime.Today;
                   db.BinhChon.Add(bc);
                   db.SaveChanges();
               }

               return true;
           }
           catch(Exception ex){
               return false;
           }
       }

       public bool isVoted(string user_name, int ms_review)
       {
           try
           {
               AspNetUsers user = db.AspNetUsers.Where(e => e.UserName == user_name).FirstOrDefault();
               if (user == null) return false;

               BinhChon bc = db.BinhChon.Where(e => e.MS_ThanhVien == user.Id && e.MS_BaiNhanXet == ms_review && e.TinhTrang == true).FirstOrDefault();
               if (bc != null)
               {
                   return true;
               }

               return false;
           }
           catch (Exception ex)
           {
               return false;
           }
       }
    }
}
