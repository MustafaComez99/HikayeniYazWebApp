using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HikayeWebApp.Models.Entity;


namespace HikayeWebApp.Controllers
{
    public class HikayeEkleController : Controller
    {
        // GET: HikayeEkle
        DbHikayeEntities1 db = new DbHikayeEntities1();
        
     
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            ViewBag.yazar = Session["kullaniciAdi"];
            ViewBag.yazarid = Session["kullaniciID"];
            if ( Session["kullaniciAdi"] != null)
            {
                ViewBag.YazarAd = Session["kullaniciAdi"];
                
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblHikayeler p1)
        {

            if (Session["kullaniciAdi"] != null)
            {
                ViewBag.YazarAd = Session["kullaniciAdi"];
                ViewBag.YazarID = Session["kullaniciID"];

            }

            var ktg = db.TblKategoriler.Where(m => m.KategoriID == p1.TblKategoriler.KategoriID).FirstOrDefault();
            p1.TblKategoriler = ktg;
            p1.HikayeTarih = DateTime.Now;
            db.TblHikayeler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");  
        }
    }
}