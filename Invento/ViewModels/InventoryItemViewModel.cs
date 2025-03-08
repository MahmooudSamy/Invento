using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.ViewModels
{
    public class InventoryItemViewModel : ViewModelBase, IInventoryItemViewModel
    {
        public bool HasChanges { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task AddEditInventoryItem(int? itemId)
        {
            throw new NotImplementedException();
        }
    }
}
