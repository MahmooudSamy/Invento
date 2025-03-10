using Invento.Model;

namespace Invento.DataAccess.Data.Lookups
{
    public interface IItemsLookupDataService
    {
        Task<IEnumerable<InventoryItemDto>> GetInventoryItemsListAysc();
        Task<IEnumerable<InventoryItemDto>> GetInventoryItemsLowStockListAysc();
        Task<IEnumerable<InventoryItemDto>> GetInventoryItemsInStockListAysc();
        Task<IEnumerable<InventoryItemDto>> GetInventoryItemsbyNameAysc(string ItemName);
        Task<IEnumerable<Item>> GetAllAysc();
    }
}
