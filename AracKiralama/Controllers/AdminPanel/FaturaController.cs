using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.AdminPanel
{
    public class FaturaController : Controller
    {
        Context ctx = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var ftr = ctx.Faturalars.ToList();
            return View(ftr);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();

        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            ctx.Faturalars.Add(f);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = ctx.Faturalars.Find(id);

            return View("FaturaGetir", fatura);

        }

        public ActionResult FaturaGüncelle(Faturalar f)
        {
            var ftr = ctx.Faturalars.Find(f.FaturaId);
            ftr.FaturaSeriNo = f.FaturaSeriNo;
            ftr.FaturaSıraNo = f.FaturaSıraNo;
            ftr.FaturaSaat = f.FaturaSaat;
            ftr.FaturaTarih = f.FaturaTarih;
            ftr.ToplamTutar = f.ToplamTutar;
            ftr.TeslimAlan = f.TeslimAlan;
            ftr.TeslimEden = f.TeslimEden;
            ftr.Status = f.Status;
            ctx.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult FaturaDetay(int id)
        {
            var ftr = ctx.FaturaKalems.Where(x => x.Faturaid == id).ToList();

            return View(ftr);

        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem ftrk)
        {
            ctx.FaturaKalems.Add(ftrk);
            ctx.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}