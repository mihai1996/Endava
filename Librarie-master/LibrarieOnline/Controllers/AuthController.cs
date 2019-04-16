using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibrarieOnline.Models;
using LibrarieOnline.Models.DTO;

namespace LibrarieOnline.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            LibrarieEntities bdContext = new LibrarieEntities();
            var user = bdContext.Users.FirstOrDefault(m =>
                model.UserName.Equals(m.UserName) && m.Password.Equals(model.Password));

            FormsAuthentication.SetAuthCookie(user.UserName, false);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserViewModel model)
        {
            
            LibrarieEntities bdContext = new LibrarieEntities();

            var role = bdContext.UserRoles.FirstOrDefault(m => m.Role.Equals(model.Rolul));

            var rolId = role.RoleId;

            var user = bdContext.Users.Create();
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.RoleId = rolId;

            bdContext.Users.Add(user);
            bdContext.SaveChanges();

            return RedirectToAction("Login");
        }

    }
}