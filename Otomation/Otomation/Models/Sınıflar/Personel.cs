using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Otomation.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonalGorsel { get; set; } 
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
    }
}