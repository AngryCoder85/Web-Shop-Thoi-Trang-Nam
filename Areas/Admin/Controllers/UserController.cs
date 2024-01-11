using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLTClothes.Identity;
using System.Web.Helpers;
using HLTClothes.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using HLTClothes.Filters;

namespace HLTClothes.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDBContext appDBContext = new AppDBContext();
            List<AppUser> userlist = appDBContext.Users.ToList();
            return View(userlist);
        }
        public ActionResult Delete(string id)
        {
            AppDBContext appDBContext = new AppDBContext();
            AppUser deluser = appDBContext.Users.Where(infor => infor.Id == id).FirstOrDefault();
            return View(deluser);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Register register)
        {
            if (ModelState.IsValid)
            {
                var appDBContext = new AppDBContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManager(userStore);
                var pwdhash = Crypto.HashPassword(register.Password);
                var user = new AppUser()
                {
                    Email = register.Email,
                    UserName = register.Username,
                    PasswordHash = pwdhash,
                    PhoneNumber = register.Mobile,
                    Address = register.Address
                };
                IdentityResult identityResult = userManager.Create(user);

                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                }
                return RedirectToAction("Index", "User", new { area = "Admin" });

            }
            ModelState.AddModelError("New Error", "Không hợp lệ");
            return View();
        }



        [HttpPost]
        public ActionResult Delete(string id, AppUser appUser)
        {
            AppDBContext appDBContext = new AppDBContext();
            AppUser deluser = appDBContext.Users.Where(infor => infor.Id == id).FirstOrDefault();
            appDBContext.Users.Remove(deluser);
            appDBContext.SaveChanges();
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }

        public ActionResult Edit(string id)
        {
            AppDBContext appDBContext = new AppDBContext();
            AppUser user = appDBContext.Users.Where(inf => inf.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(AppUser udUser)
        {
            AppDBContext appDBContext = new AppDBContext();
            AppUser user = appDBContext.Users.Where(inf => inf.Id == udUser.Id).FirstOrDefault();
            user.UserName = udUser.UserName;
            user.Email = udUser.Email;
            user.PhoneNumber = udUser.PhoneNumber;
            user.Address = udUser.Address;
            appDBContext.SaveChanges();
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}