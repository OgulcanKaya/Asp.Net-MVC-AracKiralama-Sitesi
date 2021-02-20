using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    public class ArabalarController : Controller
    {

        // GET: Arabalar
        Context ctx = new Context();

        public ActionResult Index()
        {
            var cars = ctx.Arabalars.Where(x => x.Status == true).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(cars);
        }

        [HttpGet]
        public ActionResult ArabaEkle()
        {
            List<SelectListItem> deger1 = (from x in ctx.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.KategoriId.ToString()



                                           }).ToList();
            ViewBag.dgr1 = deger1;
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
        public ActionResult ArabaEkle(Arabalar arb)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Assets/Arabalar/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                arb.Image = "/Assets/Arabalar/" + dosyaadi;
            }
            arb.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
            arb.Created_At = DateTime.Parse(DateTime.Now.ToShortDateString());
            ctx.Arabalars.Add(arb);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ArabaSil(int id)
        {
            var car = ctx.Arabalars.Find(id);
            car.Status = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ArabaAktifleştir(int id)
        {
            var car = ctx.Arabalars.Find(id);
            car.Status = true;
            ctx.SaveChanges();
            return RedirectToAction("SilinenArabalar");

        }

        public ActionResult KiradanDöndür(int id)
        {
            var car = ctx.Arabalars.Find(id);
            car.Kirada = false;
            ctx.SaveChanges();
            return RedirectToAction("KiralananArabalar");

        }



        public ActionResult SilinenArabalar()
        {
            var cars = ctx.Arabalars.Where(x => x.Status == false).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(cars);
        }

        public ActionResult KiralananArabalar()
        {
            var cars = ctx.Arabalars.Where(x => x.Kirada == true).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(cars);
        }


        public ActionResult ArabaDetayı(int id)
        {
            CarDetay crcmnt = new CarDetay();
            crcmnt.Araba = ctx.Arabalars.Where(x => x.ArabaId == id).ToList();
            crcmnt.Comments = ctx.Commentss.Where(x => x.Arabaid == id).ToList();
            crcmnt.Galeris = ctx.Galeris.Where(x => x.Arabaid == id).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View("ArabaDetayı", crcmnt);
        }
        public ActionResult ArabaDetay(int id)
        {
            var car = ctx.Arabalars.Where(x => x.ArabaId == id).ToList();
            var car1 = ctx.Arabalars.Where(x => x.ArabaId == id).Select(y => y.Title).FirstOrDefault();

            ViewBag.cars = car1;
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View("ArabaDetay", car);
        }

        public ActionResult ArabaGetir(int id)

        {
            List<SelectListItem> deger1 = (from x in ctx.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.KategoriId.ToString()



                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var car = ctx.Arabalars.Find(id);
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;

            return View("ArabaGetir", car);

        }



        public ActionResult ArabaGüncelle(Arabalar arb)
        {
            var car = ctx.Arabalars.Find(arb.ArabaId);

            if (Request.Files.Count > 0 && arb.Image != null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Assets/Arabalar/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                arb.Image = "/Assets/Arabalar/" + dosyaadi;
                car.Title = arb.Title;
                car.Keywords = arb.Keywords;
                car.Description = arb.Description;
                car.Kategoriid = arb.Kategoriid;
                car.Marka = arb.Marka;
                car.Model = arb.Model;
                car.Detail = arb.Detail;
                car.Motorgücü = arb.Motorgücü;
                car.Image = arb.Image;
                car.Yıl = arb.Yıl;
                car.Vites = arb.Vites;
                car.Km = arb.Km;
                car.Fiyat = arb.Fiyat;
                car.Status = arb.Status;
                car.Created_At = arb.Created_At;
                car.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                ctx.SaveChanges();

            }
            else
            {
                car.Title = arb.Title;
                car.Keywords = arb.Keywords;
                car.Description = arb.Description;
                car.Kategoriid = arb.Kategoriid;
                car.Marka = arb.Marka;
                car.Model = arb.Model;
                car.Detail = arb.Detail;
                car.Motorgücü = arb.Motorgücü;
                car.Yıl = arb.Yıl;
                car.Vites = arb.Vites;
                car.Km = arb.Km;
                car.Fiyat = arb.Fiyat;
                car.Status = arb.Status;
                car.Created_At = arb.Created_At;
                car.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                ctx.SaveChanges();

            }


            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult GaleriResim(int id)
        {
            var galeri = ctx.Galeris.Where(x => x.Arabaid == id).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View("GaleriResim", galeri);
        }


        [HttpGet]
        public PartialViewResult GaleriResimEkle()
        {

            return PartialView("GaleriResimEkle");
        }


        [HttpPost]
        public ActionResult GaleriResimEkle(Galeri g, int id)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Assets/Arabalar/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                g.Image = "/Assets/Arabalar/" + dosyaadi;
            }

            g.Arabaid = id;
            ctx.Galeris.Add(g);
            ctx.SaveChanges();
            return RedirectToAction("GaleriResim", new { id = id });

        }
    }
}