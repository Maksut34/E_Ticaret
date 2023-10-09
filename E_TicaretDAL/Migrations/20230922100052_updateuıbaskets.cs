using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_TicaretDAL.Migrations
{
    public partial class updateuıbaskets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cargo",
                table: "UIBasket");

            migrationBuilder.DropColumn(
                name: "totalprice",
                table: "UIBasket");

            migrationBuilder.DropColumn(
                name: "totalproductprice",
                table: "UIBasket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "cargo",
                table: "UIBasket",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalprice",
                table: "UIBasket",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalproductprice",
                table: "UIBasket",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
