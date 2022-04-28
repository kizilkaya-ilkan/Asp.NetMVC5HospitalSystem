using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class HastaTakipController : Controller
    {
        DBHospitalEntities7 HastaTakip = new DBHospitalEntities7();
        public ActionResult Index()
        {
            var Hasta = HastaTakip.Patient.ToList();

            return View(Hasta);
        }
        [HttpGet]
        public ActionResult HastaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HastaEkle(Patient p)
        {
            HastaTakip.Patient.Add(p);
            HastaTakip.SaveChanges();
            return View();
        }
        public ActionResult HastaSil(int id)
        {
            Patient kayit = HastaTakip.Patient.Where(t => t.ID == id).SingleOrDefault();
            HastaTakip.Patient.Remove(kayit);
            HastaTakip.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaGetir(int id)
        {
            Patient kayit = HastaTakip.Patient.Where(t => t.ID == id).SingleOrDefault();
     
            return View("HastaGetir", kayit);
        }
        [HttpPost]
        public ActionResult HastaGüncelle(Patient p)
        {
          Patient kayit = HastaTakip.Patient.Where(t => t.ID == p.ID).SingleOrDefault();

                kayit.ID = p.ID;
                kayit.AD = p.AD;
                kayit.SOYAD = p.SOYAD;
                kayit.TCNO = p.TCNO;
                kayit.Anahtar = p.Anahtar;
                kayit.YETKİ = p.YETKİ;
                kayit.MAILADRESI = p.MAILADRESI;
                kayit.ADRES = p.ADRES;
                kayit.TELNO = p.TELNO;
                kayit.RANDAVUTARIHIGUN = p.RANDAVUTARIHIGUN;
                kayit.RANDAVUTARIHISAAT = p.RANDAVUTARIHISAAT;
                HastaTakip.SaveChanges();
                return RedirectToAction("Index");
            }
    }
}