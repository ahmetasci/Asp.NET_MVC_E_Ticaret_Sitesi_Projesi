using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class KategoriController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult bilimKurguKitaplarıView()
        {
            List<Kitaplar> bilimKitapList = pd.Kitaplars.ToList();
            return View(bilimKitapList);
        }
        public ActionResult felsefeKitaplarıView()
        {
            List<Kitaplar> felsefeKitapList = pd.Kitaplars.ToList();
            return View(felsefeKitapList);
        }
        public ActionResult gizemKitaplarıView()
        {
            List<Kitaplar> gizemKitapList = pd.Kitaplars.ToList();
            return View(gizemKitapList);
        }
        public ActionResult kültürKitaplarıView()
        {
            List<Kitaplar> kültürKitapList = pd.Kitaplars.ToList();
            return View(kültürKitapList);
        }
        public ActionResult psikolojiKitaplarıView()
        {
            List<Kitaplar> psikolojiKitapList = pd.Kitaplars.ToList();
            return View(psikolojiKitapList);
        }
        public ActionResult saglikKitaplarıView()
        {
            List<Kitaplar> saglikKitapList = pd.Kitaplars.ToList();
            return View(saglikKitapList);
        }
        public ActionResult sanatKitaplarıView()
        {
            List<Kitaplar> sanatKitapList = pd.Kitaplars.ToList();
            return View(sanatKitapList);
        }
        public ActionResult TarihKitaplarıView()
        {
            List<Kitaplar> tarihKitapList = pd.Kitaplars.ToList();
            return View(tarihKitapList);
        }
    }
}