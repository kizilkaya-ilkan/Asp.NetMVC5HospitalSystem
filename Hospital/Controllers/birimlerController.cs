using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class birimlerController : Controller
    {
        DBHospitalEntities7 birimlerilisteleme = new DBHospitalEntities7();
        // GET: birimler
        public ActionResult Index()
        {
            var birimlerList = birimlerilisteleme.Birimler.ToList();

            return View(birimlerList);
        }
        [HttpGet]
        public ActionResult BirimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BirimEkle(Birimler p)
        {
            birimlerilisteleme.Birimler.Add(p);
            birimlerilisteleme.SaveChanges();
            return View();
        }
        public ActionResult BirimSil(int id)
        {
            Birimler kayit = birimlerilisteleme.Birimler.Where(k => k.ID == id).SingleOrDefault();
            birimlerilisteleme.Birimler.Remove(kayit);
            birimlerilisteleme.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BirimGetir(int id)
        {
            Birimler kayit = birimlerilisteleme.Birimler.Where(k => k.ID == id).SingleOrDefault();
            return View("BirimGetir", kayit);
        }  
        public ActionResult BirimDüzenle(Birimler p)
        {
            Birimler kayit = birimlerilisteleme.Birimler.Where(k => k.ID == p.ID).SingleOrDefault();
            kayit.BölümAdi = p.BölümAdi;
            kayit.PersonelSayisi = p.PersonelSayisi;
            kayit.Açıklama = p.Açıklama;
            birimlerilisteleme.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
