using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler p)
        {
            db.Musteriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}