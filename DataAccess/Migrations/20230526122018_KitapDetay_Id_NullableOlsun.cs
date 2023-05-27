using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class KitapDetay_Id_NullableOlsun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KitapDetay_ID",
                table: "Kitap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                unique: true,
                filter: "[KitapDetay_ID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                principalTable: "KitapDetay",
                principalColumn: "KitapDetayID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KitapDetay_ID",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_KitapDetay_KitapDetay_ID",
                table: "Kitap",
                column: "KitapDetay_ID",
                principalTable: "KitapDetay",
                principalColumn: "KitapDetayID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
