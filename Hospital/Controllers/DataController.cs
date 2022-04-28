using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Hospital.Models;
using Hospital.Models.Entity;

namespace Hospital.Controllers
{
    public class DataController : Controller
    {
		public DBHospitalEntities7 db = new DBHospitalEntities7();
		public ActionResult Index()
		{
			

			List<DataPoint> dataPoints = new List<DataPoint>();

			foreach (var ktg in db.Birimler)
            {
				dataPoints.Add(new DataPoint(ktg.BölümAdi, ktg.PersonelSayisi));

				ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			}

			Sayilar VeriSetleri = new Sayilar
			{
				PersonelSayisi = db.Users.Count(),
				HastaSayisi = db.Patient.Count(),
				BirimSayisi = db.Birimler.Count(),
				ReceteSatisi = db.RECETE.Count(),
				DepoMiktari = db.DEPO.Count(),
				AtilanMesajSayisi = db.Mesaj.Count(),
				IlacListesi = db.IlacListe.Count(),
			};
			return View(VeriSetleri);
		}
		JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
	}
}