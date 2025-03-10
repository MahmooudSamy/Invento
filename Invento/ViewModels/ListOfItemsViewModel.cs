using Invento.DataAccess.Data.Lookups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

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
            CheckedCommand = new DelegateCommand(OnCheckedExecute);
            UncheckedCommand= new DelegateCommand(OnUncheckedExecute);
        }

        private async void OnUncheckedExecute()
        {
            try
            {
                var items = await _lookupDataService.GetInventoryItemsLowStockListAysc();
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

        private async void OnCheckedExecute()
        {
            try
            {
                var items = await _lookupDataService.GetInventoryItemsInStockListAysc();
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
        private bool _isChecked=true;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged();

                if (value)
                {
                    OnCheckedExecute();
                }
                else
                {
                    OnUncheckedExecute();
                }

            }
        }
        private async void SearchFunction(string searchkeyword)
        {
            try
            {
                var items = await _lookupDataService.GetInventoryItemsbyNameAysc (searchkeyword);
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
        
        public ICommand CheckedCommand { get; }
        public ICommand UncheckedCommand { get; }
        public ObservableCollection<ListOfItemsItemViewModel> ItemesCollection { get; }
    }
}
