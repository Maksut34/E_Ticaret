using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_TicaretDAL.Migrations
{
    public partial class uıbasket_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UIBasket_2",
                columns: table => new
                {
                    uuıbasket_2_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalproductprice = table.Column<double>(type: "float", nullable: false),
                    totalprice = table.Column<double>(type: "float", nullable: false),
                    cargo = table.Column<double>(type: "float", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIBasket_2", x => x.uuıbasket_2_Id);
                    table.ForeignKey(
                        name: "FK_UIBasket_2_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UIBasket_2_UsersId",
                table: "UIBasket_2",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UIBasket_2");
        }
    }
}
