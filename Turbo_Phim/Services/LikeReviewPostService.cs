using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;

namespace Turbo_Phim.Services
{
    public class LikeReviewPostService
    {
        public bool LikeReviewPost(string ms_thanhvien, int ms_review)
        {
            LikeReviewPostBus bus = new LikeReviewPostBus();
            return bus.addLikeReviewPost(ms_thanhvien, ms_review);

        }

        public bool isVoted(string user_name, int ms_review)
        {
            LikeReviewPostBus bus = new LikeReviewPostBus();
            return bus.isVoted(user_name, ms_review);

        }
    }
}