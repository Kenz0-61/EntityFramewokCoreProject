using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DegistirKategorTablosundaTabloAdıVeKategoriAdıDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategoriler_Kategori_ID",
                table: "Kitap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "tbl_Kategori");

            migrationBuilder.RenameColumn(
                name: "KategoriAdi",
                table: "tbl_Kategori",
                newName: "Kategori_ADI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Kategori",
                table: "tbl_Kategori",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap",
                column: "Kategori_ID",
                principalTable: "tbl_Kategori",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Kategori",
                table: "tbl_Kategori");

            migrationBuilder.RenameTable(
                name: "tbl_Kategori",
                newName: "Kategoriler");

            migrationBuilder.RenameColumn(
                name: "Kategori_ADI",
                table: "Kategoriler",
                newName: "KategoriAdi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Kategoriler_Kategori_ID",
                table: "Kitap",
                column: "Kategori_ID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
