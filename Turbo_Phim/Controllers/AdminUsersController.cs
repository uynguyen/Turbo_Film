using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turbo_Phim.Models;
using PagedList;
using PagedList.Mvc;

namespace Turbo_Phim.Controllers
{
    public class AdminUsersController : Controller
    {
        UserAccountService uas = new UserAccountService();
        // GET: AdminUsers
        public ActionResult Index()
        {
            return View("ListAllAccounts", uas.getSomeAccountView(0, 0).ToPagedList(1, 6));
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

            var Accounts = uas.getSomeAccountView(0, 0);

            Accounts = uas.Filter(Accounts, SearchField, SearchString);

            Accounts = uas.Sort(Accounts, sortOrder);
          
            return View(Accounts.ToPagedList(page ?? 1, 2));
        }


        [HttpPost]
        public ActionResult ChangePermission(int id_member, int id_permission)
        {
            uas.ChangePermission(id_member, id_permission);
            return View("ListAllAccounts");
        }

    }


}