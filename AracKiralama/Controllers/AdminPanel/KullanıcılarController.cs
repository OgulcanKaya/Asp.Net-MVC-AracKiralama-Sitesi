using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    [Authorize(Roles = "A")]
    public class KullanıcılarController : Controller
    {
        Context ctx = new Context();

        // GET: Kullanıcılar
        public ActionResult Index()
        {
            var users = ctx.Kullanıcıs.Where(x => x.Status == true).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(users);
        }

        public ActionResult KullanıcıDetay(int id)
        {
            var user = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).ToList();
            var usr = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).Select(y => y.Ad + y.Soyad).FirstOrDefault();
            ViewBag.user = usr;
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(user);
        }

        public ActionResult KullanıcıGetir(int id)
        {
            var user = ctx.Kullanıcıs.Find(id);
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View("KullanıcıGetir",user);
        }

        [HttpPost]
        public ActionResult KullanıcıGüncelle(Kullanıcı kullanıcı)
        {
            var user = ctx.Kullanıcıs.Find(kullanıcı.KullanıcıId);
            user.Ad = kullanıcı.Ad;
            user.Soyad = kullanıcı.Soyad;
            user.Sehir = kullanıcı.Sehir;
            user.Mail = kullanıcı.Mail;
            user.Password = kullanıcı.Password;
            user.Image = kullanıcı.Image;
            user.Yetki = kullanıcı.Yetki;
            user.Status = kullanıcı.Status;
            user.Created_at = kullanıcı.Created_at;
            user.Updated_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KullanıcıSil(int id)
        {
            var user = ctx.Kullanıcıs.Find(id);
            user.Status = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KullanıcıAktifleştir(int id)
        {
            var user = ctx.Kullanıcıs.Find(id);
            user.Status = true;
            ctx.SaveChanges();
            return RedirectToAction("SilinenKullanıcılar");

        }

        public ActionResult SilinenKullanıcılar()
        {
            var user = ctx.Kullanıcıs.Where(x => x.Status == false).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(user);
        }

        public ActionResult KullanıcıKiralamalar(int id)
        {
            var hrkt = ctx.KiralamaHarekets.Where(x => x.Kullanıcıid == id).ToList();
            var user = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).Select(y => y.Ad + y.Soyad).FirstOrDefault();
            ViewBag.user = user;
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(hrkt);
        }
        public ActionResult KullanıcıYorumları(int id)
        {
            var yorumlar = ctx.Commentss.Where(x => x.Kullanıcıid == id).ToList();
            var user = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).Select(y => y.Ad + y.Soyad).FirstOrDefault();
            ViewBag.user = user;
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(yorumlar);
        }


    }
}