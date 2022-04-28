using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl

        DBHospitalEntities7 HastaKayitEt = new DBHospitalEntities7();

        [HttpGet]
        public ActionResult Kayit()
        {
            Users users = new Users();
            return View(users);
        }
        [HttpPost]
        public ActionResult Kayit(Users p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
           
            HastaKayitEt.Users.Add(p);
            HastaKayitEt.SaveChanges();
            return View();
        }
    }
}