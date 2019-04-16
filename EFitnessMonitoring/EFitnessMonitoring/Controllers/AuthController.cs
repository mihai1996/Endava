using EFitnessMonitoring.Models;
using EFitnessMonitoring.Models.DTO;
using EFitnessMonitoring.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;

namespace EFitnessMonitoring.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenitcationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Logout()
        {
            AuthenitcationManager.SignOut();

            return RedirectToAction("Login", "Auth");
        }

        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Username, model.Parola);

                if (user == null)
                {
                    ModelState.AddModelError("", "Parola sau Username gresit.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    AuthenitcationManager.SignOut();
                    AuthenitcationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationView model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Virsta = model.Virsta,
                    Gen = model.Gen
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Parola);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "user");
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", "error");
                    }
                }
            }
            return View(model);
        }


        [Authorize(Roles = "admin")]
        public ActionResult GetUsers()
        {
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var role = db.UserRoleIntPks.Include(u => u.User).Include(r => r.Role).ToList();
                return View(role);
            }
        }


        [HttpGet]
        public ActionResult CreateUserRoles()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserRoles(int userId, int roleId)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(userId);
            RoleIntPk role;

            using (FitnessDbContext db = new FitnessDbContext())
            {
                role = db.Roles.Find(roleId);
            }

            if (user != null && role != null)
            {
                await UserManager.AddToRoleAsync(user.Id, role.Name);
            }

            return RedirectToAction("GetUsers", "Auth");
        }

        
        public async Task<ActionResult> Delete(int id )
        {
            FitnessDbContext db = new FitnessDbContext();
            var user = db.UserRoleIntPks.FirstOrDefault(u => u.Id == id);
            ApplicationUser users = await UserManager.FindByIdAsync(user.UserId);


            var result = await UserManager.DeleteAsync(users);
            //var result1 = await UserManager.UpdateAsync(users);
            //db.UserRoleIntPks.Remove(user);
            //db.SaveChanges();

            return RedirectToAction("GetUsers", "Auth");

            
        }

        //[HttpPost]
        //[ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    FitnessDbContext db = new FitnessDbContext();
        //    var user = db.UserRoleIntPks.FirstOrDefault(u => u.Id == id);

        //    db.UserRoleIntPks.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("GetUsers", "Auth");

            //ApplicationUser user = await UserManager.FindByIdAsync(id);
            //if (user != null)
            //{
            //    IdentityResult result = await UserManager.Delete(user);
            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("GetUsers", "Auth");
            //    }
            //}
            //return RedirectToAction("GetUsers", "Auth");

            //}
        //}
    }
}