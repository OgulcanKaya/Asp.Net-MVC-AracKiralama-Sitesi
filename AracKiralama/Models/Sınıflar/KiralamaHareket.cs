﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class KiralamaHareket
    {
        [Key]
        public int KiralamaId { get; set; }
        public int Arabaid { get; set; }
        public int Kullanıcıid { get; set; }
        public virtual Arabalar Arabalar { get; set; }
        public virtual Kullanıcı Kullanıcı { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime TeslimTarih { get; set; }
        public int GünSayısı { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }


    }
}