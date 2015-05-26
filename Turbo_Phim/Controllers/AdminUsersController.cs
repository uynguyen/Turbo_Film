using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Turbo_Phim.Controllers
{
     [Authorize(Roles = "Administrator")]
    public class AdminUsersController : Controller
    {
        UserAccountService uas = new UserAccountService();
        // GET: AdminUsers
        public ActionResult Index()
        {
            return View("ListAllAccounts", uas.getAdminManageUserViewModels(0, 0).ToPagedList(1, 6));
        }

        public ActionResult ListAllAccounts(string sortOrder, string currentFilter, string SearchString, string SearchField, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewBag.UserNameSortParm = sortOrder == "UserName" ? "UserName_desc" : "UserName";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.SexSortParm = sortOrder == "Sex" ? "Sex_desc" : "Sex";
            ViewBag.BirthdaySortParm = sortOrder == "Birthday" ? "Birthday_desc" : "Birthday";
            ViewBag.PermissionSortParm = sortOrder == "Permission" ? "Permissionr_desc" : "Permission";
            ViewBag.DayRegisterSortParm = sortOrder == "DayRegister" ? "DayRegister_desc" : "DayRegister";

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }

            ViewBag.CurrentFilter = SearchString;

            var Accounts = uas.getAdminManageUserViewModels(0, 0);

            Accounts = uas.Filter(Accounts, SearchField, SearchString);

            Accounts = uas.Sort(Accounts, sortOrder);

            return View(Accounts.ToPagedList(page ?? 1, 3));
        }


        [HttpPost]
        public async Task<ActionResult> ChangePermission(int id_member, string id_permission)
        {
            Business.AccountBus bus = new Business.AccountBus();
            ApplicationUser user = UserManager.FindById(bus.getUserID(id_member));
           var result = await UserManager.RemoveFromRolesAsync(user.Id, bus.getAllRoleName().ToArray());
           result = await UserManager.AddToRoleAsync(user.Id, bus.getAllRoles().SingleOrDefault(e => e.Id == id_permission).Name);
            if (result.Succeeded)
                return Content("Cấp quyền thành công!");
            else
                return Content("Cấp quyền thất bại!");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user,
                    model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "User Not Found" });
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                    = await UserManager.UserValidator.ValidateAsync(user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    validPass
                        = await UserManager.PasswordValidator.ValidateAsync(password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash =
                            UserManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded
                        && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }


}