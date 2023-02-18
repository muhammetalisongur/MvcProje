using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Kategoriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            // eger herhangi bir islem yapmazsam butona felan tiklamazsam sadece view donder bana
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(Kategoriler p)
        {
            //eger butona tiklarsam o zaman assagida ki islemi uygula
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}