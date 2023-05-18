using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleBireÇokIlişkiKitapVeKitapYayinEviDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayinEvi_ID",
                table: "Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YayinEvi_ID",
                table: "Kitap",
                column: "YayinEvi_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap",
                column: "YayinEvi_ID",
                principalTable: "YayinEvleri",
                principalColumn: "YayinEvi_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_YayinEvleri_YayinEvi_ID",
                table: "Kitap");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_YayinEvi_ID",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "YayinEvi_ID",
                table: "Kitap");
        }
    }
}
