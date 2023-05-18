using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleFluentApiTablolarınıTopluEklemeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitapYazarlar_Yazar_Tbl_YazarID",
                table: "KitapYazarlar");

            migrationBuilder.CreateTable(
                name: "fluentApi_Kitaplar",
                columns: table => new
                {
                    KitapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fluentApi_Kitaplar", x => x.KitapId);
                });

            migrationBuilder.CreateTable(
                name: "fluentApi_YayinEvleri",
                columns: table => new
                {
                    YayinEvi_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fluentApi_YayinEvleri", x => x.YayinEvi_Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Yazar_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Yazar_ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_KitapYazarlar_Yazarlar_YazarID",
                table: "KitapYazarlar",
                column: "YazarID",
                principalTable: "Yazarlar",
                principalColumn: "Yazar_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitapYazarlar_Yazarlar_YazarID",
                table: "KitapYazarlar");

            migrationBuilder.DropTable(
                name: "fluentApi_Kitaplar");

            migrationBuilder.DropTable(
                name: "fluentApi_YayinEvleri");

            migrationBuilder.DropTable(
                name: "Yazarlar");

            migrationBuilder.AddForeignKey(
                name: "FK_KitapYazarlar_Yazar_Tbl_YazarID",
                table: "KitapYazarlar",
                column: "YazarID",
                principalTable: "Yazar_Tbl",
                principalColumn: "Yazar_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
