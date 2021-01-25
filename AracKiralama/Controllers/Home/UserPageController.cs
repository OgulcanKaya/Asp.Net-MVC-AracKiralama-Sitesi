using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models.Sınıflar;

namespace AracKiralama.Controllers.Home
{
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

            return View(hmpg);
        }
    }
}