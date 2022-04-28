 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class DoktorGörüntüleController : Controller
    {
        // GET: DoktorGörüntüle
        DBHospitalEntities7 db = new DBHospitalEntities7();
        public ActionResult Index()
        {
            var adres = Session["TCNO"].ToString();
            var mesajlar = db.tCalendar.Where(x => x.Title == adres).ToList();
            return View(mesajlar);
        }
        public ActionResult RandavuSil(int id)
        {
            tCalendar Delete = db.tCalendar.Where(x=> x.IDCalendar == id).SingleOrDefault();
            db.tCalendar.Remove(Delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}