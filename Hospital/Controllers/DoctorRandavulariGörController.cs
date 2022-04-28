using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class DoctorRandavulariGörController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: DoctorRandavulariGör
        public ActionResult Index()
        {
            var bölüm = Session["BÖLÜM"].ToString();
            var Sonuc = db.tCalendar.Where(x => x.Color == bölüm.ToString()).ToList();
            return View(Sonuc);
        }
        public ActionResult RandavuSil(int id)
        {
            tCalendar deger = db.tCalendar.Where(x => x.IDCalendar == id).SingleOrDefault();
            db.tCalendar.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}