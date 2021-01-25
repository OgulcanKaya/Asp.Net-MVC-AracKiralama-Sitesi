using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;


namespace AracKiralama.Controllers.AdminPanel
{
    public class CommentController : Controller
    {
        // GET: Comment

        Context ctx = new Context();
        public ActionResult Index()
        {
            var cmnt = ctx.Commentss.Where(x => x.Status == true).ToList();
            return View(cmnt);
        }

        public ActionResult CommentDetay(int id)
        {
            var cmnt = ctx.Commentss.Where(x => x.ıd == id).ToList();
            return View(cmnt);
        }



        public ActionResult YorumSil(int id)
        {
            var cmnt = ctx.Commentss.Find(id);
            cmnt.Status = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YorumAktifEt(int id)
        {
            var cmnt = ctx.Commentss.Find(id);
            cmnt.Status = true;
            ctx.SaveChanges();
            return RedirectToAction("SilinenComment");
           
        }

        public ActionResult SilinenComment()
        {
            var cmnt = ctx.Commentss.Where(x => x.Status == false).ToList();

            return View(cmnt);

        }

    }
}