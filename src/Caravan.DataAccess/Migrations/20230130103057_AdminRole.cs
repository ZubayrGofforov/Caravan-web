using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Administrators",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 30, 10, 30, 56, 793, DateTimeKind.Utc).AddTicks(2035), new DateTime(2023, 1, 30, 10, 30, 56, 793, DateTimeKind.Utc).AddTicks(2037) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Administrators");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 17, 8, 46, 45, 974, DateTimeKind.Utc).AddTicks(4565), new DateTime(2023, 1, 17, 8, 46, 45, 974, DateTimeKind.Utc).AddTicks(4566) });
        }
    }
}
