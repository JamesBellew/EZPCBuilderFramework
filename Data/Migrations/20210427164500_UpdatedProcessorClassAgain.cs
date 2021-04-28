using Microsoft.EntityFrameworkCore.Migrations;

namespace EZPCBuilder.Data.Migrations
{
    public partial class UpdatedProcessorClassAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BoostSpeed",
                table: "Processor",
                type: "nvarchar(64)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(5,5)");

            migrationBuilder.AlterColumn<string>(
                name: "BaseSpeed",
                table: "Processor",
                type: "nvarchar(64)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(5,5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BoostSpeed",
                table: "Processor",
                type: "Decimal(5,5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseSpeed",
                table: "Processor",
                type: "Decimal(5,5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)");
        }
    }
}
