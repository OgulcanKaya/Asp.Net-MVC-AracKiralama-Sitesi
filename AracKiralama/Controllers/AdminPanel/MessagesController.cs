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

            return View(messages);
        }

        public ActionResult MesajGetir(int id)
        {
            var msg = ctx.Messages.Where(x => x.messageid == id).FirstOrDefault();
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