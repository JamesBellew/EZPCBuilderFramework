using Microsoft.EntityFrameworkCore.Migrations;

namespace EZPCBuilder.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Graphics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    VRAM = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    BaseSpeed = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    BoostSpeed = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graphics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ModelNum = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Latency = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false),
                    BaseSpeed = table.Column<decimal>(type: "Decimal(5,5)", nullable: false),
                    BoostSpeed = table.Column<decimal>(type: "Decimal(5,5)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Connection = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Graphics");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "Processor");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
