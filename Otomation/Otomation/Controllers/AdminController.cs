using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Otomation.Models.Sınıflar;
namespace Otomation.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminController : Controller
    {
        
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Admins.ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin k)
        {
            c.Admins.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var ktg = c.Admins.Find(id);
            c.Admins.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult AdminGetir(int id)
        {
            var admin = c.Admins.Find(id);
            return View("AdminGetir", admin);
        }
        public ActionResult AdminGuncelle(Admin k)
        {
            var ktgr = c.Admins.Find(k.Adminid);
            ktgr.KullaniciAd = k.KullaniciAd;
            ktgr.Sifre = k.Sifre;
            ktgr.Yetki = k.Yetki;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}