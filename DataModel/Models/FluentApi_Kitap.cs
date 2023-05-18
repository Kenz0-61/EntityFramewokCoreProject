using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FluentApi_Kitap
    {
        public int KitapId { get; set; }

        public string KitapAdi { get; set; }


        public double Fiyat { get; set; }

        public string ISBN { get; set; }

        public FluentApi_KitapDetay KitapDetayEntity { get; set; }
        public int KitapDetay_ID { get; set; }

        public FluentApi_YayinEvi FluentApi_YayinEviEntity { get; set; }

        public int YayinEvi_Id { get; set; }


        public ICollection<FluentApi_KitapYazar> FluentApi_KitapYazar { get; set; } // ÇokaÇokİlişki



    }
}
