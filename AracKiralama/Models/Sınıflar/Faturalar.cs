using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool Status { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }



    }


}