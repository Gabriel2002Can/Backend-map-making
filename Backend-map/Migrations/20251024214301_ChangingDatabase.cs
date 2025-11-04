using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_map.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "X", "Y" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "X", "Y" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "X", "Y" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "X", "Y" },
                values: new object[] { 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "X", "Y" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "X", "Y" },
                values: new object[] { 0, 1 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "X", "Y" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Cells",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "X", "Y" },
                values: new object[] { 1, 1 });
        }
    }
}
