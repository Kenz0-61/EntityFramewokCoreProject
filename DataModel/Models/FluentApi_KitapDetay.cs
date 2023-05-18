using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FluentApi_KitapDetay
    {
        public int KitapDetay_ID { get; set; }

        
        public int BolumSayisi { get;set; }

        public int KitapSayfasi { get; set; }

        public double Agırlık { get; set; }

        public FluentApi_Kitap FluentApi_KitapEntity { get; set; }

        
    }
}
