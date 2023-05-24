using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class YayinEvi
    {
        public ICollection<Kitap> Kitaplar { get; set; } /*= new List<Kitap>();*/ //List olarak eklenerek bire çok ilişki  gerçekleştirmektedir.

        [Key]
        public int YayinEvi_Id { get; set; }
        [Required]
        public string YayinEviAdi { get; set; }
        [Required]
        public string Lokasyon { get; set; }

        [NotMapped]
        public int YayinEviDetay { get; set; }
        
        
    }
}
