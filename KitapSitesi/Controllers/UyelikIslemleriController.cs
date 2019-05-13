using KitapSitesi.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KitapSitesi.Controllers
{
    public class UyelikIslemleriController : Controller
    {
        public ActionResult GirisYap()  // (giriş yap) ekranını göstermek için 
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(UserClass uc, string RememberMe)   //Login için POST metodu
        {
            //ValidateUser metodu  kullanıcının vermiş olduğu kullanıcı adı valid mi diye bakar
            bool validateResult = Membership.ValidateUser(uc.UserName, uc.Password);
            if (validateResult == true)
            {
                //girilen bilgiler doğruysa anasayfaya yönlendireceğiz
                if (RememberMe == "on")
                {
                    //Beni hatırlayı işaretlediyse browserin içindeki Cookie'lere kullanıcı adı ve parolayı ekliycez
                    //Authentic olan kullanıcıyı yönlendirmeye yarar.
                    FormsAuthentication.RedirectFromLoginPage(uc.UserName, true);
                    //true= çerez oluşturayımmı? => evet

                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(uc.UserName, false);
                    //false= çerez oluşturayımmı? => hayır
                }
            }
            else
            {
                ViewBag.validateMessage = "Kullanıcı adı veya parola hatalı. Kontrol ediniz.";
                return View(); // Tekrar giriş yapabilmesi için yine aynı sayfada kalıcak.
            }
            return View();
        }
        public ActionResult ParolaSıfırla(string UserName)   //  parola resetleme ekranını getirmek için
        {
            UserClass uc = new UserClass();
            uc.UserName = UserName;
            return View(uc);
        }
        [HttpPost]
        public ActionResult ParolaSıfırla(UserClass uc)    //Parolayı resetlemek (sıfırlamak) için 
        {
            MembershipUser mu = Membership.GetUser(uc.UserName);
            if (mu.PasswordQuestion == uc.PasswordQuestion) //Kullanıcının daha önceden verdiği soru ile ekrana girdiği soru aynı ise
            {
                string pwd = mu.ResetPassword(uc.PasswordAnswer); //Girilen cevap doğru ise şifreyi resetle
            }
            else
            {
                ViewBag.resetPasswordMessage = "Girilen bilgiler yanlıştır";
            }
            return View();
        }
        public ActionResult HesapOlustur()    //Yeni kayıt ekleme ekranını getirmek için
        {
            return View();
        }

        [HttpPost]
        public ActionResult HesapOlustur(UserClass uc, string passwordConfirm)     //Yeni kayıt eklemek için POST
        {
            if (uc.Password != passwordConfirm)
            {
                ViewBag.messageStatus = "Parolalar eşleşmiyor";
                return View();
            }

            MembershipCreateStatus createStatus;
            Membership.CreateUser(uc.UserName, uc.Password, uc.PasswordQuestion, uc.PasswordAnswer, uc.Email, true, out createStatus);
            string messageStatus = "";

            switch (createStatus)
            {

                case MembershipCreateStatus.Success:
                    messageStatus = "Başarılı";
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
                return RedirectToAction("GirisYap"); //giriş yap ekranına yönlendirdik
            }
            else
            {
                return View();
            }

        }
        public ActionResult CıkısYap()   //Sistemden çıkış yapmak için View açacak. Bu metodun POSTu yok.
        {
            FormsAuthentication.SignOut(); //Çıkış yapmak için 
            return RedirectToAction("GirisYap"); //çıkınca tekrar giriş yapma ekranına gelecek.
        }
    }
}