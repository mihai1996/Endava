using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarieOnline.Models.DTO
{
    public class LoginViewModel
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => _password = value;
        }

    }
}