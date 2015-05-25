﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turbo_Phim.Models {

    public class CreateModel {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginModel {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }



    public class RoleModificationModel {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

}