using AracKiralama.Models.Sınıflar;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AracKiralama.Controllers.Home
{
    [Authorize]
    public class UserPageController : Controller
    {
        // GET: UserPage
        Context ctx = new Context();

        public ActionResult Index()
        {
            HomePageDatas hmpg = new HomePageDatas();
            hmpg.Kategoris = ctx.Kategoris.ToList();
            hmpg.Settings = ctx.Settings.ToList();
            hmpg.SeciliArabalar = ctx.Arabalars.OrderByDescending(x => x.ArabaId).Take(3).ToList();
            hmpg.Arabalars = ctx.Arabalars.ToList();
            hmpg.Comments = ctx.Commentss.ToList();
            var mail = User.Identity.Name.ToString();
            hmpg.Kullanıcıs = ctx.Kullanıcıs.Where(x => x.Mail == mail).ToList();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();

            var toplamKiralama = ctx.KiralamaHarekets.Where(x => x.Kullanıcıid == kullanıcıID).Count().ToString();
            var toplamHarcama = ctx.KiralamaHarekets.Where(x => x.Kullanıcıid == kullanıcıID).Sum(y => y.Fiyat).ToString();
            var toplamYorum = ctx.Commentss.Where(x => x.Kullanıcıid == kullanıcıID).Count().ToString();

            ViewBag.toplamKiralama = toplamKiralama;
            ViewBag.toplamHarcama = toplamHarcama;
            ViewBag.toplamYorum = toplamYorum;

            return View(hmpg);
        }

        public PartialViewResult kullanıcıKiralama()
        {
            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            var kiralamalar = ctx.KiralamaHarekets.Where(x => x.Kullanıcıid == kullanıcıID).OrderByDescending(y=>y.KiralamaId).ToList();
            return PartialView(kiralamalar);
        }

        public PartialViewResult kullanıcıYorum()
        {
            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            var yorumlar = ctx.Commentss.Where(x => x.Kullanıcıid == kullanıcıID).ToList();
            return PartialView(yorumlar);
        }

        public ActionResult Yorumsil(int id)
        {
            var cmnt = ctx.Commentss.Find(id);
            ctx.Commentss.Remove(cmnt);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KullanıcıKiralamalarListe()
        {
            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            var kiralamalar = ctx.KiralamaHarekets.Where(x => x.Kullanıcıid == kullanıcıID).ToList();
            return View(kiralamalar);
        }
        public PartialViewResult ProfilGetir()
        {

            var mail = User.Identity.Name.ToString();
            var kullanıcıID = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            var kullanıcı = ctx.Kullanıcıs.Find(kullanıcıID);
            return PartialView("ProfilGetir", kullanıcı);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfilGüncelle(Kullanıcı k)
        {


            if (Request.Files.Count > 0 && k.Image != null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string yol = "~/Assets/Users/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                k.Image = "/Assets/Users/" + dosyaadi;
                var kullanıcı = ctx.Kullanıcıs.Find(k.KullanıcıId);
                kullanıcı.Ad = k.Ad;
                kullanıcı.Soyad = k.Soyad;
                kullanıcı.Sehir = k.Sehir;
                kullanıcı.Mail = k.Mail;
                kullanıcı.Image = k.Image;
                kullanıcı.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                ctx.SaveChanges();
            }
            else
            {
                var kullanıcı = ctx.Kullanıcıs.Find(k.KullanıcıId);
                kullanıcı.Ad = k.Ad;
                kullanıcı.Soyad = k.Soyad;
                kullanıcı.Sehir = k.Sehir;
                kullanıcı.Mail = k.Mail;
                kullanıcı.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }


    }
}