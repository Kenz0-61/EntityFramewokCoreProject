using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleBirebirIlişkiKitapVeKitapDetayTablosuDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Kategoriler_Kategori_ID",
                table: "Kitaplar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitaplar",
                table: "Kitaplar");

            migrationBuilder.RenameTable(
                name: "Kitaplar",
                newName: "Kitap");

            migrationBuilder.RenameIndex(
                name: "IX_Kitaplar_Kategori_ID",
                table: "Kitap",
                newName: "IX_Kitap_Kategori_ID");

            migrationBuilder.AddColumn<int>(
                name: "KitapDetay_ID",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitap",
                table: "Kitap",
                column: "KitapId");

            migrationBuilder.CreateTable(
                name: "KitapDetay",
                columns: table => new
                {
                    KitapDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumSayisi = table.Column<int>(type: "int", nullable: false),
                    KitapSayfasi = table.Column<int>(type: "int", nullable: false),
                    Agırlık = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapDetay", x => x.KitapDetayID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Kategoriler_Kategori_ID",
                table: "Kitap",
                column: "Kategori_ID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                principalTable: "KitapDetay",
                principalColumn: "KitapDetayID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Kategoriler_Kategori_ID",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.DropTable(
                name: "KitapDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitap",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.RenameTable(
                name: "Kitap",
                newName: "Kitaplar");

            migrationBuilder.RenameIndex(
                name: "IX_Kitap_Kategori_ID",
                table: "Kitaplar",
                newName: "IX_Kitaplar_Kategori_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitaplar",
                table: "Kitaplar",
                column: "KitapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Kategoriler_Kategori_ID",
                table: "Kitaplar",
                column: "Kategori_ID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
