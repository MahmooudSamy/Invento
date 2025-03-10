using Invento.DataAccess.Data.Repositories;
using Invento.Events;
using Invento.Model;
using Invento.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Invento.ViewModels
{
    public class InventoryItemViewModel : ViewModelBase, IInventoryItemViewModel
    {
        private IInventoryItemRepository _inventoryItemRepository;
        private IEventAggregator _eventAggregator;
        private InventoryItemWrapper _inventoryitemwrapper;
        private bool _haschanges;
        public InventoryItemViewModel(IInventoryItemRepository inventoryItemRepository,IEventAggregator eventAggregator)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return InventoryItemWrapper != null && !InventoryItemWrapper.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {
            try
            {
                InventoryItemWrapper.ItemId = ItemId;
                InventoryItemWrapper.InventoryId = 1;
                InventoryItemWrapper.Quantity = Quantity;
                InventoryItemWrapper.LastUpdate = DateTime.Now;

                await _inventoryItemRepository.SaveAsync();
                HasChanges = _inventoryItemRepository.HasChanges();

                _eventAggregator.GetEvent<OpenListPageEvent>().Publish(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        public async Task AddEditInventoryItem(int? itemId,int itemIdSending, int quantity)
        {
            Quantity = quantity;
            ItemId = itemIdSending;
            var item = itemId.HasValue
               ? await _inventoryItemRepository.GetInventoryItemAsyncById(itemId.Value)
               : CreateNewItem();
           
            InitilaizeItem(item);
            OnSaveExecute();
        }

        private void InitilaizeItem(InventoryItem item)
        {
            InventoryItemWrapper = new InventoryItemWrapper(item);

           


            InventoryItemWrapper.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _inventoryItemRepository.HasChanges();
                }
                if (e.PropertyName == nameof(InventoryItemWrapper.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private InventoryItem CreateNewItem()
        {
            var inventoryitem = new InventoryItem();
            _inventoryItemRepository.Add(inventoryitem);
            return inventoryitem;
        }

        public InventoryItemWrapper InventoryItemWrapper
        {
            get { return _inventoryitemwrapper; }
            set { _inventoryitemwrapper = value; OnPropertyChanged(); }
        }
        

        public bool HasChanges
        {
            get { return _haschanges; }
            set
            {
                if (_haschanges != value)
                {
                    _haschanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

            }
        }
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; OnPropertyChanged(); }
        }
        public ICommand  SaveCommand { get; }
    }
}
