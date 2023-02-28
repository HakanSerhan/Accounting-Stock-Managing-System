using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Otomation.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int Cariid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariMail { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }


    }
}