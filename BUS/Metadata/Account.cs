using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    [MetadataType(typeof(AcccountMetadata))]
    public partial class Account
    {

        private class AcccountMetadata
        {
            [Display(Name="Tên đăng nhập")]
            public string Username { get; set; }
        }

    }
}
