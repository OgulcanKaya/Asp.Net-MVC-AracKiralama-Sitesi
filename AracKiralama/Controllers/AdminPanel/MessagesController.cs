using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    public class MessagesController : Controller
    {
        Context ctx = new Context();
        // GET: Messages
        public ActionResult Index()
        {
            var messages = ctx.Messages.OrderByDescending(x => x.messageid).ToList();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View(messages);
        }

        public ActionResult MesajGetir(int id)
        {
            var msg = ctx.Messages.Where(x => x.messageid == id).FirstOrDefault();
            var mail = User.Identity.Name.ToString();
            var ad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Ad).FirstOrDefault();
            var soyad = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Soyad).FirstOrDefault();
            var image = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.Image).FirstOrDefault();
            var KullanıcıId = ctx.Kullanıcıs.Where(x => x.Mail == mail).Select(y => y.KullanıcıId).FirstOrDefault();
            ViewBag.KullanıcıId = KullanıcıId;
            ViewBag.ad = ad;
            ViewBag.soyad = soyad;
            ViewBag.image = image;
            return View("MesajGetir",msg);

        }

        [HttpPost]
        public ActionResult MesajGüncelle(Messages messages) 
        {
            var msg = ctx.Messages.Find(messages.messageid);
            msg.status = messages.status;
            msg.updated_at = DateTime.Parse(DateTime.Today.ToShortDateString());
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MesajSil(int id)
        {
            var msg = ctx.Messages.Find(id);
            ctx.Messages.Remove(msg);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}