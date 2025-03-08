using Invento.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private InventoryDbContext _context;

        public ItemRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public void Add(Item item)
        {
            _context.Items.Add(item);
        }

        public async Task<Item> GetAsyncById(int ItemId)
        {
            var item= await _context.Items.SingleOrDefaultAsync(u => u.ItemId == ItemId);
            return item;
        }

       

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
        public void Remove(Item item)
        {
            _context.Items.Remove(item);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
