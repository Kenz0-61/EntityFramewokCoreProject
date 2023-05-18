using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using System.Security.Cryptography.X509Certificates;
using DataAccess.FluentApiKonfigrasyonu;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=ENES-EROGLU\SQLEXPRESS;Initial Catalog=Panel;Integrated Security=True");
        //}

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<DataAnnotationsMüsteri> Musterilerr { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<Kitap> KitapDetay { get; set; }

        public DbSet<KitapYazar> KitapYazarlar { get; set; }
        
        //FluentApi Tabloları
        public DbSet<FluentApi_Kitap> fluentApi_Kitaplar { get; set; }
        public DbSet<FluentApi_KitapDetay> fluentApi_KitapDetay { get; set; }
        //public DbSet<FluentApi_KitapYazar> fluentApi_KitapYazarlar { get; set; }
        public DbSet<FluentApi_YayinEvi> fluentApi_YayinEvleri { get; set; }
        public DbSet<FluentApi_Yazar> fluentApi_Yazarlar { get; set; }
        //FluentApi ile configrasyon işlemi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite Key Oluşturamk için yazılan kod satırı
            //KitapYazarlar tablosunda iki kolonu PK olarak ayarlama...
            modelBuilder.Entity<KitapYazar>().HasKey(x => new { x.YazarID, x.KitapID });

            //Profosyonel yaklasım datanotaitons degil fluent api olarak context sınıfı içierisinde database ayarlamalarını yapmaktır.
           

            //KatagorAd ve Kategori Kolon Ad Değiştirme

            modelBuilder.Entity<Kategori>().ToTable("tbl_Kategori");
            modelBuilder.Entity<Kategori>().Property(b => b.KategoriAdi).HasColumnName("Kategori_ADI");


            modelBuilder.ApplyConfiguration(new FluentApiKitapDetayKonfigrasyonu());
            modelBuilder.ApplyConfiguration(new FluentApiKitapKonfigrasyonu());
            modelBuilder.ApplyConfiguration(new FluentApiKitapYazarKonfigrasyonu());
            modelBuilder.ApplyConfiguration(new FluentApiYayinEviKonfigrasyonu());
            modelBuilder.ApplyConfiguration(new FluentApiYazarKonfigrasyonu());
        }

    }
}
