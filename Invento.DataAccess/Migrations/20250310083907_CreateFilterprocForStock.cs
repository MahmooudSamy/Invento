using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invento.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateFilterprocForStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create proc GetItemLowStock 
As 
BEGIN
 Select Items.ItemId,ItemName,CategoryName,Quantity,LastUpdate
From Items inner join Categories on Items.CategoryId = Categories.CategoryId
inner join InventoryItems on Items.ItemId = InventoryItems.ItemId
where Quantity=0
END");
            migrationBuilder.Sql(@"create proc GetItemInStock 
As 
BEGIN
 Select Items.ItemId,ItemName,CategoryName,Quantity,LastUpdate
From Items inner join Categories on Items.CategoryId = Categories.CategoryId
inner join InventoryItems on Items.ItemId = InventoryItems.ItemId
where Quantity>0
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" DROP PROCEDURE IF EXISTS GetItemLowStock");
            migrationBuilder.Sql(@" DROP PROCEDURE IF EXISTS GetItemInStock");
        }
    }
}
