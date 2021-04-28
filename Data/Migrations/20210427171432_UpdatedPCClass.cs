using Microsoft.EntityFrameworkCore.Migrations;

namespace EZPCBuilder.Data.Migrations
{
    public partial class UpdatedPCClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pc_name = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    pc_desc = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ProcessorID = table.Column<int>(nullable: false),
                    GraphicsID = table.Column<int>(nullable: false),
                    CaseID = table.Column<int>(nullable: false),
                    MemoryID = table.Column<int>(nullable: false),
                    StorageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PC_Case_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Case",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PC_Graphics_GraphicsID",
                        column: x => x.GraphicsID,
                        principalTable: "Graphics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PC_Memory_MemoryID",
                        column: x => x.MemoryID,
                        principalTable: "Memory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PC_Processor_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "Processor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PC_Storage_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PC_CaseID",
                table: "PC",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PC_GraphicsID",
                table: "PC",
                column: "GraphicsID");

            migrationBuilder.CreateIndex(
                name: "IX_PC_MemoryID",
                table: "PC",
                column: "MemoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PC_ProcessorID",
                table: "PC",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_PC_StorageID",
                table: "PC",
                column: "StorageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PC");
        }
    }
}
