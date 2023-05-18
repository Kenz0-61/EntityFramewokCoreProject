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
    public class FluentApiKitapDetayKonfigrasyonu : IEntityTypeConfiguration<FluentApi_KitapDetay>
    {
        public void Configure(EntityTypeBuilder<FluentApi_KitapDetay> builder)
        {

            //FluentApi_KitapDetay için
            builder.HasKey(a => a.KitapDetay_ID);
            builder.Property(a => a.BolumSayisi).IsRequired();

        }
    }
}
