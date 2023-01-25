using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caravan.DataAccess.Migrations
{
    public partial class PriceCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Orders",
                type: "double precision",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 17, 8, 46, 45, 974, DateTimeKind.Utc).AddTicks(4565), new DateTime(2023, 1, 17, 8, 46, 45, 974, DateTimeKind.Utc).AddTicks(4566) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 16, 16, 3, 42, 665, DateTimeKind.Utc).AddTicks(3721), new DateTime(2023, 1, 16, 16, 3, 42, 665, DateTimeKind.Utc).AddTicks(3722) });
        }
    }
}
