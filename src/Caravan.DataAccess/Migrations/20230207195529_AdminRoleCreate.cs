using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class AdminRoleCreate : Migration
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
                values: new object[] { new DateTime(2023, 2, 7, 19, 55, 28, 744, DateTimeKind.Utc).AddTicks(7306), new DateTime(2023, 2, 7, 19, 55, 28, 744, DateTimeKind.Utc).AddTicks(7310) });
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
                values: new object[] { new DateTime(2023, 2, 4, 17, 7, 31, 500, DateTimeKind.Utc).AddTicks(6159), new DateTime(2023, 2, 4, 17, 7, 31, 500, DateTimeKind.Utc).AddTicks(6160) });
        }
    }
}
