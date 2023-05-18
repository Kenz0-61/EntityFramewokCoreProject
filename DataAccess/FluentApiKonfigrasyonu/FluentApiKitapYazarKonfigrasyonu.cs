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
    public class FluentApiKitapYazarKonfigrasyonu : IEntityTypeConfiguration<FluentApi_KitapYazar>
    {
        public void Configure(EntityTypeBuilder<FluentApi_KitapYazar> builder)
        {

            //FluentAPi_Kitap Ve FluentApi_Yazar Tablosunda ÇokaÇok ilişki

            builder.HasKey(ab => new { ab.YazarID, ab.KitapID }); // iki tane primarykey tanımlanıcağı için new keywordu kullanılmaktadır. Tek olsa idi new keywordu kullanmamıza gerek kalmaz.
            builder.HasOne(a => a.FluentApi_Kitap).WithMany(a => a.FluentApi_KitapYazar).HasForeignKey(a => a.KitapID);
            builder.HasOne(a => a.FluentApi_Yazar).WithMany(a => a.FluentApi_KitapYazar).HasForeignKey(a => a.YazarID);

        }
    }
}
