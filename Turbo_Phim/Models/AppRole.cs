using Microsoft.AspNet.Identity.EntityFramework;

namespace Turbo_Phim.Models {
    public class AppRole : IdentityRole {

        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }
}
