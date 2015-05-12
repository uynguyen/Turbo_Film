using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Turbo_Phim.Controllers
{
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
    }
}