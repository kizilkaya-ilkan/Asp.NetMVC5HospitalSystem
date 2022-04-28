using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;


namespace Hospital.Controllers
{
    public class HastaLoginController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();



        // GET: HastaLogin
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Index(Patient p)
        {
            var bilgiler = db.Patient.FirstOrDefault(f => f.TCNO == p.TCNO && f.Anahtar == p.Anahtar);
            if (bilgiler != null )
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ADRES, true);
                Session["TCNO"] = bilgiler.TCNO;
                Session["ADRES"] = bilgiler.ADRES;
                Session["MAILADRESI"] = bilgiler.MAILADRESI;
                return RedirectToAction("Index","Hasta");
            }
            else
            {
                return View();
            }
        }
    }
}