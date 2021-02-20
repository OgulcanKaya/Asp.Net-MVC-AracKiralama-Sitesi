using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context ctx = new Context();
        public ActionResult Index()
        {
            var kullanıcı = ctx.Kullanıcıs.Count().ToString();
            var kiralama = ctx.KiralamaHarekets.Count().ToString();
            var car = ctx.Arabalars.Count().ToString();
            var ktgr = ctx.Kategoris.Count().ToString();
            var aktifcar = ctx.Arabalars.Where(x=>x.Status == true).Count().ToString();
            var pasifcar = ctx.Arabalars.Where(x => x.Status == false).Count().ToString();
            var cmnt = ctx.Commentss.Count().ToString();
            var message = ctx.Messages.Count().ToString();
            var kazanç = ctx.KiralamaHarekets.Select(x=>x.ToplamTutar).Sum().ToString();
            var aktifkullanıcı = ctx.Kullanıcıs.Where(x => x.Status == true).Count().ToString();
            var pasifkullanıcı = ctx.Kullanıcıs.Where(x => x.Status == false).Count().ToString();
            var fatura = ctx.Faturalars.Count().ToString();
            var bugünkikiralama = ctx.KiralamaHarekets.Count(x => x.Tarih == DateTime.Today).ToString();
            var ençokkiralama = ctx.KiralamaHarekets.GroupBy(x => x.Arabalar.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var enazkiralama = ctx.KiralamaHarekets.GroupBy(x => x.Arabalar.Marka).OrderBy(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var maxmarka = ctx.Arabalars.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();

            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            ViewBag.klc = kullanıcı;
            ViewBag.kira = kiralama;
            ViewBag.car = car;
            ViewBag.ktgr = ktgr;
            ViewBag.aktifcar = aktifcar;
            ViewBag.pasifcar = pasifcar;
            ViewBag.cmnt = cmnt;
            ViewBag.kazanç = kazanç;
            ViewBag.message = message;
            ViewBag.aktifkullanıcı = aktifkullanıcı;
            ViewBag.pasifkullanıcı = pasifkullanıcı;
            ViewBag.fatura = fatura;
            ViewBag.bugünkikiralama = bugünkikiralama;
            ViewBag.ençokkiralama = ençokkiralama;
            ViewBag.enazkiralama = enazkiralama;
            ViewBag.maxmarka = maxmarka;

            return View();
        }
    }
}