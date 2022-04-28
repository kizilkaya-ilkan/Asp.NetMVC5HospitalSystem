using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class HastaReceteController : Controller
    {
        // GET: HastaRecete

        DBHospitalEntities7 db = new DBHospitalEntities7();
        public ActionResult Index()
        {
            var hasta = Session["TCNO"].ToString();
            var HastaReceteBul = db.RECETE.Where(x => x.HASTATC == hasta.ToString()).ToList();
            return View(HastaReceteBul);
        }
    }
}