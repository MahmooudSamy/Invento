using Invento.DataAccess.Data.Lookups;
using Invento.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Invento.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IItemsLookupDataService _itemDataService;

        public NavigationViewModel(IItemsLookupDataService itemDataService)
        {
            _itemDataService = itemDataService;
            ItemsCollection = new ObservableCollection<Item>();
        }
        public async Task LoadAsync()
        {
            try
            {
                var item = await _itemDataService.GetAllAysc();
                ItemsCollection.Clear();
                foreach (var items in item)
                {
                    ItemsCollection.Add(items);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ObservableCollection<Item> ItemsCollection { get; set; }

    }
}
