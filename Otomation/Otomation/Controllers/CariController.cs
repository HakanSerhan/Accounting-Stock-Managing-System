using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize]
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Caris.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A,B")]

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari k)
        {
            c.Caris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,B")]

        public ActionResult CariSil(int id)
        {
            var ktg = c.Caris.Find(id);
            c.Caris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,B")]

        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari k)
        {
            var ktgr = c.Caris.Find(k.Cariid);
            ktgr.CariAd = k.CariAd;
            ktgr.CariSoyad = k.CariSoyad;
            ktgr.CariMail = k.CariMail;
            ktgr.CariSehir = k.CariSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSatis(int id)
        {
            var veriler = c.SatisHarakets.Where(x => x.Cariid == id).ToList();
            var crs = c.Caris.Where(x => x.Cariid == id).Select(y => y.CariAd).FirstOrDefault();
            ViewBag.c = crs;
            return View(veriler);
        }
    }
}