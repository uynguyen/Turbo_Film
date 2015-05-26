using System.Threading.Tasks;
using System.Web.Mvc;
using Turbo_Phim.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace Turbo_Phim.Controllers
{
    public class AdminRolesController : Controller
    {
        // GET: AdminRoles
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
    }
}