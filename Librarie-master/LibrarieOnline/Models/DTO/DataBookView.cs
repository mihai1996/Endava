using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Models.DTO
{
    public class DataBookView
    {
        public List<Author>Authors { get; set; }
        public List<Category>Categories { get; set; }
        public List<Publisher> Publishers { get; set; }

    }
}