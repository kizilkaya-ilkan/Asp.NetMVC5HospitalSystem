using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();

        // GET: Doctor
        [Authorize]
        public ActionResult Index()
        {
            var adres = Session["ADRES"].ToString();
            var adresBilgiGetir = db.Users.Where(x => x.ADRES == adres.ToString()).ToList();

            return View(adresBilgiGetir);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}