using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize]
    public class SatisHareketController : Controller
    {

        // GET: SatisHareket
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarakets.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A,B,C")]
        [HttpGet]
        public ActionResult SatisHareketEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;
            return View();
        }
        [Authorize(Roles = "A,B,C")]
        public ActionResult SatisHareketGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;
            var urundeger = c.SatisHarakets.Find(id);
            return View("SatisHareketGetir", urundeger);

        }

        [HttpPost]
        public ActionResult SatisHareketEkle(SatisHaraket p)
        {
            c.SatisHarakets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisHareketSil(int id)
        {
            var ktg = c.SatisHarakets.Find(id);
            c.SatisHarakets.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisHareketGuncelle(SatisHaraket p)
        {
            var urn = c.SatisHarakets.Find(p.Satisid);
            urn.Tarihi = p.Tarihi;
            urn.Fiyat = p.Fiyat;
            urn.Adet = p.Adet;
            urn.ToplamFutar = p.ToplamFutar;
            urn.Cariid = p.Cariid;
            urn.PersonelID = p.PersonelID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}