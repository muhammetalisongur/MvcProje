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
        public ActionResult Index(string p)
        {
            var degerler = from i in db.Musteriler select i;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());           
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler p)
        {
            if (!ModelState.IsValid)
            {
               
                return View("YeniMusteri");
            }
            db.Musteriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            if (!ModelState.IsValid)
            {

                return View("MusteriGetir");
            }
            var musteri = db.Musteriler.Find(id);
            return View("MusteriGetir", musteri);

        }

        public ActionResult Guncelle(Musteriler p)
        {
            var musteribul = db.Musteriler.Find(p.MusteriID);
            musteribul.MusteriAd = p.MusteriAd;
            musteribul.MusteriSoyad = p.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}