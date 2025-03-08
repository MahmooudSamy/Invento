using Invento.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private InventoryDbContext _context;

        public InventoryItemRepository(InventoryDbContext context)
        {
            _context = context;

        }
        public void Add(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
        }

        public async Task<InventoryItem> GetInventoryItemAsyncById(int ItemId)
        {
            var item = await _context.InventoryItems.SingleOrDefaultAsync(u => u.ItemId == ItemId);
            return item;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(InventoryItem item)
        {
            _context.InventoryItems.Remove(item);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
