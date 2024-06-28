
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HikayeWebApp.Models.Entity;

namespace HikayeWebApp.Controllers
{
    public class FirstPageController : Controller
    {
        public DbHikayeEntities1 db = new DbHikayeEntities1();

        // GET: Fir
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginEkrani()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult LoginEkrani(string kullaniciAdi,string sifre)
        {
            var yazar = db.TblKullanicilar.SingleOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.KullaniciSifre == sifre);

            if (yazar != null)
            {
                // Kullanıcı bilgilerini Session'a ekleyin
                Session["kullaniciAdi"] = yazar.KullaniciAdi;
                Session["kullaniciID"] = yazar.KullaniciID;
                

               
                // Home/Index sayfasına yönlendirin
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
                return View();
            }
        }
        [HttpGet]
        public ActionResult SignupEkrani()
        {

            return View();

        }
        [HttpPost]
        public ActionResult SignupEkrani(TblKullanicilar p1)
        {

            db.TblKullanicilar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("LoginEkrani","FirstPage");

        }
    }
}