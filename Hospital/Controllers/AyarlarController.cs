using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar

        DBHospitalEntities7 db = new DBHospitalEntities7(); 

        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var durum = db.Users.Where(x => x.ADRES == adres.ToString()).ToList();
            return View(durum);
        }

        public ActionResult AyarGetir(int id)
        {
            Users kayit = db.Users.Where(t => t.ID == id).SingleOrDefault();

            return View("AyarGetir", kayit);
        }

 
        public ActionResult AyarDüzenle(Users bilgi)
        {
            Users kayit = db.Users.Where(t => t.ID == bilgi.ID).SingleOrDefault();

            kayit.ID = bilgi.ID;
            kayit.SOYAD = bilgi.SOYAD;
            kayit.ANAHTAR = bilgi.ANAHTAR;
            kayit.ADRES = bilgi.ADRES;
            kayit.TELNO = bilgi.TELNO;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}