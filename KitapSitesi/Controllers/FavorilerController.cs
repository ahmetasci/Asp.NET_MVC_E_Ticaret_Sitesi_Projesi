using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KitapSitesi.Controllers
{
    public class FavorilerController : Controller
    {
        ProjeDatabase pd = new ProjeDatabase();
   
        public ActionResult Index()
        {
          
            List<FavoriKitaplar> favkitapList = pd.FavoriKitaplars.ToList();
            var c= pd.aspnet_Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.aspUsers = c.UserId;
            return View(favkitapList);
        }
        [HttpPost]     /**** Ajax ile Favorilerden Kitap Kaldırma için****/
        public ActionResult FavorilerdenKaldır(int id)
        {
            FavoriKitaplar favkitap = pd.FavoriKitaplars.FirstOrDefault(x => x.KitapID == id);
            pd.FavoriKitaplars.Remove(favkitap);
            pd.SaveChanges();
            return RedirectToAction("Index");    
        }
    }
}