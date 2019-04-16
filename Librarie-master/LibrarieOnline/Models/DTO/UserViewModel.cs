using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Models.DTO
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rolul { get; set; }
    }
}


//https://techbrij.com/custom-roleprovider-authorization-asp-net-mvc