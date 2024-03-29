﻿// <auto-generated />
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
    [Migration("20230502121850_EkleDataAnnotationsMusterTablosuDB")]
    partial class EkleDataAnnotationsMusterTablosuDB
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
#pragma warning restore 612, 618
        }
    }
}
