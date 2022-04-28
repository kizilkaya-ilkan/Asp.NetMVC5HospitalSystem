using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class LoginController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: Login
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users p)      
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.TCNO == p.TCNO && x.ANAHTAR == p.ANAHTAR);

            

            if (bilgiler != null && bilgiler.YETKİDERECE==1)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.TCNO.ToString(), true);
                Session["ADRES"] = bilgiler.ADRES;
                return RedirectToAction("Index","Admin");
                
            }
            if (bilgiler != null && bilgiler.YETKİDERECE == 2)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.TCNO.ToString(), true);
                Session["ADRES"] = bilgiler.ADRES;
                Session["BÖLÜM"] = bilgiler.BÖLÜM;
                return RedirectToAction("Index", "Doctor");

            }
            if (bilgiler != null && bilgiler.YETKİDERECE == 3)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.TCNO.ToString(), true);
                Session["ADRES"] = bilgiler.ADRES;
                return RedirectToAction("Index", "Lab");

            }
            else
            {
                return View();
            }
        }   
    }
}