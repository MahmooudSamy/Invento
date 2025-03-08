using Invento.DataAccess.Data.Lookups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Invento.ViewModels
{
    public class ListOfItemsViewModel : ViewModelBase, IListOfItemsViewModel
    {
        private IItemsLookupDataService _lookupDataService;
        private IEventAggregator _eventAggregator;

        public ListOfItemsViewModel(IItemsLookupDataService lookupDataService,IEventAggregator eventAggregator)
        {
            _lookupDataService = lookupDataService;
            _eventAggregator = eventAggregator;
            ItemesCollection = new ObservableCollection<ListOfItemsItemViewModel>();
        }
        public async Task LoadAllItems()
        {
            try
            {
                var items = await _lookupDataService.GetInventoryItemsListAysc();
                ItemesCollection.Clear();
                foreach (var item in items)
                {
                    ItemesCollection.Add(new ListOfItemsItemViewModel(item.ItemId, item.ItemName
                        , item.CategoryName, item.Quantity, item.LastUpdate, _eventAggregator));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string _searchkeyword;

        public string SearchKeyWord
        {
            get { return _searchkeyword; }
            set
            {
                _searchkeyword = value;
                OnPropertyChanged();
                if (_searchkeyword == value)
                {
                    SearchFunction(_searchkeyword);
                }
            }
        }

        private async void SearchFunction(string searchkeyword)
        {

        }

        public ObservableCollection<ListOfItemsItemViewModel> ItemesCollection { get; }
    }
}
