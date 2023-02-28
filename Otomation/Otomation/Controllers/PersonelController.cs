using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize(Roles = "A,B")]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.Departmanid.ToString()
                                             }).ToList();

            ViewBag.dgr2 = degerler;
            return View();

        }
        [Authorize(Roles = "A")]

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.Departmanid.ToString()
                                             }).ToList();

            ViewBag.dgr2 = degerler;
            var urundeger = c.Personels.Find(id);
            return View("PersonelGetir", urundeger);

        }

        [HttpPost]

        public ActionResult PersonelEkle(Personel k)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                k.PersonalGorsel = "/Images/" + dosyaadi + uzanti;
            }
            c.Personels.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "A")]

        public ActionResult PersonelSil(int id)
        {
            var ktg = c.Personels.Find(id);
            c.Personels.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult PersonelGuncelle(Personel k)
        {
            if (Request.Files.Count > 0 )
            {
                
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                k.PersonalGorsel = "/Images/" + dosyaadi + uzanti;
                
            }
            else if (Request.Files.Count <= 0)
            {
                Response.Write("<script>alert('Dosya Seçmeyi unuttunuz!')</script>");
            }

            var ktgr = c.Personels.Find(k.PersonelID);
            ktgr.PersonelAd = k.PersonelAd;
            ktgr.PersonalSoyad = k.PersonalSoyad;
            ktgr.PersonalGorsel = k.PersonalGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelProfil(int id)
        {
            SatisClass sc = new SatisClass();
            sc.deger1 = c.Personels.Where(x => x.PersonelID == id).ToList();
            sc.deger2 = c.SatisHarakets.Where(x => x.PersonelID == id).ToList(); ;
            return View(sc);
        }
    }
}
