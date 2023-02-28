using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize] 
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [Authorize(Roles = "A,B")]
        [HttpGet]

        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem 
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString() 
                                           }).ToList();

            ViewBag.dgr1 = deger1;
                return View();
                                            
        }
        [Authorize(Roles = "A,B")]

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);

        }

        public ActionResult UrunGuncelle(Urun p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Images/" + dosyaadi + uzanti;
            }
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Images/" + dosyaadi + uzanti;
            }
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A,B")]

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}