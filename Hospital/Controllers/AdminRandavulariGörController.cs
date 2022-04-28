using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class AdminRandavulariGörController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: AdminRandavulariGör
        public ActionResult Index()
        {
            var Gör = db.tCalendar.ToList();
            return View(Gör);
        }
        public ActionResult RandavuSil(int id)
        {
            var deger = db.tCalendar.Where(x => x.IDCalendar == id).SingleOrDefault();
            db.tCalendar.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}