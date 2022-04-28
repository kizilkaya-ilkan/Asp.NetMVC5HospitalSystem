using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: Home
        public ActionResult Index()
        {

            var sonuc = from k in db.BunlarıBiliyormusunuz select k;

            return View(sonuc.ToList());
        }
    }
}