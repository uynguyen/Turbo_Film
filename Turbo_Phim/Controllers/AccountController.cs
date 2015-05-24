using System.Threading.Tasks;
using System.Web.Mvc;
using Turbo_Phim.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Turbo_Phim.Infrastructure;
using System.Web;

namespace Turbo_Phim.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        Models.UserAccountService uas = new Models.UserAccountService();

        [HttpPost]
        public JsonResult doesUserNameExist(string username)
        {
            return Json(!uas.IsExistAccount(username));
        }

     

        public ActionResult Register()
        {
            return View(new Models.AccountViewModel());
        }

        [HttpPost]
        public ActionResult Register(Models.AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                uas.AddNewAccount(account);
                return View("RegisterSuccess", account);
            }
            account = null;
            return View("RegisterSuccess", account);
        }

        [HttpGet]
        public ActionResult RegisterSuccess(Models.AccountViewModel account)
        {           
            return View(account);
        }

        public ActionResult EditAccount()
        {
            return View(uas.getSomeAccountView(1, 1).First());          // Test code
        }

        [HttpPost]
        public ActionResult EditAccount(Models.AccountViewModel account)
        {
          
                uas.UpdateAccount(account);

                return RedirectToAction("Index", "Home");
         
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user,
                    model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return PartialView(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(details.Name,
                    details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}