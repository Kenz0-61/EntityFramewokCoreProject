using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    //[Table("Yazar_Tbl")]
    public class Yazar
    {
        [Key]
        public int Yazar_ID { get; set; }

        [Required]
        public String YazarAdi { get; set; }

        [Required]
        public string YazarSoyadi { get; set; }

        public string Lokasyon { get; set; }

        public DateTime DogumTarihi { get; set; }

        [NotMapped]
        public string YazarAdSoyad
        { get
            {
                return $"{YazarAdi} {YazarSoyadi}";
            } }

        public ICollection<KitapYazar> KitapYazarlar { get; set; } // ÇokaÇok İlişki
    }

}
