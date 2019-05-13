using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class YayıneviController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
        // GET: Yayınevi
        public ActionResult Index()
        {
            List<YayinEvi> yayineviList = pd.YayinEvis.ToList();
            return View(yayineviList);
        }

        public ActionResult YayıneviEkleme()
        {
            ViewBag.yayineviList = pd.YayinEvis.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult YayıneviEkleme(YayinEvi yayinevi)
        {
            pd.YayinEvis.Add(yayinevi);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult YayıneviSil(int ID)
        {                                              /*Ajax ile silme için*/
            YayinEvi yayınevi = pd.YayinEvis.FirstOrDefault(x => x.YayinEviID == ID);
            pd.YayinEvis.Remove(yayınevi);
            pd.SaveChanges();
            return RedirectToAction("Index");  /*Silme işleminden sonra Index View'ını çalıştır'*/
        }
        public ActionResult YayıneviGuncelle(int yayineviID)
        {
            ViewBag.yayineviList = pd.YayinEvis.ToList();
            YayinEvi yayinEvi = pd.YayinEvis.FirstOrDefault(x => x.YayinEviID == yayineviID);
            return View(yayinEvi);
        }
        [HttpPost]
        public ActionResult YayıneviGuncelle(YayinEvi yayinevi)
        {
            YayinEvi yayin = pd.YayinEvis.FirstOrDefault(x => x.YayinEviID == yayinevi.YayinEviID);
            yayin.YayinEviAdi = yayinevi.YayinEviAdi;
            yayin.Adres = yayinevi.Adres;

            pd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}