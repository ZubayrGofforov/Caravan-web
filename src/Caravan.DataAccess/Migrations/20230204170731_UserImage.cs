using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class UserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Administrators");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 2, 4, 17, 7, 31, 500, DateTimeKind.Utc).AddTicks(6159), new DateTime(2023, 2, 4, 17, 7, 31, 500, DateTimeKind.Utc).AddTicks(6160) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Users");

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
    }
}
