using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class CarGaleri
    {
        public IEnumerable<Arabalar> Araba { get; set; }
        public IEnumerable<Galeri> Galeris { get; set; }

    }
}