using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;


namespace AracKiralama.Controllers.AdminPanel
{
    public class KiralamaController : Controller
    {
        Context ctx = new Context();

        // GET: Kiralama
        public ActionResult Index()
        {
            var kiralama = ctx.KiralamaHarekets.ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(kiralama);
        }


        [HttpGet]
        public ActionResult YeniKiralama()
        {
            List<SelectListItem> arabalar = (from x in ctx.Arabalars.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ArabaId.ToString()

                                             }).ToList();


            List<SelectListItem> kullanıcılar = (from x in ctx.Kullanıcıs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Ad,
                                                     Value = x.KullanıcıId.ToString()

                                                 }).ToList();

            ViewBag.arabalar = arabalar;
            ViewBag.kullanıcılar = kullanıcılar;
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
        public ActionResult YeniKiralama(KiralamaHareket kiralamaHareket)
        {
            var fiyat = ctx.Arabalars.Where(x => x.ArabaId == kiralamaHareket.Arabaid).Select(y => y.Fiyat).FirstOrDefault();
            var günsayısı = (kiralamaHareket.TeslimTarih - kiralamaHareket.Tarih).TotalDays;
            var toplamtutar = (decimal)günsayısı * fiyat;
            kiralamaHareket.Fiyat = fiyat;
            kiralamaHareket.GünSayısı = (int)günsayısı;
            kiralamaHareket.ToplamTutar = (Decimal)toplamtutar;
            ctx.KiralamaHarekets.Add(kiralamaHareket);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KiralamaGetir(int id) 
        {
            var kiralama = ctx.KiralamaHarekets.Find(id);
            List<SelectListItem> arabalar = (from x in ctx.Arabalars.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Title,
                                                 Value = x.ArabaId.ToString()

                                             }).ToList();


            List<SelectListItem> kullanıcılar = (from x in ctx.Kullanıcıs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Ad,
                                                     Value = x.KullanıcıId.ToString()

                                                 }).ToList();

            ViewBag.arabalar = arabalar;
            ViewBag.kullanıcılar = kullanıcılar;
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View("KiralamaGetir", kiralama);

        }


        public ActionResult KiralamaGüncelle (KiralamaHareket k)
        {
            var kiralama = ctx.KiralamaHarekets.Find(k.KiralamaId);
            kiralama.Arabaid = k.Arabaid;
            
            kiralama.Kullanıcıid = k.Kullanıcıid;
            kiralama.Tarih = k.Tarih;
            kiralama.TeslimTarih = k.TeslimTarih;
            var fiyat = ctx.Arabalars.Where(x => x.ArabaId == k.Arabaid).Select(y => y.Fiyat).FirstOrDefault();
            var günsayısı = (k.TeslimTarih - k.Tarih).TotalDays;
            var toplamtutar = (decimal)günsayısı * fiyat;
            kiralama.Fiyat = fiyat;
            kiralama.GünSayısı = (int)günsayısı;
            kiralama.ToplamTutar = (Decimal)toplamtutar;
            ctx.SaveChanges();
            return RedirectToAction("Index");        
        
        }

        public ActionResult KiralamaDetay(int id) 
        {
            var detay = ctx.KiralamaHarekets.Where(x => x.KiralamaId == id).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(detay);
        
        
        }

        public ActionResult KiralamalarListe() 
        {
            var degerler = ctx.KiralamaHarekets.ToList();

            return View(degerler);
        
        
        }
        



    }
}