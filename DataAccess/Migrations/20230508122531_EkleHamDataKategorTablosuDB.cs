using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EkleHamDataKategorTablosuDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tbl_Kategori VALUES('Roman')");
            migrationBuilder.Sql("INSERT INTO tbl_Kategori VALUES('Şiir')");
            migrationBuilder.Sql("INSERT INTO tbl_Kategori VALUES('Bilim')");
            migrationBuilder.Sql("INSERT INTO tbl_Kategori VALUES('Ders')");
            migrationBuilder.Sql("INSERT INTO tbl_Kategori VALUES('YabancıDil')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
