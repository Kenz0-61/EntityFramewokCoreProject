using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class KitapDetay
    {
        public int KitapDetayID { get; set; }

        [Required]
        public int BolumSayisi { get;set; }

        public int KitapSayfasi { get; set; }

        public double Agırlık { get; set; }

        public Kitap Kitap { get; set; }//entity olarak eklenip kitap detay birebir ilişki oluşturulmaktadır
    }
}
