using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemıd { get; set; }
        public string Detail { get; set; }
        public int Gün { get; set; }
        public decimal Tutar { get; set; }
        public int Faturaid { get; set; }
        public virtual Faturalar Faturalar { get; set; }

    }
}