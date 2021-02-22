using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
namespace AracKiralama.Controllers.AdminPanel
{
    [Authorize(Roles = "A")]
    public class KategoriController : Controller
    {
        // GET:Kategori
        Context ctx = new Context();
        public ActionResult Kategori(int sayfa =1)
        {
            var kategoriler = ctx.Kategoris.ToList().ToPagedList(sayfa,10);
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle() {

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
        public ActionResult KategoriEkle(Kategori k)
        {
            k.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            k.Created_At = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctx.Kategoris.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Kategori");

        }

        public ActionResult KategoriSil(int id)
        {
            var ktgr = ctx.Kategoris.Find(id);
            ctx.Kategoris.Remove(ktgr);
            ctx.SaveChanges();
            return RedirectToAction("Kategori");
        
        }
        public ActionResult KategoriGetir(int id) 
        {
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
            return View("KategoriGetir", ktgr);

        }

        public ActionResult KategoriGüncelle(Kategori k) 
        {
            var ktgr = ctx.Kategoris.Find(k.KategoriId);
            ktgr.ParentId = k.ParentId;
            ktgr.Title = k.Title;
            ktgr.Keywords = k.Keywords;
            ktgr.Description = k.Description;
            ktgr.Status = k.Status;
            ktgr.Created_At = k.Created_At;
            ktgr.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctx.SaveChanges();
            return RedirectToAction("Kategori");
        }

    }
}