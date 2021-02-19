using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Messages
    {
        [Key]
        public int messageid { get; set; }
        [Required]
        public string isim { get; set; }
        [Required]
        public string konu { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string message { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
    }
}