using Invento.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Lookups
{
    public class LookupDataService : IItemsLookupDataService
    {
        private Func<InventoryDbContext> _contextcreator;
        public LookupDataService(Func<InventoryDbContext> ContextCreator)
        {
            _contextcreator = ContextCreator;
        }

        public async Task<IEnumerable<Item>> GetAllAysc()
        {
            using (var context = _contextcreator())
            {
                return await context.Items.AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<InventoryItemDto>> GetInventoryItemsbyNameAysc(string ItemName)
        {
            using (var context = _contextcreator())
            {
                return await context.Database.SqlQueryRaw<InventoryItemDto>(
                "EXEC GetItemsbyName @SearchTerm = {0}",
                ItemName
                ).ToListAsync();

            }
              
        }

        public async Task<IEnumerable<InventoryItemDto>> GetInventoryItemsListAysc()
        {
            using (var context = _contextcreator()) 
            {
                var item= await context.Database.SqlQueryRaw<InventoryItemDto>("EXEC GetItems")
                    .ToListAsync();
                return item;
            }
        }
    }
}
