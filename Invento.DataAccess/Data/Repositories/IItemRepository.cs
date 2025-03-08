using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsyncById(int ItemId);
       
       
        Task SaveAsync();
        bool HasChanges();
        void Add(Item item);
        void Remove(Item item);
    }
}
