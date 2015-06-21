using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReviewFilmsBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();

        public int addPost(BaiNhanXet baiNhanXet)
        {
            try
            {
                BaiNhanXet result = db.BaiNhanXet.Add(baiNhanXet);
                db.SaveChanges();

                return result.MaSo;
            }

            catch (Exception e)
            {

                return -1;
            }
        }


        public BaiNhanXet getTopReview(int IDPhim)
        {

            try
            {
                List<BaiNhanXet> lstReviews = db.BaiNhanXet.Where(x => x.MS_Phim == IDPhim).ToList();

                int flag = 0;

                int MS0 = lstReviews[0].MaSo;
                int temp = db.BinhChon.Where(y => y.MS_BaiNhanXet == MS0).ToList().Count;





                for (int i = 1; i < lstReviews.Count; i++)
                {
                    int MS = lstReviews[i].MaSo;
                    int tmp2 = db.BinhChon.Where(x => x.MS_BaiNhanXet == MS).ToList().Count;


                    if (tmp2 > temp)
                    {
                        temp = tmp2;
                        flag = i;
                    }


                }

                return lstReviews[flag];



            }

            catch (Exception e)
            {
                return null;

            }

        }

        public int getTotalRank(int? IDBaiNhanXet)
        {
            return db.BinhChon.Where(x => x.MS_BaiNhanXet == IDBaiNhanXet).Count();
        }

        public List<BaiNhanXet> getTop10Review(int IDPhim)
        {
            List<BaiNhanXet> result = new List<BaiNhanXet>();
            try
            {
                List<BaiNhanXet> lstReviews = db.BaiNhanXet.Where(x => x.MS_Phim == IDPhim).ToList();

                Dictionary<BaiNhanXet, int> Rank = new Dictionary<BaiNhanXet, int>();

                for (int i = 0; i < lstReviews.Count; i++)
                {

                    int MS = lstReviews[i].MaSo;
                    int tmp = db.BinhChon.Where(x => x.MS_BaiNhanXet == MS).ToList().Count;
                    Rank.Add(lstReviews[i], tmp);

                }


                foreach (KeyValuePair<BaiNhanXet, int> author in Rank.OrderByDescending(key => key.Value))
                {
                    result.Add(author.Key);
                }
               
                   
                
                return result;


            }

            catch (Exception e)
            {
                return null;

            }













        }

        public BaiNhanXet getReview(int p)
        {
            return db.BaiNhanXet.Where(x => x.MaSo == p).FirstOrDefault();
        }

        public List<BaiNhanXet> getMyListReview(String p)
        {
            return db.BaiNhanXet.Where(x => x.MS_TaiKhoan.Equals(p) && x.TinhTrang == true).ToList();
        }

        public bool editPost(BaiNhanXet baiNhanXet)
        {
            try
            {
                db.Entry(baiNhanXet).State = EntityState.Modified;
                db.SaveChanges();


                return true;
            }
            catch (Exception e)
            {
             
                return false;
            }
        }

        public bool deletePost(int IDPost)
        {
            try
            {
                BaiNhanXet temp = db.BaiNhanXet.Where(x => x.MaSo == IDPost).FirstOrDefault();
                temp.TinhTrang = false;
               

                List<BinhChon> lstBinhChon = db.BinhChon.ToList();
                foreach (BinhChon binhChon in lstBinhChon) //Đánh dấu bỏ những bài bình chọn liên quan
                {
                    if (binhChon.MS_BaiNhanXet == IDPost)
                    {
                        binhChon.TinhTrang = false;
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool addComment(BinhLuan binhLuan)
        {
            try
            {
                db.BinhLuan.Add(binhLuan);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public List<BaiNhanXet> getAllReviewFilm()
        {
            try
            {
                return db.BaiNhanXet.Where(X => X.TinhTrang == true).ToList();
               
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
