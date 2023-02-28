using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Otomation.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int Adminid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}