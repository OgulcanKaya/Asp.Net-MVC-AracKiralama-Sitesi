using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AracKiralama.Models.Sınıflar
{
    public class Kategori
    {
      
        [Key]
        public int KategoriId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_at { get; set; }
        public ICollection<Arabalar> Cars { get; set; }
    }
}