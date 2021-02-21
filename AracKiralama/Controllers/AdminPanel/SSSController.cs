using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    [Authorize(Roles = "A")]
    public class SSSController : Controller
    {
        Context ctx = new Context();
        // GET: SSS
        public ActionResult Index()
        {
            var faq = ctx.SSSes.ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View(faq);
        }

        [HttpGet]
        public ActionResult SSSekle()
        {
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;


            return View();
        }

        [HttpPost]
        public ActionResult SSSekle(SSS faq)
        {
            faq.updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            faq.created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctx.SSSes.Add(faq);
            ctx.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult SSSGetir(int id)
        {
            var faq = ctx.SSSes.Find(id);
            var ktgr = ctx.Kategoris.Find(id);
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View("SSSGetir",faq);
        }

        public ActionResult SSSGÜncelle(SSS faq)
        {
            var sss = ctx.SSSes.Find(faq.id);
            sss.position = faq.position;
            sss.soru = faq.soru;
            sss.cevap = faq.cevap;
            sss.status = faq.status;
            sss.updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            sss.created_at = faq.created_at;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}