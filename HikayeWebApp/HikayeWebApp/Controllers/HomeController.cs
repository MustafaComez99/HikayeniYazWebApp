using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HikayeWebApp.Models.Entity;

namespace HikayeWebApp.Controllers
{
    public class HomeController : Controller
    {
        public DbHikayeEntities1 db = new DbHikayeEntities1();
        public ActionResult Index()
        {
            if (Session["kullaniciAdi"] != null)
            {              
                ViewBag.YazarAd= Session["kullaniciAdi"];
                ViewBag.YazarID = Session["kullaniciID"];
                
            }
            var degerler = db.TblHikayeler.ToList();
            return View(degerler);
        }


     
        public ActionResult HikayeyiOku(int id)
        {
            var hky = db.TblHikayeler.Find(id);
            return View("HikayeyiOku", hky);


        }

     
        public ActionResult HikayeyiGetir(int id)
        {
            var hky = db.TblHikayeler.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            return View("HikayeyiGetir", hky);


        }

        public ActionResult HikayeyiGuncelle(TblHikayeler p)
        {
            //HikayeyiGetir'deki formdan gönderilen bilgilerle bu işlem yapılabildi. İlk denemede formda HikayeId olmadığından hata almıştık. Çünkü p HikayeId'si null olmuştu
            var hky = db.TblHikayeler.Find(p.HikayeID);
            hky.HikayeBaslik = p.HikayeBaslik;
            hky.HikayeIcerik = p.HikayeIcerik;
            //hky.HikayeKategori = p.HikayeKategori;
            var ktg = db.TblKategoriler.Where(m => m.KategoriID == p.TblKategoriler.KategoriID).FirstOrDefault();
            hky.HikayeKategori = ktg.KategoriID;
            db.SaveChanges();
            
            return RedirectToAction("Index");


        }
        public ActionResult HikayeyiSil(int id)
        {
            var hky = db.TblHikayeler.Find(id);
            db.TblHikayeler.Remove(hky);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}