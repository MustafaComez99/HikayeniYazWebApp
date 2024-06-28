using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HikayeWebApp.Models.Entity;

namespace HikayeWebApp.Controllers
{
    
    public class KategoriController : Controller
    {
        public DbHikayeEntities1 db = new DbHikayeEntities1();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TblKategoriler.ToList();
            return View(degerler);
        }

        public ActionResult KategoriyeGoreFiltrele(int id)
        {
            var degerler = db.TblHikayeler.Where(h => h.HikayeKategori == id).ToList();
            
            return View(degerler);


        }
    }
}