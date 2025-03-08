using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Repositories
{
    public interface IInventoryItemRepository
    {
        Task<InventoryItem> GetInventoryItemAsyncById(int ItemId);
        Task SaveAsync();
        bool HasChanges();
        void Add(InventoryItem item);
        void Remove(InventoryItem item);
    }
}
