using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Trucks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 18, 39, 40, 68, DateTimeKind.Utc).AddTicks(9336), new DateTime(2023, 1, 6, 18, 39, 40, 68, DateTimeKind.Utc).AddTicks(9338) });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_UserId",
                table: "Trucks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Users_UserId",
                table: "Trucks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Users_UserId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_UserId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trucks");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 5, 16, 59, 42, 392, DateTimeKind.Utc).AddTicks(5981), new DateTime(2023, 1, 5, 16, 59, 42, 392, DateTimeKind.Utc).AddTicks(5982) });
        }
    }
}
