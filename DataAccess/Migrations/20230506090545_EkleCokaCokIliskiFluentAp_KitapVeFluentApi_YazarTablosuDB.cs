using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleCokaCokIliskiFluentAp_KitapVeFluentApi_YazarTablosuDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentApi_KitapYazar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentApi_KitapYazar", x => new { x.YazarID, x.KitapID });
                    table.ForeignKey(
                        name: "FK_FluentApi_KitapYazar_Yazar_Tbl_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazar_Tbl",
                        principalColumn: "Yazar_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentApi_KitapYazar_fluentApi_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "fluentApi_Kitaplar",
                        principalColumn: "KitapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentApi_KitapYazar_KitapID",
                table: "FluentApi_KitapYazar",
                column: "KitapID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentApi_KitapYazar");
        }
    }
}
