using librarieonline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace librarieonline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Books()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "Luceafarul",
                    Author =  "M. Eminescu",
                    Description = "Drama"
                },
                 new Book()
                {
                    Id = 2,
                    Name = "Mama",
                    Author =  "G. Vieru",
                    Description = "Family"
                 }
            };
            return View(books);
        }

        public ActionResult Person()
        {
            ViewBag.people = new List<Person>()
            {
                new Person()
                {
                    Name = "Pavel",
                    Surname = "Filip",
                    Age = 42,
                    Profession = "Deputat"
                },

                new Person()
                {
                    Name = "Ion",
                    Surname = "Balmus",
                    Age = 68,
                    Profession = "Decan"
                },

                new Person()
                {
                    Name = "Ernest",
                    Surname = "Bitca",
                    Age = 22,
                    Profession = "Student"
                }
            };

            return View();
        }
    }
}
       