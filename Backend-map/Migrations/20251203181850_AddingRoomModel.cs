using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_map.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoomModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Cells",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Cells_RoomId",
                table: "Cells",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorId",
                table: "Rooms",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Rooms_RoomId",
                table: "Cells",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Rooms_RoomId",
                table: "Cells");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Cells_RoomId",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Cells");
        }
    }
}
