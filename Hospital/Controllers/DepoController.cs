using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;


namespace Hospital.Controllers
{
    public class DepoController : Controller
    {
        // GET: Depo
        DBHospitalEntities7 db = new DBHospitalEntities7();

        public ActionResult Index(string p)
        {
            var ilacliste = from k in db.DEPO select k;
            if (!string.IsNullOrEmpty(p))
            {
                ilacliste = ilacliste.Where(m => m.URUNADI.Contains(p));
            }
            return View(ilacliste.ToList());
        }

        public ActionResult DepoSil(int id)
        {
            DEPO Sil = db.DEPO.Where(t => t.ID == id).SingleOrDefault();
            db.DEPO.Remove(Sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepoGetir(int id )
        {
            DEPO kayit = db.DEPO.Where(t => t.ID == id).SingleOrDefault();

            List<SelectListItem> deger1 = (from r in db.IlacListe.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.UrunAdi,
                                               Value = r.UrunAdi.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View("DepoGetir",kayit);
        }

        public ActionResult DepoDüzenle(DEPO P)
        {
            DEPO depo = db.DEPO.Where(t => t.ID == P.ID).SingleOrDefault();
            IlacListe depoo = db.IlacListe.Where(t => t.ID == P.ID).SingleOrDefault();

            depo.ID = P.ID;
            depoo.UrunAdi = P.URUNADI;
            depo.URUNACIKLAMASI = depo.URUNACIKLAMASI;
            depo.STOK = P.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DepoEkle()
        {
            List<SelectListItem> deger1 = (from r in db.IlacListe.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.UrunAdi,
                                               Value = r.UrunAdi.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            

            return View();
        }
        [HttpPost]
        public ActionResult DepoEkle(DEPO P)
        {
            db.DEPO.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}