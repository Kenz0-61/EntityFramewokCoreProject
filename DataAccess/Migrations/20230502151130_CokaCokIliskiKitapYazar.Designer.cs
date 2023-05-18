﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230502151130_CokaCokIliskiKitapYazar")]
    partial class CokaCokIliskiKitapYazar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModel.Models.DataAnnotationsMüsteri", b =>
                {
                    b.Property<int>("Musteri_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Musteri_Id"));

                    b.Property<string>("Musteri_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MusteriAcıklama");

                    b.Property<string>("Musteri_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MusteriAdi");

                    b.Property<string>("Musteri_TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("Musteri_Type")
                        .HasColumnType("bit")
                        .HasColumnName("MusteriTipi");

                    b.HasKey("Musteri_Id");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("DataModel.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"));

                    b.Property<string>("KategoriAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("DataModel.Models.Kitap", b =>
                {
                    b.Property<int>("KitapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitapId"));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Kategori_ID")
                        .HasColumnType("int");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KitapDetay_ID")
                        .HasColumnType("int");

                    b.Property<int>("YayinEvi_ID")
                        .HasColumnType("int");

                    b.HasKey("KitapId");

                    b.HasIndex("Kategori_ID");

                    b.HasIndex("KitapDetay_ID")
                        .IsUnique();

                    b.HasIndex("YayinEvi_ID");

                    b.ToTable("Kitap");
                });

            modelBuilder.Entity("DataModel.Models.KitapDetay", b =>
                {
                    b.Property<int>("KitapDetayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitapDetayID"));

                    b.Property<double>("Agırlık")
                        .HasColumnType("float");

                    b.Property<int>("BolumSayisi")
                        .HasColumnType("int");

                    b.Property<int>("KitapSayfasi")
                        .HasColumnType("int");

                    b.HasKey("KitapDetayID");

                    b.ToTable("KitapDetay");
                });

            modelBuilder.Entity("DataModel.Models.KitapYazar", b =>
                {
                    b.Property<int>("YazarID")
                        .HasColumnType("int");

                    b.Property<int>("KitapID")
                        .HasColumnType("int");

                    b.HasKey("YazarID", "KitapID");

                    b.HasIndex("KitapID");

                    b.ToTable("KitapYazarlar");
                });

            modelBuilder.Entity("DataModel.Models.Tur", b =>
                {
                    b.Property<int>("TurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurId"));

                    b.Property<string>("Elma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurId");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("DataModel.Models.YayinEvi", b =>
                {
                    b.Property<int>("YayinEvi_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YayinEvi_Id"));

                    b.Property<string>("Lokasyon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YayinEviAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YayinEvi_Id");

                    b.ToTable("YayinEvleri");
                });

            modelBuilder.Entity("DataModel.Models.Yazar", b =>
                {
                    b.Property<int>("Yazar_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Yazar_ID"));

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lokasyon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazarAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YazarSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Yazar_ID");

                    b.ToTable("Yazar_Tbl");
                });

            modelBuilder.Entity("DataModel.Models.Kitap", b =>
                {
                    b.HasOne("DataModel.Models.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("Kategori_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Models.KitapDetay", "KitapDetay")
                        .WithOne("Kitap")
                        .HasForeignKey("DataModel.Models.Kitap", "KitapDetay_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Models.YayinEvi", "YayinEvi")
                        .WithMany("Kitap")
                        .HasForeignKey("YayinEvi_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("KitapDetay");

                    b.Navigation("YayinEvi");
                });

            modelBuilder.Entity("DataModel.Models.KitapYazar", b =>
                {
                    b.HasOne("DataModel.Models.Kitap", "Kitap")
                        .WithMany("KitapYazarlar")
                        .HasForeignKey("KitapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Models.Yazar", "Yazar")
                        .WithMany("KitapYazarlar")
                        .HasForeignKey("YazarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitap");

                    b.Navigation("Yazar");
                });

            modelBuilder.Entity("DataModel.Models.Kitap", b =>
                {
                    b.Navigation("KitapYazarlar");
                });

            modelBuilder.Entity("DataModel.Models.KitapDetay", b =>
                {
                    b.Navigation("Kitap")
                        .IsRequired();
                });

            modelBuilder.Entity("DataModel.Models.YayinEvi", b =>
                {
                    b.Navigation("Kitap");
                });

            modelBuilder.Entity("DataModel.Models.Yazar", b =>
                {
                    b.Navigation("KitapYazarlar");
                });
#pragma warning restore 612, 618
        }
    }
}
