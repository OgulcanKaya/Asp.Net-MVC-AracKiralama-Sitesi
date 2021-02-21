using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Kullanıcı
    {
        [Key]
        public int KullanıcıId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Ad{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Soyad{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Sehir{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Password { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Image { get; set; }
        public string Yetki { get; set; }

        public bool Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        
        public ICollection<KiralamaHareket> KiralamaHarekets { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}