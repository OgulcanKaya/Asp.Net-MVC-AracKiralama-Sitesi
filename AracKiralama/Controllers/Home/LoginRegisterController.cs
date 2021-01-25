using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;
using System.Web.Security;


namespace AracKiralama.Controllers.Home
{

    public class LoginRegisterController : Controller
    {

        Context ctx = new Context();
        // GET: LoginRegister
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Kullanıcı k)
        {
            var kullanıcı = ctx.Kullanıcıs.FirstOrDefault(x => x.Mail == k.Mail && x.Password == k.Password);
            if (kullanıcı != null)
            {
                FormsAuthentication.SetAuthCookie(kullanıcı.Mail,false);
                Session["Mail"] = kullanıcı.Mail.ToString();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Index","LoginRegister");

            }

        }

        [HttpGet]
        public ActionResult Register() 
        {

            return View();
        
        }

        [HttpPost]
        public ActionResult Register(Kullanıcı k)
        {
            k.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            k.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctx.Kullanıcıs.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AdminLogin() 
        {

            return View();        
        
        }


        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var admin = ctx.Admins.FirstOrDefault(x => x.Mail == a.Mail && x.Password == a.Password);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Mail, false);
                Session["Mail"] = admin.Mail.ToString();
                return RedirectToAction("Index", "İstatistik");

            }
            else
            {
                return RedirectToAction("AdminLogin", "LoginRegister");

            }

        }

        public ActionResult SignOut()
        {


            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }



    }
}