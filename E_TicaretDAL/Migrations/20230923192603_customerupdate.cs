using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_TicaretDAL.Migrations
{
    public partial class customerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Customer",
                newName: "name_surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customer",
                newName: "cardnumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name_surname",
                table: "Customer",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "cardnumber",
                table: "Customer",
                newName: "name");
        }
    }
}
