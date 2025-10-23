using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend_map.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DimensionX = table.Column<int>(type: "int", nullable: false),
                    DimensionY = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    IsFilled = table.Column<bool>(type: "bit", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cells_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sample Map" });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "DimensionX", "DimensionY", "MapId", "Number" },
                values: new object[] { 1, 10, 10, 1, 1 });

            migrationBuilder.InsertData(
                table: "Cells",
                columns: new[] { "Id", "FloorId", "IsFilled", "X", "Y" },
                values: new object[,]
                {
                    { 1, 1, false, 0, 0 },
                    { 2, 1, true, 0, 1 },
                    { 3, 1, false, 1, 0 },
                    { 4, 1, true, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cells_FloorId",
                table: "Cells",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_MapId",
                table: "Floors",
                column: "MapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
