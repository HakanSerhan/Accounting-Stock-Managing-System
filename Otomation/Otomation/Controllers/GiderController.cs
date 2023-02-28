using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize(Roles = "A")]

    public class GiderController : Controller
    {
        // GET: Gider
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Giders.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult GiderEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiderEkle(Gider k)
        {
            c.Giders.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GiderSil(int id)
        {
            var ktg = c.Giders.Find(id);
            c.Giders.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GiderGetir(int id)
        {
            var gider = c.Giders.Find(id);
            return View("GiderGetir", gider);
        }
        public ActionResult GiderGuncelle(Gider k)
        {
            var ktgr = c.Giders.Find(k.GiderId);
            ktgr.Aciklama = k.Aciklama;
            ktgr.Tarih = k.Tarih;
            ktgr.Tutar = k.Tutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}