using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invento.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => new { x.ItemId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_InventoryItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "InventoryName" },
                values: new object[] { 1, "Store A" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "ItemName" },
                values: new object[,]
                {
                    { 1, 1, "ASUS Vivobook" },
                    { 2, 1, "Huawei MatePad" },
                    { 3, 2, "Fit Polo Shirt" },
                    { 4, 2, "The North Face Jacket" },
                    { 5, 3, "The Art of Computer Programming" },
                    { 6, 3, "Programming C# 12" },
                    { 7, 1, "Samsung Galaxy S25 Ultra Dual SIM" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "InventoryId", "ItemId", "LastUpdate", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 5, 16, 16, 36, 885, DateTimeKind.Local).AddTicks(3162), 10 },
                    { 1, 2, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6408), 20 },
                    { 1, 3, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6481), 10 },
                    { 1, 4, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6488), 50 },
                    { 1, 5, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6493), 20 },
                    { 1, 6, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6497), 30 },
                    { 1, 7, new DateTime(2025, 3, 5, 16, 16, 36, 956, DateTimeKind.Local).AddTicks(6502), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_InventoryId",
                table: "InventoryItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
