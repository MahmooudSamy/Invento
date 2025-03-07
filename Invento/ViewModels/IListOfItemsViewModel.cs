using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.ViewModels
{
   public interface IListOfItemsViewModel
    {
        Task LoadAllItems();
    }
}
