using LibrarieOnline.Models;
using LibrarieOnline.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarieOnline.Controllers
{
    public class BookController : Controller
    {   
        LibrarieEntities db = new LibrarieEntities();
        
        // GET: Book
        [Authorize (Roles = "admin")]
        public ActionResult UploadBook()
        {
            DataBookView data = new DataBookView();
            data.Authors = db.Authors.ToList();
            data.Categories = db.Categories.ToList();
            data.Publishers = db.Publishers.ToList();

            return View(data);
        }
        [HttpPost]
        public ActionResult UploadBook(DataBookView data)
        {
            var autor = db.Authors.FirstOrDefault(a => a.AuthorId.Equals(data.Authors));

            return View();
        }
    }
}