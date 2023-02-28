using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otomation.Models.Sınıflar
{
    public class SatisHaraket
    {
        [Key]
        public int Satisid { get; set; }
        public DateTime Tarihi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamFutar { get; set; }
        public int urunid { get; set; }
        public virtual Urun Urun{ get; set; }
        public int Cariid { get; set; }
        public virtual Cari Cari { get; set; }
        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
    }
}