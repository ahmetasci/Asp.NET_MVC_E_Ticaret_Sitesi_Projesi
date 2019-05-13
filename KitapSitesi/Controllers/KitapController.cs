using KitapSitesi.App_Classes;
using KitapSitesi.Controllers.App_Classes;
using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KitapSitesi.Controllers
{
    public class KitapController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
        // GET: Kitap
        public ActionResult Index()
        {
            List<Kitaplar> kitapList = pd.Kitaplars.ToList();
            return View(kitapList);
        }
        [HttpPost]
        public string SepeteEkle(int id)
        {
            UserCart uc;
            if (Session["CurrentCart"] == null)    /*Her istek attığımızda Session açılır. Eklediğimiz her ürünü sepet gibi Session'a atar'*/
            {
                uc = new UserCart();
            }
            else
            {
                uc = (UserCart)Session["CurrentCart"]; //Ürünlerin listesini UserCart'ta tuttuğum için UserCart'a convert ettik.
            }
            //Önce uc'ye ekliyoruz. Dolayısıyla CurrentCart adındaki Session'ına ekliyoruz.

            Kitaplar kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == id);
            string messageAddCart = "";
            //Aynı üründen sepette varsa eklememesi için
            foreach (Kitaplar kit in uc.KitapList)
            {
                if (id == kit.KitapID)
                {
                    messageAddCart = "Bu ürün sepetinizde zaten var.";
                    return messageAddCart;
                }
            }
            uc.KitapList.Add(kitap);  // UserChart'a yeni ürünü ekledik.
            Session["CurrentCart"] = uc;
            messageAddCart = "Kitap sepete eklendi";
            return messageAddCart;

        }
       
        [HttpPost]
        public string FavorilereEkleme(int id)
        {
            Kitaplar kitap = pd.Kitaplars.FirstOrDefault(x => x.KitapID == id);
            FavoriKitaplar favkitap = new FavoriKitaplar();
            string message = "";

            var c = pd.aspnet_Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            favkitap.KitapAdi = kitap.KitapAdi;
            favkitap.SatisFiyati = kitap.SatisFiyati;
            favkitap.YazarID = kitap.YazarID;
            favkitap.KategoriID = kitap.KategoriID;
            favkitap.YayinEviID = kitap.YayinEviID;
            favkitap.UserId = c.UserId;
            
            favkitap.BasimYili = kitap.BasimYili;
            favkitap.IndirimOrani = kitap.IndirimOrani;

            pd.FavoriKitaplars.Add(favkitap);
            pd.SaveChanges();
            message = "Kitap favorilere eklendi";
            return message;

        }
        public ActionResult Sepetim()
        {

            return View();
        }
        [HttpPost]     /**** Ajax ile Sepetten Ürün Kaldırma için****/
        public ActionResult SepettenKaldır(int id)
        {
            UserCart uc = new UserCart();
            uc = (UserCart)Session["CurrentCart"];
            Kitaplar ktp = uc.KitapList.FirstOrDefault(x => x.KitapID == id);
            uc.KitapList.Remove(ktp);
            Session["CurrentCart"] = uc;   //Sessionı güncellemek için


            return RedirectToAction("Sepetim");  /*Silme işleminden sonra Sepetim View'ını çalıştır'*/
        }

       
        public ActionResult PartialKitapView()
        {
            UserCart c = (UserCart)Session["CurrentCart"];
            //int n = c.PrdList.Count();
            return PartialView(c.KitapList);
        }

    }
}