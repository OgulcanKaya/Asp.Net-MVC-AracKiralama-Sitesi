using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Models.Sınıflar
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Harita { get; set; }
        public string Address{ get; set; }
        public string Smtpserver { get; set; }
        public string Smtpemail { get; set; }
        public string Smtppassword { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        [AllowHtml]
        public string Aboutus{ get; set; }
        [AllowHtml]
        public string Contactus { get; set; }
        [AllowHtml]
        public string References { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_at { get; set; }
    }
}