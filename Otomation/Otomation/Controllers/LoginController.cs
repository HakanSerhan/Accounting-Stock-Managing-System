using Otomation.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Otomation.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login (Admin admin)
        {
            
            var giris = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
           
            if (giris != null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAd, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.G = "Kullanıcı Adı veya Şifrenizi Kontrol Ediniz.";
                return View();
            }
        }
    }
}
