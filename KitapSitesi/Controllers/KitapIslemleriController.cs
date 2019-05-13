using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class KitapIslemleriController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
        // GET: KitapIslemleri
        public ActionResult Index()
        {
            List<Kitaplar> kitapList = pd.Kitaplars.ToList();
            return View(kitapList);
        }
        public ActionResult KitapEkle()
        {
            ViewBag.ctgList = pd.Kategorilers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitaplar kitap)
        {
            pd.Kitaplars.Add(kitap);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult KitapSil(int ID)
        {
            Kitaplar kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == ID);
            pd.Kitaplars.Remove(kitap);
            pd.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult KitapGuncelle(int kitapID)
        //{
        //    ViewBag.kitapList = pd.Kitaplars.ToList();
        //    Kitaplar kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == kitapID);
        //    return View(kitap);
        //}
        public ActionResult KitapGuncelle()
        {
            int kID = Convert.ToInt32(Request.QueryString["id"]); //id'yi Querystring ile aldık
            string kName = Request.QueryString["kName"].ToString(); //pName'i aldık.
            string kFrom = Request.QueryString["kFrom"].ToString(); //pFrom'u aldık

            Kitaplar kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == kID);

            ViewBag.kFrom = kFrom; //kFrom'u Viewlarda kullanmak için ViewBag'a attık.

            return View(kitap);
        }

        [HttpPost]
        public ActionResult KitapGuncelle(Kitaplar kitap)
        {
            Kitaplar Kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == kitap.KitapID);
            Kitap.KitapAdi = kitap.KitapAdi;
            Kitap.Kategoriler.KategoriAdi = kitap.Kategoriler.KategoriAdi;
            Kitap.SatisFiyati = kitap.SatisFiyati;
            Kitap.AlisFiyati = kitap.AlisFiyati;
            Kitap.Yazarlar.YazarAdiSoyadi = kitap.Yazarlar.YazarAdiSoyadi;
           
            Kitap.YayinEvi.YayinEviAdi = kitap.YayinEvi.YayinEviAdi;
            Kitap.BasimYili = kitap.BasimYili;
            Kitap.Aciklama = kitap.Aciklama;
            Kitap.EklenmeTarihi = kitap.EklenmeTarihi;

            pd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}