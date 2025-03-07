using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invento.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemListProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create proc GetItems 
As 
BEGIN 
Select Items.ItemId,ItemName,CategoryName,Quantity,LastUpdate
From Items inner join Categories on Items.CategoryId=Categories.CategoryId
inner join InventoryItems on Items.ItemId=InventoryItems.ItemId 
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" DROP PROCEDURE IF EXISTS GetItems");

        }
    }
}
