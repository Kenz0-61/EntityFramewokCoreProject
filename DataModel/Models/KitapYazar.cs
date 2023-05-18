using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class KitapYazar
    {
        [ForeignKey("Kitap")]
        public int KitapID { get; set; }

        [ForeignKey("Yazar")]
        public int YazarID { get; set; }


        public Kitap Kitap { get; set; }//ÇokaÇok İlişiki için ilgili tablo abjeleri(sınıfları) entitty olarak ekleniyor.
        public Yazar Yazar { get; set;} //ÇokaÇok İlişiki için ilgili tablo abjeleri(sınıfları) entitty olarak ekleniyor.
    }
}
