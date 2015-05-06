using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [MetadataType(typeof(PhimMetadata))]
    public partial class Phim
    {
        private class PhimMetadata
        {
            [Display(Name = "Tên đăng nhập")]
            public string TenPhim { get; set; }
        }
    }
}
