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
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler p)
        {
            db.Urunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}