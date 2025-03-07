using Invento.Model;

namespace Invento.DataAccess.Data.Lookups
{
    public interface IItemsLookupDataService
    {
        Task<IEnumerable<InventoryItemDto>> GetInventoryItemsListAysc();

        Task<IEnumerable<Item>> GetAllAysc();
    }
}
