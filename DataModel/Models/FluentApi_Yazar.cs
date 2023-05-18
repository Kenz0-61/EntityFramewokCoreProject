using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    [Table("Yazar_Tbl")]
    public class FluentApi_Yazar
    {
        
        public int Yazar_ID { get; set; }

        
        public String YazarAdi { get; set; }

        
        public string YazarSoyadi { get; set; }

        public string Lokasyon { get; set; }

        public DateTime DogumTarihi { get; set; }

        
        public string YazarAdSoyad
        { get
            {
                return $"{YazarAdi} {YazarSoyadi}";
            } }

        public ICollection<FluentApi_KitapYazar> FluentApi_KitapYazar { get; set; } // ÇokaÇok İlişki
    }

}
