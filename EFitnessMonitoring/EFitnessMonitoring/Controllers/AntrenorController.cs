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
    public class AntrenorController : Controller
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
        // GET: Antrenor
       
        [Authorize(Roles = "antrenor")]
        public ActionResult AntrenorMode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AntrenorMode(ArticleView model)
        {
            if (ModelState.IsValid)
            {
                using (FitnessDbContext db = new FitnessDbContext())
                {
                    string currentUserId = User.Identity.GetUserId();
                    var a = Convert.ToInt32(currentUserId);
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id.Equals(a));
                
                DomeniuSport sport = new DomeniuSport
                    {
                        Nume_exercitiu = model.Nume_exercitiu,
                        Image = model.Image,
                        Descriere = model.Descriere,
                        Id_muschi = model.Id_muschi,
                        UserId = a
                    };
                    db.DomeniuSports.Add(sport);
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult Atrenamente()
        {
          using(FitnessDbContext db = new FitnessDbContext())
            {
                var a = db.DomeniuSports.Include(r => r.ClasaMuschi).ToList();
                return View(a);
               
            }

        }

        public ActionResult ShowAntrenamente(string id)
        {
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var idd = Convert.ToInt32(id);
                var d = db.DomeniuSports.FirstOrDefault(m => m.Id_exercitiu == idd);
   
                return View(d);
            }
        }
        [Authorize(Roles = "antrenor")]
        public ActionResult CreateGrafic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGrafic(GraficView model)
        {
            if (ModelState.IsValid)
            {

                using (FitnessDbContext db = new FitnessDbContext())
                {
                    string currentUserId = User.Identity.GetUserId();
                    var a = Convert.ToInt32(currentUserId);
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id.Equals(a));



                    GraficAntrenament grafic = new GraficAntrenament
                    {
                        Titlu = model.Titlu,
                        Image = model.Image,
                        Descriere = model.Descriere,
                        Id_antrenament = model.Id_antrenament,
                        UserId = a

                    };
                    
                    db.GraficAntrenaments.Add(grafic);
                    db.SaveChanges();

                }
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult GetCardGrafic()
        {
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var a = db.GraficAntrenaments.Include(r => r.DomeniuAntrenamente).ToList();
                return View(a);

            }

        }

        public ActionResult ShowGrafic(string id)
        {
            
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var idd = Convert.ToInt32(id);
                var d = db.GraficAntrenaments.FirstOrDefault(m => m.Id_grafic == idd);

                return View(d);
            }
        }

        [Authorize(Roles = "antrenor")]
        public ActionResult CreateSanatate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSanatate(SanatateView model)
        {
            if (ModelState.IsValid)
            {

                using (FitnessDbContext db = new FitnessDbContext())
                {
                    string currentUserId = User.Identity.GetUserId();
                    var a = Convert.ToInt32(currentUserId);
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id.Equals(a));



                    Medicina med = new Medicina
                    {
                        Nume_maladie = model.Nume_maladie,
                        Image = model.Image,
                        Descriere = model.Descriere,
                        Id_categorie = model.Id_categorie,
                        UserId = a

                    };

                    db.Medicinas.Add(med);
                    db.SaveChanges();

                }
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult GetCardSanatate()
        {
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var a = db.Medicinas.Include(r => r.DomeniuSanatate).ToList();
                return View(a);

            }

        }

        public ActionResult ShowSanatate(string id)
        {

            using (FitnessDbContext db = new FitnessDbContext())
            {
                var idd = Convert.ToInt32(id);
                var d = db.Medicinas.FirstOrDefault(m => m.Id_maladie == idd);

                return View(d);
            }
        }

        [Authorize(Roles = "antrenor")]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProduseView model)
        {
            if (ModelState.IsValid)
            {

                using (FitnessDbContext db = new FitnessDbContext())
                {
                    string currentUserId = User.Identity.GetUserId();
                    var a = Convert.ToInt32(currentUserId);
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id.Equals(a));



                    Produse product = new Produse
                    {
                        Nume_produs = model.Nume_produs,
                        Image = model.Image,
                        Linq = model.Linq,
                        Id_category = model.Id_category,
                        UserId = a

                    };

                    db.Produses.Add(product);
                    db.SaveChanges();

                }
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult GetCardProduct()
        {
            using (FitnessDbContext db = new FitnessDbContext())
            {
                var a = db.Produses.Include(r => r.ProduseCategory).ToList();
                return View(a);

            }

        }

    }
}


        