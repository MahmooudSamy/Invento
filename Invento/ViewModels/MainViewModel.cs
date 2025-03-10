using Invento.DataAccess.Data.Lookups;
using Invento.Events;
using Invento.Model;
using Invento.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invento.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Page _pagetonavigate;
        private Func<IListOfItemsViewModel> _LookupListItemsviewModelCreator;
        private Func<IItemViewModel> _ItemViewModelCreator;
        private Func<IInventoryItemViewModel> _InventoryViewModelCreator;
        private IListOfItemsViewModel _listofitemsviewmodel;
        private IItemViewModel _itemviewmodel;
        private IInventoryItemViewModel _inventoryviewmodel;
        private IEventAggregator _eventAggregator;
        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<IListOfItemsViewModel> LookupListItemsviewModelCreator,
            Func<IItemViewModel> ItemViewModelCreator, Func<IInventoryItemViewModel> InventoryViewModelCreator,
            IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            _eventAggregator = eventAggregator;
            _LookupListItemsviewModelCreator = LookupListItemsviewModelCreator;
            _ItemViewModelCreator = ItemViewModelCreator;
            _InventoryViewModelCreator = InventoryViewModelCreator;
            OpenNewItem = new DelegateCommand(OnOpenNewItemExceute);
            _eventAggregator.GetEvent<SendIdEvent>().Subscribe(OnSendDataToInventoryItemExecute);
            _eventAggregator.GetEvent<OpenListPageEvent>().Subscribe(OnOpenPageExecute);
        }

        private async void OnOpenPageExecute(bool IsOpen)
        {
           if(IsOpen)
            {
                await LoadAsync();
            }
        }

        private void OnSendDataToInventoryItemExecute(SendIdEventArgs ItemData)
        {
            InventoryItemViewModel = _InventoryViewModelCreator();
            if (ItemData.ItemID != 0)
            {
                InventoryItemViewModel.AddEditInventoryItem(null,ItemData.ItemID, ItemData.Quantity);
            }


        }

        private void OnOpenNewItemExceute()
        {
            ItemViewModel = _ItemViewModelCreator();
            ItemViewModel.AddEditInventoryItem(null);
            PageToNavigate = new AddEditItem(this);
        }

        public async Task LoadAsync()
        {
            ListOfItemsViewModel = _LookupListItemsviewModelCreator();
            await ListOfItemsViewModel.LoadAllItems();

            PageToNavigate = new ListItemsPage(this);
        }

        public Page PageToNavigate
        {
            get { return _pagetonavigate; }
            set { _pagetonavigate = value; OnPropertyChanged(); }
        }



        public IItemViewModel ItemViewModel
        {
            get { return _itemviewmodel; }
            set { _itemviewmodel = value; OnPropertyChanged(); }
        }


        public IInventoryItemViewModel InventoryItemViewModel
        {
            get { return _inventoryviewmodel; }
            set { _inventoryviewmodel = value; OnPropertyChanged(); }
        }

        public IListOfItemsViewModel ListOfItemsViewModel
        {
            get { return _listofitemsviewmodel; }
            set { _listofitemsviewmodel = value; OnPropertyChanged(); }
        }

        public INavigationViewModel NavigationViewModel { get; set; }

        public ICommand OpenNewItem { get; }


    }
}
