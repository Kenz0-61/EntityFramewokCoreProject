using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FluentApi_YayinEvi
    {
        
        public int YayinEvi_Id { get; set; }
        
        public string YayinEviAdi { get; set; }
        
        public string Lokasyon { get; set; }

        public List<FluentApi_Kitap> Fluent_Api_Kitap { get; set; }



    }
}
