using Microsoft.EntityFrameworkCore.Migrations;

namespace EZPCBuilder.Data.Migrations
{
    public partial class BasketUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketID",
                table: "PC",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    PCID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Basket_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PC_BasketID",
                table: "PC",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserID",
                table: "Basket",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_PC_Basket_BasketID",
                table: "PC",
                column: "BasketID",
                principalTable: "Basket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PC_Basket_BasketID",
                table: "PC");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_PC_BasketID",
                table: "PC");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "PC");
        }
    }
}
