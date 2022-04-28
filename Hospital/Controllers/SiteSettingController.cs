using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class SiteSettingController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: SiteSetting

        public ActionResult Index()
        {
            var sorgu = db.BunlarıBiliyormusunuz.ToList();
            return View(sorgu);
        }

        public ActionResult Düzenle(int id)
        {

            BunlarıBiliyormusunuz kayit = db.BunlarıBiliyormusunuz.Where(t => t.ID == id).SingleOrDefault();
            return View("Düzenle", kayit);
        }
        public ActionResult Kaydet(BunlarıBiliyormusunuz p)
        {
            BunlarıBiliyormusunuz kayit = db.BunlarıBiliyormusunuz.Where(t => t.ID == p.ID).SingleOrDefault();
            kayit.SiteAcıklama = p.SiteAcıklama;
            kayit.Acıklama = p.Acıklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}