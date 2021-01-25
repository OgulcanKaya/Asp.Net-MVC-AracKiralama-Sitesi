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
    public class KategoriController : Controller
    {
        // GET:Kategori
        Context ctx = new Context();
        public ActionResult Kategori(int sayfa =1)
        {
            var kategoriler = ctx.Kategoris.ToList().ToPagedList(sayfa,5);
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult KategoriEkle() {


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