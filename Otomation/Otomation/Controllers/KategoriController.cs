using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }


        [Authorize(Roles = "A,B")]

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,B")]

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,B")]

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult KategoriDetay(int id)
        {
            var veriler = c.Uruns.Where(x => x.Kategoriid == id).ToList();
            var vrl = c.Uruns.Where(x => x.Urunid == id).Select(y => y.UrunAd).FirstOrDefault();
            ViewBag.m = vrl;
            return View(veriler);
        }
    }
}
