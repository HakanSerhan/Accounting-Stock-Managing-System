using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize(Roles = "A,B")]

    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar k)
        {
            c.Faturalars.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaSil(int id)
        {
            var ktg = c.Faturalars.Find(id);
            c.Faturalars.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var faturalar = c.Faturalars.Find(id);
            return View("FaturaGetir", faturalar);
        }
        public ActionResult FaturaGuncelle(Faturalar k)
        {
            var ktgr = c.Faturalars.Find(k.Faturaid);
            ktgr.FaturaSeriNo = k.FaturaSeriNo;
            ktgr.FaturaSıraNo = k.FaturaSıraNo;
            ktgr.Tarih = k.Tarih;
            ktgr.VergiDairesi = k.VergiDairesi;
            ktgr.Saat = k.Saat;
            ktgr.TeslimEden = k.TeslimEden;
            ktgr.TeslimAlan = k.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}