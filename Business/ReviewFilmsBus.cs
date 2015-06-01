using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReviewFilmsBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();

        public bool addPost(BaiNhanXet baiNhanXet)
        {
            try
            {
                db.BaiNhanXet.Add(baiNhanXet);
                db.SaveChanges();

                return true;
            }

            catch (Exception e)
            {
               
                return false;
            }
        }

    }
}
