using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleFluentApiIleBireCokIliskiFluentApi_KitapVeFluentApi_YayinEviDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YayinEvi_Id",
                table: "fluentApi_Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fluentApi_Kitaplar_YayinEvi_Id",
                table: "fluentApi_Kitaplar",
                column: "YayinEvi_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fluentApi_Kitaplar_fluentApi_YayinEvleri_YayinEvi_Id",
                table: "fluentApi_Kitaplar",
                column: "YayinEvi_Id",
                principalTable: "fluentApi_YayinEvleri",
                principalColumn: "YayinEvi_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fluentApi_Kitaplar_fluentApi_YayinEvleri_YayinEvi_Id",
                table: "fluentApi_Kitaplar");

            migrationBuilder.DropIndex(
                name: "IX_fluentApi_Kitaplar_YayinEvi_Id",
                table: "fluentApi_Kitaplar");

            migrationBuilder.DropColumn(
                name: "YayinEvi_Id",
                table: "fluentApi_Kitaplar");
        }
    }
}
