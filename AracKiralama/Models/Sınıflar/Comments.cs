using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Comments
    {
        [Key]
        public int ıd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Comment { get; set;}

        public int Rate { get; set; }
        public bool Status { get; set; }
        public DateTime Created_at{ get; set; }
        public DateTime Updated_at{ get; set; }

        public int Kullanıcıid { get; set; }
        public int Arabaid { get; set; }
        public virtual Kullanıcı Kullanıcıs { get; set; }
        public virtual Arabalar Arabalars { get; set; }


    }
}