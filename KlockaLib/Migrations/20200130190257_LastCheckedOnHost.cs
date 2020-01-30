using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KlockaLib.Migrations
{
    public partial class LastCheckedOnHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastChecked",
                table: "Hosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastChecked",
                table: "Hosts");
        }
    }
}
