using Otomation.Models.Sınıflar;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Otomation.Controllers
{
    [Authorize(Roles = "A")]
    public class İstatistikController : Controller
    {
        Context c = new Context();
        // GET: İstatistik
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var prodCount = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            if (prodCount =="0")
            {
                ViewBag.d5 = 0;
            }
            else if (prodCount!="0")
            { 
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            }
            var deger6 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d6 = deger6;

            var deger7 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            var satisSayac = c.SatisHarakets.Sum(x => x.ToplamFutar).ToString();
            if (satisSayac == "0")
            {
                ViewBag.d10 = 0;
            }
            else if (satisSayac != "0")
            { 
            var deger10 = c.SatisHarakets.Sum(x => x.ToplamFutar).ToString();
            ViewBag.d10 = deger10;
            }

            DateTime bugun = DateTime.Today;
            var deger11 = c.SatisHarakets.Count(x => x.Tarihi == bugun).ToString();
            ViewBag.d11 = deger11;
            if (deger11 == "0")
            {
                ViewBag.d12 = 0;
            }
            else if (deger11 == "0")
            {
                var deger12 = c.SatisHarakets.Where(x => x.Tarihi == bugun).Sum(y => y.ToplamFutar).ToString();
            
                ViewBag.d12 = deger12;
            }
            return View();
        }
        public ActionResult Statstable()
        {
            var sorgu = from x in c.Caris
                        group x by x.CariSehir into g
                        select new Sinifgrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new Sinifgrup2
                         {
                             departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu2 = from x in c.Uruns
                         group x by x.Kategori.KategoriAd into g
                         select new Sinifgrup3
                         {
                             kategori = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
    }
}