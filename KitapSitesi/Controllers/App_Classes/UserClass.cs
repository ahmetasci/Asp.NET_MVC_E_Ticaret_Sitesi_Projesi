using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitapSitesi.App_Classes
{
    public class UserClass
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
    }
}