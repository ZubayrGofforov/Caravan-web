using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class ConnectionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 19, 35, 22, 807, DateTimeKind.Utc).AddTicks(8328), new DateTime(2023, 1, 7, 19, 35, 22, 807, DateTimeKind.Utc).AddTicks(8330) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 18, 39, 40, 68, DateTimeKind.Utc).AddTicks(9336), new DateTime(2023, 1, 6, 18, 39, 40, 68, DateTimeKind.Utc).AddTicks(9338) });
        }
    }
}
