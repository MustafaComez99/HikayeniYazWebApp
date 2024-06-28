using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HikayeWebApp.Models.Entity;

namespace HikayeWebApp.Controllers
{
    public class YazarController : Controller
    {
        //Index'te veritabanındaki yazarları listeledik.
        public DbHikayeEntities1 db = new DbHikayeEntities1();
        public ActionResult Index()
        {
            var yazarlar = db.TblKullanicilar.ToList();
            return View(yazarlar);
        }
    }
}