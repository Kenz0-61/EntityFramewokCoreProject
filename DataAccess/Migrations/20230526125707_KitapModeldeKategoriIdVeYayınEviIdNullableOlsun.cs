using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KitapModeldeKategoriIdVeYayınEviIdNullableOlsun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "YayinEvi_ID",
                table: "Kitap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Kategori_ID",
                table: "Kitap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap",
                column: "YayinEvi_ID",
                principalTable: "YayinEvleri",
                principalColumn: "YayinEvi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap",
                column: "Kategori_ID",
                principalTable: "tbl_Kategori",
                principalColumn: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "YayinEvi_ID",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kategori_ID",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap",
                column: "YayinEvi_ID",
                principalTable: "YayinEvleri",
                principalColumn: "YayinEvi_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap",
                column: "Kategori_ID",
                principalTable: "tbl_Kategori",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
