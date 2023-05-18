using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    [Table("Musteriler")]
    public class DataAnnotationsMüsteri
    {
        [Key]
        public int Musteri_Id { get; set; }

        [Required]
        [MaxLength(11)]
        public string Musteri_TcNo { get; set; }

        [Column("MusteriAdi")]
        [Required]
        public string Musteri_Name { get; set; }

        [Column("MusteriAcıklama")]
        public string Musteri_Description { get; set; }

        [Column("MusteriTipi")]
        [Required]
        public bool Musteri_Type { get; set; }
    }
}
