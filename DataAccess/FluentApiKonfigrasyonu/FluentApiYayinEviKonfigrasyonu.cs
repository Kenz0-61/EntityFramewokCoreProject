using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FluentApiKonfigrasyonu
{
    public class FluentApiYayinEviKonfigrasyonu : IEntityTypeConfiguration<FluentApi_YayinEvi>
    {
        public void Configure(EntityTypeBuilder<FluentApi_YayinEvi> builder)
        {
            //FluentApi_YayinEvi

            builder.HasKey(a => a.YayinEvi_Id);
            builder.Property(a => a.YayinEviAdi).IsRequired();
            builder.Property(a => a.Lokasyon).IsRequired();
        }
    }
}
