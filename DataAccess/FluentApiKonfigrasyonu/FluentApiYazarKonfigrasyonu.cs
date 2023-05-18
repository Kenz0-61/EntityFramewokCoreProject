using DataModel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace DataAccess.FluentApiKonfigrasyonu
{
    public class FluentApiYazarKonfigrasyonu : IEntityTypeConfiguration<FluentApi_Yazar>
    {
        public void Configure(EntityTypeBuilder<FluentApi_Yazar> builder)
        {
            //FluentApi_Yazar

            builder.HasKey(a => a.Yazar_ID);
            builder.Property(a => a.YazarAdi).IsRequired();
            builder.Property(a => a.YazarSoyadi).IsRequired();
            builder.Ignore(a => a.YazarAdSoyad); //DataAnatations'da NotMapped
        }
    }
}