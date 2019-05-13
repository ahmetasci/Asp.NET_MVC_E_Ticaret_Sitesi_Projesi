using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Index()
        {
            ProjeDatabase pd = new ProjeDatabase();
            List<Kitaplar> kitapList = pd.Kitaplars.ToList();
            return View(kitapList);
        }
    }
}