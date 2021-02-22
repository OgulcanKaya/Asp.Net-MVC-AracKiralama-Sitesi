using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;


namespace AracKiralama.Controllers.Home
{
    public class HomeController : Controller
    {
        Context ctx = new Context();
        // GET: Home
        public ActionResult Index()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.SeciliArabalar = ctx.Arabalars.OrderByDescending(x => x.ArabaId).Take(3).ToList();
            hmpg.Arabalars = ctx.Arabalars.ToList();
            hmpg.Comments = ctx.Commentss.OrderByDescending(x => x.ıd).Take(6).ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();

            return View(hmpg);
        }

        public ActionResult Hakkımızda()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();

            return View(hmpg);
        }

        public ActionResult İletişim()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();


            return View(hmpg);
        }

        public ActionResult Referanslarımız()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();


            return View(hmpg);
        }

        public ActionResult Arabalar(string ara)
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.Arabalars = ctx.Arabalars.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                hmpg.Arabalars = ctx.Arabalars.Where(x => x.Title.Contains(ara)).ToList();
            }
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();

            return View(hmpg);

        }
        public ActionResult KategoriArabalar(int id,string ara)
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.Arabalars = ctx.Arabalars.Where(x => x.Kategoriid == id).ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                hmpg.Arabalars = ctx.Arabalars.Where(x => x.Kategoriid == id && x.Title.Contains(ara)).ToList();
            }
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();

            return View(hmpg);

        }


        public ActionResult AraçDetay(int id)
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.Arabalars = ctx.Arabalars.Where(x => x.ArabaId == id).ToList();
            hmpg.Comments = ctx.Commentss.Where(x => x.Arabaid == id && x.Status == true).ToList();
            hmpg.Galeris = ctx.Galeris.Where(x => x.Arabaid == id).ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();

            return View("AraçDetay", hmpg);

        }

        [HttpGet]
        public PartialViewResult KiralamaYap()
        {
            return PartialView("KiralamaYap");

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KiralamaYap(KiralamaHareket kiralamaHareket, int id)
        {

            var fiyat = ctx.Arabalars.Where(x => x.ArabaId == id).Select(y => y.Fiyat).FirstOrDefault();
            var günsayısı = (kiralamaHareket.TeslimTarih - kiralamaHareket.Tarih).TotalDays;
            var toplamtutar = (decimal)günsayısı * fiyat;
            kiralamaHareket.Arabaid = id;
            kiralamaHareket.Fiyat = fiyat;
            kiralamaHareket.GünSayısı = (int)günsayısı;
            kiralamaHareket.ToplamTutar = (Decimal)toplamtutar;
            ViewBag.id = kiralamaHareket.Arabaid;
            ViewBag.title = ctx.Arabalars.Where(x => x.ArabaId == id).Select(y => y.Title).FirstOrDefault();
            ViewBag.image = ctx.Arabalars.Where(x => x.ArabaId == id).Select(y => y.Image).FirstOrDefault();

            return View("KiralamaDetay", kiralamaHareket);

        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult KiralamaDetay(KiralamaHareket kiralamaHareket)
        {
            Arabalar arb = new Arabalar();
            arb = ctx.Arabalars.Where(x => x.ArabaId == kiralamaHareket.Arabaid).FirstOrDefault();
            arb.Kirada = true;
            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            kiralamaHareket.Kullanıcıid = kullanıcıID;
            ctx.KiralamaHarekets.Add(kiralamaHareket);
            ctx.SaveChanges();
            return RedirectToAction("Index", "UserPage");
        }


        [HttpGet]
        public PartialViewResult KullanıcıYorum()
        {
            return PartialView("KullanıcıYorum");
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullanıcıYorum(Comments cmnt, int id)
        {
            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            cmnt.Kullanıcıid = kullanıcıID;
            cmnt.Arabaid = id;
            cmnt.Status = false;
            cmnt.Created_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            cmnt.Updated_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            ctx.Commentss.Add(cmnt);
            ctx.SaveChanges();
            return RedirectToAction("AraçDetay", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MesajGÖnder(Messages msg)
        {
            msg.status = "New";
            msg.created_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            msg.updated_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            ctx.Messages.Add(msg);
            ctx.SaveChanges();
            return RedirectToAction("İletişim");
        }

        public ActionResult SSS()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.SSSes = ctx.SSSes.ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();
            return View(hmpg);
        }

        public ActionResult KullanıcıDetayları(int id)
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.Kullanıcıs2 = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();
            ViewBag.Ad = ctx.Kullanıcıs.Where(x => x.KullanıcıId == id).Select(y=>y.Ad).FirstOrDefault();
            return View(hmpg);
        }
    }
}