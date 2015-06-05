using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turbo_Phim.Models
{
    public class CommentViewModels
    {
        public string url_Avatar { get; set; }
        public string content { get; set; }
        public DateTime datePost { get; set; }

        public string fullName { get; set; }
    }
}