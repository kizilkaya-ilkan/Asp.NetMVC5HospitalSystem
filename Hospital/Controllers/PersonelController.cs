using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        DBHospitalEntities7 PersonelListele = new DBHospitalEntities7();

        public ActionResult Index(string p)
        {
            var birimlerList = from k in PersonelListele.Users select k;
            if (!string.IsNullOrEmpty(p))
            {
                birimlerList = birimlerList.Where(m => m.AD.Contains(p));
            }
            return View(birimlerList.ToList());
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger3 = (from r in PersonelListele.Birimler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = r.BölümAdi,
                                               Value = r.BölümAdi.ToString()

                                           }).ToList();
            ViewBag.dgr3 = deger3;

            //

            List<SelectListItem> deger4 = (from f in PersonelListele.Birimler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = f.Açıklama,
                                               Value = f.Açıklama.ToString()

                                           }).ToList();
            ViewBag.dgr4 = deger4;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Users p)
        {
            PersonelListele.Users.Add(p);
            PersonelListele.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            Users kayit = PersonelListele.Users.Where(t => t.ID == id).SingleOrDefault();
            PersonelListele.Users.Remove(kayit);
            PersonelListele.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            Users kayit = PersonelListele.Users.Where(t => t.ID == id).SingleOrDefault();
            List<SelectListItem> deger1 = (from i in PersonelListele.Birimler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.BölümAdi,
                                               Value = i.BölümAdi.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            //

            List<SelectListItem> deger2 = (from x in PersonelListele.Birimler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Açıklama,
                                               Value = x.Açıklama.ToString()

                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("PersonelGetir", kayit);
        }
        public ActionResult PersonelDüzenle(Users p)
        {
            Users kayit = PersonelListele.Users.Where(t => t.ID == p.ID).SingleOrDefault();

            kayit.ID = p.ID;
            kayit.AD = p.AD;
            kayit.SOYAD = p.SOYAD;
            kayit.BÖLÜM = p.BÖLÜM;
            kayit.YETKİDERECE = p.YETKİDERECE;
            kayit.ANAHTAR = p.ANAHTAR;
            kayit.GÖREVİ = p.GÖREVİ;
            kayit.TELNO = p.TELNO;
            kayit.TCNO = p.TCNO;
            kayit.ADRES = p.ADRES;

            PersonelListele.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}