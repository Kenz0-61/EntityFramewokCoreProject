using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        [Required]
        public string KitapAdi { get; set; }

        [Required]
        public double Fiyat { get; set; }
        [Required]
        [MaxLength(13)]
        public string ISBN { get;  set; }
        // Kategori Tablosu ile İlişkilendirme yapılmaktadır.
        [ForeignKey("Kategori")]
        public int Kategori_ID { get; set; }
        public Kategori Kategori { get; set; }


        [ForeignKey("KitapDetay")]
        public int KitapDetay_ID { get; set; }
        public KitapDetay KitapDetay { get; set; }


        [ForeignKey("YayinEvi")] //ForeignKey DataAnatations'a ForeignKey yapılacak Tablo Objesi Verilmelidir.
        public int YayinEvi_ID { get; set; }
        public YayinEvi YayinEvi { get; set; }//entitty

        public ICollection<KitapYazar> KitapYazarlar { get; set; } // ÇokaÇok İlişki
    }
}
