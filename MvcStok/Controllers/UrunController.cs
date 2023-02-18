using Microsoft.Ajax.Utilities;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcStokEntities db = new MvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAD,
                                                 Value = i.KategoriID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler p)
        {
            var ktg = db.Kategoriler.Where(x => x.KategoriID == p.Kategoriler.KategoriID).FirstOrDefault();
            p.Kategoriler = ktg;
            db.Urunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}