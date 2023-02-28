using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomation.Models.Sınıflar;

namespace Otomation.Controllers
{
    [Authorize]
    public class DetayController : Controller
    {
        Context c = new Context();
        // GET: Detay
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = c.Uruns.Where(x => x.Urunid == 7).ToList();
            cs.deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}