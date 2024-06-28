using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HikayeWebApp.Controllers
{
    public class AdminController : Controller
    {
        public string adminAd="mustafaComez3437";
        public string adminSifre="123456";
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            if(adminAd==fc["username"] && adminSifre == fc["password"])
            {
                return Redirect("/Admin/AdminSuccesfullLogin");
            }
            return View();
        }
        public ActionResult AdminSuccesfullLogin()
        {
            return View();
        }
    }
}