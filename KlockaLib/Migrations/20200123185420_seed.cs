using Microsoft.EntityFrameworkCore.Migrations;

namespace KlockaLib.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Demo Inventory" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Demo Inventory" });
        }
    }
}
