using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AracKiralama.Models.Sınıflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Arabalar> Arabalars{ get; set; }
        public DbSet<Comments> Commentss { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars{ get; set; }
        public DbSet<Kategori> Kategoris{ get; set; }
        public DbSet<KiralamaHareket> KiralamaHarekets{ get; set; }
        public DbSet<Kullanıcı> Kullanıcıs{ get; set; }
        public DbSet<Setting> Settings{ get; set; }
        public DbSet<Galeri> Galeris{ get; set; }
        public DbSet<Messages> Messages{ get; set; }


         


    }
}