using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitapSitesi.App_Classes
{
    public class UserCart
    {
        public List<Kitaplar> kitapList = new List<Kitaplar>();
        public List<Kitaplar> KitapList
        {
            get
            {
                return kitapList;
            }
            set
            {
                kitapList = new List<Kitaplar>();
            }
        }
    }
}