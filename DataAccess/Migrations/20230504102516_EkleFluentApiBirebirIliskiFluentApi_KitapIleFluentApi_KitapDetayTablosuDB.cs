using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleFluentApiBirebirIliskiFluentApi_KitapIleFluentApi_KitapDetayTablosuDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapDetay_ID",
                table: "fluentApi_Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fluentApi_Kitaplar_KitapDetay_ID",
                table: "fluentApi_Kitaplar",
                column: "KitapDetay_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fluentApi_Kitaplar_fluentApi_KitapDetay_KitapDetay_ID",
                table: "fluentApi_Kitaplar",
                column: "KitapDetay_ID",
                principalTable: "fluentApi_KitapDetay",
                principalColumn: "KitapDetay_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fluentApi_Kitaplar_fluentApi_KitapDetay_KitapDetay_ID",
                table: "fluentApi_Kitaplar");

            migrationBuilder.DropIndex(
                name: "IX_fluentApi_Kitaplar_KitapDetay_ID",
                table: "fluentApi_Kitaplar");

            migrationBuilder.DropColumn(
                name: "KitapDetay_ID",
                table: "fluentApi_Kitaplar");
        }
    }
}
