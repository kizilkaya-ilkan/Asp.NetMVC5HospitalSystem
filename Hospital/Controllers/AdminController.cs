using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DBHospitalEntities7 db = new DBHospitalEntities7();

        [Authorize]
        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.ALICI == adres.ToString()).ToList();

            return View(mesajlar);
        }

     
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult AdminMesaj()
        {
            var adres = Session["ADRES"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.ALICI == adres.ToString()).ToList();

            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj t)
        {

            var adres = Session["ADRES"].ToString();
            t.GÖNDEREN = adres.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            t.ISLEM = "İşlem Beklemede";
            db.Mesaj.Add(t);
            db.SaveChanges();
            return View();
        }

        public ActionResult MesajSil(int id)
        {

            Mesaj Delete = db.Mesaj.Where(t => t.ID == id).SingleOrDefault();
            db.Mesaj.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MesajGetir(int id)
        {
            Mesaj kayit = db.Mesaj.Where(t => t.ID == id).SingleOrDefault();

            return View("MesajGetir", kayit);
        }

        [HttpPost]
        public ActionResult MesajDüzenle(Mesaj p)
        {
            Mesaj kayit = db.Mesaj.Where(t => t.ID == p.ID).SingleOrDefault();
            kayit.ISLEM = "ADMİN TARAFINDAN MÜDAHALE ETTİ";
            kayit.MESAJ1 = p.MESAJ1;
            kayit.HASTA = p.HASTA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }






























    }
}