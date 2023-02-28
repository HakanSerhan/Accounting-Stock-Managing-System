using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize(Roles = "A,B")]

    public class FaturaKalemController : Controller
    {
        // GET: FaturaKalem
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.FaturaKalems.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            List<SelectListItem> degerler = (from x in c.Faturalars.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.FaturaSeriNo,
                                                 Value = x.Faturaid.ToString()
                                             }).ToList();

            ViewBag.dgr3 = degerler;
            return View();

        }

        public ActionResult FaturaKalemGetir(int id)
        {
            List<SelectListItem> degerler = (from x in c.Faturalars.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.FaturaSeriNo,
                                                 Value = x.Faturaid.ToString()
                                             }).ToList();

            ViewBag.dgr2 = degerler;
            var urundeger = c.FaturaKalems.Find(id);
            return View("FaturaKalemGetir", urundeger);

        }

        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem k)
        {
            c.FaturaKalems.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaKalemSil(int id)
        {
            var ktg = c.FaturaKalems.Find(id);
            c.FaturaKalems.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaKalemGuncelle(FaturaKalem p)
        {
            var prs = c.FaturaKalems.Find(p.FaturaKalemid);
            prs.Aciklama = p.Aciklama;
            prs.Miktar = p.Miktar;
            prs.BirimFiyat = p.BirimFiyat;
            prs.Tutar = p.Tutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
