using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class LacationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Trucks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 16, 16, 3, 42, 665, DateTimeKind.Utc).AddTicks(3721), new DateTime(2023, 1, 16, 16, 3, 42, 665, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_DeliveryLocationId",
                table: "Orders",
                column: "DeliveryLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryLocationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 19, 35, 22, 807, DateTimeKind.Utc).AddTicks(8328), new DateTime(2023, 1, 7, 19, 35, 22, 807, DateTimeKind.Utc).AddTicks(8330) });
        }
    }
}
