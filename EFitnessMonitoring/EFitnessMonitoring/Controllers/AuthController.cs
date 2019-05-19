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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using System.Web.Security;
//using Microsoft.Owin.Host.SystemWeb;
namespace EFitnessMonitoring.Controllers
{
    public class AuthController : Controller
    {
        private ApplicationSignInManager _signInManager;

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

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
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

                if (user == null || user.EmailConfirmed == false)
                {
                    ModelState.AddModelError("", "Parola sau Username gresit ");
                    ModelState.AddModelError("", "Emailul nu a fost confirmat.");
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
        ////[HttpPost]
        ////[AllowAnonymous]
        ////[ValidateAntiForgeryToken]
        ////public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await UserManager.FindAsync(model.Username, model.Parola);
        ////        if (user != null)
        ////        {
        ////            if (user.EmailConfirmed == true)
        ////            {
        ////                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        ////                return RedirectToLocal(returnUrl);
        ////            }
        ////            else
        ////            {
        ////                ModelState.AddModelError("", "Не подтвержден email.");
        ////            }
        ////        }
        ////        else
        ////        {
        ////            ModelState.AddModelError("", "Неверный логин или пароль");
        ////        }
        ////    }
        ////    return View(model);
        ////}

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult EmailMesage()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
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
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                   string ccode = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    await UserManager.AddToRoleAsync(user.Id, "user");
                    var callbackUrl = Url.Action("ConfirmEmail", "Auth",
               new { userId = user.Id, code = ccode }, protocol: Request.Url.Scheme);
                    var mailer = new EmailService();
                    await mailer.SendAsync("<a href=\"" + callbackUrl + "\">here</a>", user.Email);

                    return RedirectToAction("EmailMesage", "Auth");//

                    //return RedirectToAction("Login", "Auth");
                }
                AddErrors(result);
                //else
                //{
                //    foreach (string error in result.Errors)
                //    {
                //        ModelState.AddModelError("", "error");
                //    }
                //}
            }
            return View(model);
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Content("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(Convert.ToInt32(userId), code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Auth");//
            }
            AddErrors(result);
            return View();
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
           
            return RedirectToAction("GetUsers", "Auth");

        }

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

       // // GET: /Account/ConfirmEmail
       // [HttpGet]
       ////[AllowHtml]
       // public async Task<ActionResult> ConfirmEmail(string userId, string code)
       // {
       //     if (userId == null || code == null)
       //     {
       //         return View("Error");
       //     }
       //     var id = Convert.ToInt32(userId);
       //     var user = await UserManager.FindByIdAsync(id);

       //     if (user == null)
       //     {
       //         return View("Error");
       //     }
       //     var result = await UserManager.ConfirmEmailAsync(user.Id, code);
       //     return View(result.Succeeded ? "ConfirmEmail" : "Error");
       // }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.StartsWith("Name"))
                {
                    var NameToEmail = Regex.Replace(error, "Name", "Email");
                    ModelState.AddModelError("", NameToEmail);
                }
                else
                {
                    ModelState.AddModelError("", error);
                }
            }
        }

        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        //{
        //    var id = Convert.ToInt32(Token);
        //    ApplicationUser user = this.UserManager.FindById(id);
        //    if (user != null)
        //    {
        //        if (user.Email == Email)
        //        {
        //            user.EmailConfirmed = true;
        //            await UserManager.UpdateAsync(user);
        //            await SignInAsync(user, isPersistent: false);
        //            return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
        //        }
        //        else
        //        {
        //            return RedirectToAction("Confirm", "Account", new { Email = user.Email });
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Confirm", "Account", new { Email = "" });
        //    }

        //}
    }
}