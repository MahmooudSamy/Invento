using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invento.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewInialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 2 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 3 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 4 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 5 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 6 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 7 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 885, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 2 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 3 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 4 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 5 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 6 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "InventoryId", "ItemId" },
                keyValues: new object[] { 1, 7 },
                column: "LastUpdate",
                value: new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6502));
        }
    }
}
