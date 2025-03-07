using Invento.Model;
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
        public Task<IEnumerable<InventoryItemDto>> GetInventoryItemsListAysc()
        {
            throw new NotImplementedException();
        }
    }
}
