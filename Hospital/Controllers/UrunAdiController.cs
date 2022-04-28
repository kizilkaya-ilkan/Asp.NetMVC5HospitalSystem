using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class UrunAdiController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: UrunAdi
        public ActionResult Index(string p)
        {
            var ilacliste = from k in db.IlacListe select k;
            if (!string.IsNullOrEmpty(p))
            {
                ilacliste = ilacliste.Where(m => m.UrunAdi.Contains(p));
            }
            return View(ilacliste.ToList());
        }
        public ActionResult GetirIlac(int id)
        {
            IlacListe kayit = db.IlacListe.Where(t => t.ID == id).SingleOrDefault();

            return View("GetirIlac", kayit);
        }
        public ActionResult GetirDüzenle(IlacListe P)
        {
            IlacListe kayit = db.IlacListe.Where(t => t.ID == P.ID).SingleOrDefault();
       
            kayit.UrunAdi = P.UrunAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SilIlac(int id)
        {
            IlacListe Sil = db.IlacListe.Where(t => t.ID == id).SingleOrDefault();
            db.IlacListe.Remove(Sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EkleIlac()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EkleIlac(IlacListe P)
        {
            db.IlacListe.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}