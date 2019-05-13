using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class KategoriIslemleriController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
        // GET: KategoriIslemleri
        public ActionResult Index()
        {
            List<Kategoriler> kategoriList = pd.Kategorilers.ToList();
            return View(kategoriList);
        }
        public ActionResult KategoriEkle()
        {
            ViewBag.kategoriList = pd.Kategorilers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler kategori)
        {
            pd.Kategorilers.Add(kategori);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult KategoriSil(int ID)
        {                                              /*Ajax ile silme için*/
            Kategoriler kategori = pd.Kategorilers.FirstOrDefault(x => x.KategoriID == ID);
            pd.Kategorilers.Remove(kategori);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGuncelle(int katID)
        {
            ViewBag.kategoriList = pd.Kategorilers.ToList();
            Kategoriler kategori = pd.Kategorilers.FirstOrDefault(x => x.KategoriID == katID);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategoriler Kategori)
        {
            Kategoriler kategori = pd.Kategorilers.FirstOrDefault(x => x.KategoriID == Kategori.KategoriID);
            kategori.KategoriAdi = Kategori.KategoriAdi;
          

            pd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}