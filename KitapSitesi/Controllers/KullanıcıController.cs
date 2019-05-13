using KitapSitesi.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KitapSitesi.Controllers
{
    public class KullanıcıController : Controller
    {
        public ActionResult Index()
        {
            MembershipUserCollection kullanicilist = Membership.GetAllUsers();

            return View(kullanicilist);
        }
        public ActionResult KullanıcıEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullanıcıEkle(UserClass uc)  //UserClass'ı biz oluşturduk.Bizim oluşturduğumuz entity.
        {

            MembershipCreateStatus createStatus;
            Membership.CreateUser(uc.UserName, uc.Password, uc.Email, uc.PasswordQuestion, uc.PasswordAnswer, true, out createStatus);
            string messageStatus = "";


            switch (createStatus)
            {

                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    messageStatus = "Geçersiz kullanıcı adı";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    messageStatus = "Geçersiz parola";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    messageStatus = "Geçersiz gizli soru";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    messageStatus = "Geçersiz gizli cevap";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    messageStatus = "Geçersiz email";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    messageStatus = "Kullanılmış kullanıcı adı";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    messageStatus = "Kullanılmış email";
                    break;
                case MembershipCreateStatus.UserRejected:
                    messageStatus = "Engellenmiş kullanıcı";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    messageStatus = "Geçersiz kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    messageStatus = "Kullanılmış kullanıcı anahtarı";
                    break;
                case MembershipCreateStatus.ProviderError:
                    messageStatus = "Üye yönetimi sağlayıcı hatası";
                    break;
                default:
                    break;
            }
            ViewBag.messageStatus = messageStatus;
            if (createStatus == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public string KullanıcıSil(string UserName)
        {                //Silme işlemi AJAX kodlarıyla yapıldı. Silme işlemi esnasında farklı bir sayfa açmadığımız için
                         //Bu metot için View açmadık.*** Bu metot sadece idyi(UserName) yakalamak için***
            try
            {
                Membership.DeleteUser(UserName);

                return "OK";
            }
            catch (Exception)
            {

                return "ERROR";
            }
        }
        public string RolleriKullanıcı(string username)
        {                //Her kullanıcının rollerini (Rolleri butonuna) gösterecek işlem AJAX kodlarıyla yapıldı. 
                         //Rolleri işlemi esnasında farklı bir sayfa açmadığımız için
                         //Bu metot için View açmadık.*** Bu metot sadece idyi(UserName) yakalamak için***
            try
            {
                string[] roller = Roles.GetRolesForUser(username);
                ViewBag.kullanıcıRoller = string.Join(",", roller);
                return ViewBag.kullanıcıRoller;
            }
            catch (Exception)
            {

                return "HATA";
            }

        }
        public ActionResult RolAtama(string username, string message = null)  //***ROL ATAMA EKRANI İÇİN**** Bunun View'ını ekledik
        {
            if (string.IsNullOrWhiteSpace(username)) //eğer user değeri boşsa Index viewında kal
            {
                return RedirectToAction("Index");
            }

            MembershipUser user = Membership.GetUser(username);

            if (user == null) //gelen değer boşsa HttpNotFound() hatası ver.
            {
                return HttpNotFound();
            }

            string[] userRoles = Roles.GetRolesForUser(username); //Her kullanıcının aldığı roller için  string tipli bir dizi
            string[] allRoles = Roles.GetAllRoles(); //Varolan bütün roller için string tipli bir dizi

            List<string> availableRoles = new List<string>();
            //Kullanıcı için roller eklendiğinde bütün rollerin olduğu listbox içinde kullanıcıya atanan rollerin görünmesini
            //istemiyoruz.Sebebi bir kullanıcıya aynı iki rolü atamamak. Bu yüzden availableRoles adında bir List oluşturduk.
            //Ve bu listte varolan bütün rollerden kullanıcıya eklenen rolleri çıkartıp kalan rolleri gösterdik.
            foreach (string role in allRoles)
            //allRoles dizisi içinde gez. 
            {
                if (!userRoles.Contains(role)) //Eğer role userRoles(kullanıcının aldığı roller) içinde yoksa 
                {
                    availableRoles.Add(role); //availableRoles dizisine ekle.
                }
            }

            ViewBag.AvailableRoles = availableRoles; //Bunu sağdaki listbox kutusunda göstermek için
            ViewBag.UserRoles = userRoles;//Bunu soldaki listbox kutusu içinde göstermek için
            ViewBag.UserName = username;
            ViewBag.Message = message;

            return View();
        }
        [HttpPost]
        public ActionResult RolAtama(string username, List<string> addedRoles)
        {
            //Rol Ver için Post Action'ı. Rol Ver butonu için işlemler burda yapıldı. Rol ver için herhangi bir 
            //Script veya Ajax kodu yazmadık
            if (addedRoles == null)
            {
                return RedirectToAction("RolAtama", new { username = username, message = "Önce rol seçiniz" });
            }
            if (addedRoles.Count < 1)
            {
                return RedirectToAction("RolAtama", new { username = username, message = "Hata" });
            }

            Roles.AddUserToRoles(username, addedRoles.ToArray());

            return RedirectToAction("RolAtama", new { username = username, message = "Başarılı" });
        }
        [HttpPost]
        public string RolAtamaKaldırma(string username, string removedRoles)
        {
            //Rol Silme için Post Action'ı
            string[] removedRolesArray = removedRoles.Split(',');

            if (removedRolesArray.Length < 1 || string.IsNullOrWhiteSpace(removedRolesArray[0]))
                return "Hata";

            Roles.RemoveUserFromRoles(username, removedRolesArray);
            return "Başarılı";
        }
    }
}