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
    public class FluentApiKitapKonfigrasyonu : IEntityTypeConfiguration<FluentApi_Kitap>
    {
        public void Configure(EntityTypeBuilder<FluentApi_Kitap> builder)
        {

            //FluentApi_Kitap

            builder.HasKey(a => a.KitapId);
            builder.Property(a => a.KitapAdi).IsRequired();
            builder.Property(a => a.Fiyat).IsRequired();
            builder.Property(a => a.ISBN).HasMaxLength(13);

            //FluentApi_Kitap ile FluentApi_KitapDetay ile birebir ilişki

            builder.HasOne(a => a.KitapDetayEntity).WithOne(a => a.FluentApi_KitapEntity).HasForeignKey<FluentApi_Kitap>("KitapDetay_ID"); //Birebir için WithOne() // Bire Çok İlişki İçin WithMany() metodlarıkullanılmalıdır.

            //FluentApi_Kitap ile FluentApiYayinEvi Bire Çok İlişki Kurulması

            builder.HasOne(a => a.FluentApi_YayinEviEntity).WithMany(a => a.Fluent_Api_Kitap).HasForeignKey(a => a.YayinEvi_Id);


            
        }
    }
}
