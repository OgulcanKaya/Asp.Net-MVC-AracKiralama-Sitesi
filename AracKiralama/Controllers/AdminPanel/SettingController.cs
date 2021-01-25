using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    public class SettingController : Controller
    {
        Context ctx = new Context();
        // GET: Setting
        public ActionResult Index()
        {
            var setting = ctx.Settings.ToList();

            return View(setting);
        }

        public ActionResult SettingGetir(int id)
        {
            var set = ctx.Settings.Find(id);
            return View("SettingGetir", set);
        }

        public ActionResult SettingGüncelle(Setting s)
        {
            var set = ctx.Settings.Find(s.SettingId);
            set.Title = s.Title;
            set.Keywords = s.Keywords;
            set.Description = s.Description;
            set.Mail = s.Mail;
            set.Address = s.Address;
            set.Smtpserver= s.Smtpserver;
            set.Smtpemail = s.Smtpemail;
            set.Harita = s.Harita;
            set.Telefon = s.Telefon;
            set.Smtppassword = s.Smtppassword;
            set.Facebook = s.Facebook;
            set.Twitter = s.Twitter;
            set.Instagram = s.Instagram;
            set.Aboutus = s.Aboutus;
            set.Contactus = s.Contactus;
            set.References = s.References;
            set.Updated_at = DateTime.Parse(DateTime.Now.ToLongDateString());

            ctx.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}