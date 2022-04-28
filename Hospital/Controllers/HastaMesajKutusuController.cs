using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class HastaMesajKutusuController : Controller
    {
        DBHospitalEntities7 db = new DBHospitalEntities7();
        // GET: HastaMesajKutusu
        public ActionResult Index()
        {
            var adres = Session["MAILADRESI"].ToString();
            var mesajlar = db.Mesaj.Where(x => x.ALICI == adres.ToString()).ToList();
            return View(mesajlar);

        }
    }
}