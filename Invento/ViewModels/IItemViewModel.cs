using Invento.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.ViewModels
{
    public interface IItemViewModel
    {
        Task AddEditInventoryItem(int? itemId,int quantity,EventState eventState);
        bool HasChanges { get; set; }
    }
}
