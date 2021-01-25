using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Galeri
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string Image { get; set; }
        public int Arabaid { get; set; }
        public virtual Arabalar Arabalar { get; set; }
    }
}