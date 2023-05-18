using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FluentApi_KitapYazar
    {
        
        public int KitapID { get; set; }

        
        public int YazarID { get; set; }

        public FluentApi_Kitap FluentApi_Kitap { get; set; }  //Coka Cok İlişk NAvigation Property
                                                              
        public FluentApi_Yazar  FluentApi_Yazar { get; set; } //Coka Cok İlişk NAvigation Property
        
    }
}
