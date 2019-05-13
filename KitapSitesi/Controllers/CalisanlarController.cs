using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        ProjeDatabase pd = new ProjeDatabase();
        // GET: Calisanlar
        public ActionResult Index()
        {
            List<Calisanlar> calisanList = pd.Calisanlars.ToList();
            return View(calisanList);
        }
        public ActionResult CalisanEkle()
        {
            ViewBag.calisanList = pd.Calisanlars.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CalisanEkle(Calisanlar calisan)
        {
            pd.Calisanlars.Add(calisan);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult KargoSil(int ID)
        {                                              /*Ajax ile silme için*/
            Kargo kargo = pd.Kargoes.FirstOrDefault(x => x.KargoID == ID);
            pd.Kargoes.Remove(kargo);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoGuncelle(int kargoID)
        {
            ViewBag.kargoList = pd.Kargoes.ToList();
            Kargo kargo = pd.Kargoes.FirstOrDefault(x => x.KargoID == kargoID);
            return View(kargo);
        }
        [HttpPost]
        public ActionResult KargoGuncelle(Kargo Kargo)
        {
            Kargo kargo = pd.Kargoes.FirstOrDefault(x => x.KargoID == Kargo.KargoID);
            kargo.SirketAdi = Kargo.SirketAdi;
            kargo.TeslimatSuresi = Kargo.TeslimatSuresi;
            kargo.KargoFiyati = Kargo.KargoFiyati;
            kargo.Adres = Kargo.Adres;
            kargo.Telefon = Kargo.Telefon;
            kargo.WebSite = Kargo.WebSite;



            pd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}