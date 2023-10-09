using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_TicaretDAL.Migrations
{
    public partial class uıbasket_2update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productcount",
                table: "UIBasket_2",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productcount",
                table: "UIBasket_2");
        }
    }
}
