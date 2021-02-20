using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Models.Sınıflar
{
    public class SSS
    {
        [Key]
        public int id { get; set; }
        public int position { get; set; }
        public string soru { get; set; }

        [AllowHtml]
        public string cevap { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}