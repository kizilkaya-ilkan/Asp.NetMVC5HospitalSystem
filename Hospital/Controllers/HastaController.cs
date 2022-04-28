using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class HastaController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: HASTAGİRİS
        [Authorize]
        public ActionResult Index()
        {
            var adres = Session["TCNO"].ToString();
            var mesajlar = db.Patient.Where(x => x.TCNO == adres.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}