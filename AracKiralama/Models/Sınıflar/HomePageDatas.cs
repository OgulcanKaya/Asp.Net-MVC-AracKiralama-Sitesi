using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class HomePageDatas
    {

        public IEnumerable<Kategori> Kategoris { get; set; }
        public IEnumerable<Setting> Settings { get; set; }
        public IEnumerable<Arabalar> Arabalars { get; set; }
        public IEnumerable<Arabalar> SeciliArabalar { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
        public IEnumerable<Galeri> Galeris { get; set; }
        public IEnumerable<Kullanıcı> Kullanıcıs { get; set; }
        public IEnumerable<Kullanıcı> Kullanıcıs2 { get; set; }
        public IEnumerable<KiralamaHareket> KiralamaHarekets { get; set; }
        public IEnumerable<SSS> SSSes { get; set; }


    }
}