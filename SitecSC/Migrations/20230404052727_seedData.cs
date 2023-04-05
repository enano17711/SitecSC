using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SitecSC.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "PurchaseDate", "PurchaseTotal" },
                values: new object[] { new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m });

            migrationBuilder.InsertData(
                table: "Movements",
                columns: new[] { "MovementId", "Price", "ProductId", "PurchaseId", "Quantity", "SaleId" },
                values: new object[,]
                {
                    { new Guid("3c4fef43-76fe-41ae-a019-3427be36237f"), 34.50m, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"), 100, null },
                    { new Guid("d794045c-d231-4fa5-bb51-134fca92880d"), 65.50m, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"), 200, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movements",
                keyColumn: "MovementId",
                keyValue: new Guid("3c4fef43-76fe-41ae-a019-3427be36237f"));

            migrationBuilder.DeleteData(
                table: "Movements",
                keyColumn: "MovementId",
                keyValue: new Guid("d794045c-d231-4fa5-bb51-134fca92880d"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: new Guid("6aec1a38-1c16-4b84-a031-af00b34c3a5c"));
        }
    }
}
