using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Models.Sınıflar
{
    public class Arabalar
    {
        
        [Key]
        public int ArabaId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Keywords { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Marka { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Image { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Model { get; set; }

        [AllowHtml]
        public string Detail { get; set; }


        public String Sehir { get; set; }
        public int Motorgücü { get; set; }
        public int Yıl { get; set; }
        public int Vites { get; set; }
        public int Km { get; set; }
        public int Fiyat { get; set; }
        public bool Status { get; set; }
        public bool Kirada { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_at { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<KiralamaHareket> KiralamaHarekets { get; set; }
        public ICollection<Comments> Commentss { get; set; }
        public ICollection<Galeri> Galeris { get; set; }

    }
}