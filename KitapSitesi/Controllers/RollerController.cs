using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KitapSitesi.Controllers
{
    public class RollerController : Controller
    {
        public ActionResult Index()
        {
            //Sistemde tanımlı bütün rolleri çekmek için
            List<string> roleList = Roles.GetAllRoles().ToList();

            return View(roleList);
        }
        public ActionResult RolEkle(string message = null)
        { //string message=null=> eğer hiç birşey girilmezse değeri null olarak al. string message=Ahmet dersek değeri Ahmet alır.

            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        [ActionName("RolEkle")]
        public ActionResult RolEklePost(string RoleName)
        {
            if (string.IsNullOrWhiteSpace(RoleName)) //eğer birşey girilmediyse 
            {
                return RedirectToAction("RolEkle", new { message = "Rol boş olamaz." });
            }
            if (Roles.RoleExists(RoleName)) //Varolan bir Role girildiyse
            {
                return RedirectToAction("RolEkle", new { message = "Rol zaten kayıtlı" });
            }

            Roles.CreateRole(RoleName);
            return RedirectToAction("RolEkle", new { message = "Başarılı" });

        }
        public string RolSil(string RoleName)
        {
            Roles.DeleteRole(RoleName);    //AJAX İLE SİLME YAPTIĞIMIZ için(yeni bir silme sayfası açmıyoruz)
            return "Hata";                 //bu metot için View eklemedik. Burayı sadece indeksi(RoleName) almak için kullandık.
        }
    }
}