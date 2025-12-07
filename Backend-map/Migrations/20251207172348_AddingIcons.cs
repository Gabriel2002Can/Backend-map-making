using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_map.Migrations
{
    /// <inheritdoc />
    public partial class AddingIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Icon",
                table: "Cells",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Cells");
        }
    }
}
