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
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(setting);
        }

        public ActionResult SettingGetir(int id)
        {
            var set = ctx.Settings.Find(id);
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
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