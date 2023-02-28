using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize]

    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();

      
        public ActionResult Index()
        {
            var degerler = c.Departmans.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman k)
        {
            c.Departmans.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]

        public ActionResult DepartmanSil(int id)
        {
            var ktg = c.Departmans.Find(id);
            c.Departmans.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }
        public ActionResult DepartmanGuncelle(Departman k)
        {
            var ktgr = c.Departmans.Find(k.Departmanid);
            ktgr.Departmanid = k.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var UrunVeri = c.SatisHarakets.Where(x => x.PersonelID == id).ToList();
            var vrl = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonalSoyad).FirstOrDefault();
            ViewBag.p = vrl;           
            return View(UrunVeri);
        }
        public ActionResult DepartmanDetay(int id)
        {
            var veriler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var vrl = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = vrl;
            return View(veriler);
        }
    }
}