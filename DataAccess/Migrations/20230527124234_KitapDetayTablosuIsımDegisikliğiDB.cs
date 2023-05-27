using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KitapDetayTablosuIsımDegisikliğiDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_tbl_Kategori_Kategori_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapYazarlar_Kitap_KitapID",
                table: "KitapYazarlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KitapDetay",
                table: "KitapDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitap",
                table: "Kitap");

            migrationBuilder.RenameTable(
                name: "KitapDetay",
                newName: "KitapDetaylar");

            migrationBuilder.RenameTable(
                name: "Kitap",
                newName: "Kitaplar");

            migrationBuilder.RenameIndex(
                name: "IX_Kitap_YayinEvi_ID",
                table: "Kitaplar",
                newName: "IX_Kitaplar_YayinEvi_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitaplar",
                newName: "IX_Kitaplar_KitapDetay_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Kitap_Kategori_ID",
                table: "Kitaplar",
                newName: "IX_Kitaplar_Kategori_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KitapDetaylar",
                table: "KitapDetaylar",
                column: "KitapDetayID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitaplar",
                table: "Kitaplar",
                column: "KitapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_KitapDetaylar_KitapDetay_ID",
                table: "Kitaplar",
                column: "KitapDetay_ID",
                principalTable: "KitapDetaylar",
                principalColumn: "KitapDetayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_YayinEvleri_YayinEvi_ID",
                table: "Kitaplar",
                column: "YayinEvi_ID",
                principalTable: "YayinEvleri",
                principalColumn: "YayinEvi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_tbl_Kategori_Kategori_ID",
                table: "Kitaplar",
                column: "Kategori_ID",
                principalTable: "tbl_Kategori",
                principalColumn: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_KitapYazarlar_Kitaplar_KitapID",
                table: "KitapYazarlar",
                column: "KitapID",
                principalTable: "Kitaplar",
                principalColumn: "KitapId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_KitapDetaylar_KitapDetay_ID",
                table: "Kitaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_YayinEvleri_YayinEvi_ID",
                table: "Kitaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_tbl_Kategori_Kategori_ID",
                table: "Kitaplar");

            migrationBuilder.DropForeignKey(
                name: "FK_KitapYazarlar_Kitaplar_KitapID",
                table: "KitapYazarlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitaplar",
                table: "Kitaplar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KitapDetaylar",
                table: "KitapDetaylar");

            migrationBuilder.RenameTable(
                name: "Kitaplar",
                newName: "Kitap");

            migrationBuilder.RenameTable(
                name: "KitapDetaylar",
                newName: "KitapDetay");

            migrationBuilder.RenameIndex(
                name: "IX_Kitaplar_YayinEvi_ID",
                table: "Kitap",
                newName: "IX_Kitap_YayinEvi_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Kitaplar_KitapDetay_ID",
                table: "Kitap",
                newName: "IX_Kitap_KitapDetay_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Kitaplar_Kategori_ID",
                table: "Kitap",
                newName: "IX_Kitap_Kategori_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitap",
                table: "Kitap",
                column: "KitapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KitapDetay",
                table: "KitapDetay",
                column: "KitapDetayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                principalTable: "KitapDetay",
                principalColumn: "KitapDetayID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_KitapYazarlar_Kitap_KitapID",
                table: "KitapYazarlar",
                column: "KitapID",
                principalTable: "Kitap",
                principalColumn: "KitapId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
