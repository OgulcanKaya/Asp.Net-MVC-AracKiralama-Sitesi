using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string Password { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Role { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Image { get; set; }

        public string Status { get; set; }  
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
       





    }
}