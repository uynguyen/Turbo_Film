using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CommentBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();
        public List<BinhLuan> getComments(int IDPost)
        {
            return db.BinhLuan.Where(x => x.MS_BaiNhanXet == IDPost).OrderByDescending(x=>x.NgayDang).ToList();


        }

        public List<BinhLuan> getMyComments(string IDUser)
        {
            return db.BinhLuan.Where(x => x.MS_ThanhVien == IDUser).OrderByDescending(x => x.NgayDang).ToList();
        }
    }
}
