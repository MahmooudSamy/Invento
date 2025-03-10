using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.ViewModels
{
    public interface IInventoryItemViewModel
    {
        Task AddEditInventoryItem(int? itemIdForNew,int itemIdSending, int quantity);
        bool HasChanges { get; set; }
    }
}
