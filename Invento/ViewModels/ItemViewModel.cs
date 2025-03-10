using Invento.DataAccess.Data.Lookups;
using Invento.DataAccess.Data.Repositories;
using Invento.Events;
using Invento.Model;
using Invento.Validation;
using Invento.Wrapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Invento.ViewModels
{
    public class ItemViewModel : ViewModelBase, IItemViewModel
    {
        private IItemRepository _itemRepository;
        private IEventAggregator _eventAggregator;
        private ICategoriesLookup _categoriesLookup;
        private ItemWrapper _itemWrapper;
        public ItemViewModel(IItemRepository itemRepository, ICategoriesLookup categoriesLookup
            , IEventAggregator eventAggregator)
        {
            _itemRepository = itemRepository;
            _eventAggregator = eventAggregator;
            _categoriesLookup = categoriesLookup;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            CloseCommand = new DelegateCommand(OnCloseDetailsViewExecute);
            CategoriesCollection = new ObservableCollection<CategoryDto>();
        }

        private void OnCloseDetailsViewExecute()
        {
            _eventAggregator.GetEvent<CloseDetailsViewEvent>().Publish(true);
        }

        private async Task LoadCategoryAsync()
        {
            CategoriesCollection.Clear();
            var lookup = await _categoriesLookup.GetCategoryList();
            foreach (var item in lookup)
            {

                CategoriesCollection.Add(item);
            }
        }
        private bool OnSaveCanExecute()
        {
            return ItemWrapper != null && !ItemWrapper.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {
            //try
            //{

            await _itemRepository.SaveAsync();
            HasChanges = _itemRepository.HasChanges();
            if (EventState == EventState.AddNew)
            {
                _eventAggregator.GetEvent<SendIdEvent>().Publish(new SendIdEventArgs
                {
                    ItemID = ItemWrapper.Id,
                    Quantity = Quantity,
                    State=EventState.AddNew
                });
            }
            else if (EventState == EventState.Edit)
            {
                //event edite
                _eventAggregator.GetEvent<SendIdEvent>().Publish(new SendIdEventArgs
                {
                    ItemID = ItemWrapper.Id,
                    Quantity = Quantity,
                    State = EventState.Edit
                });
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        public async Task AddEditInventoryItem(int? itemId, int quantity, EventState eventState)
        {
            Quantity = quantity;
            EventState = eventState;
            var item = itemId.HasValue
                ? await _itemRepository.GetAsyncById(itemId.Value)
                : CreateNewItem();
            InitilaizeItem(item);
            await LoadCategoryAsync();
            if (ItemWrapper.Id == 0)
            {
                ItemWrapper.ItemName = "";

            }

        }

        private void InitilaizeItem(Item item)
        {
            ItemWrapper = new ItemWrapper(item);
            ItemWrapper.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _itemRepository.HasChanges();
                }
                if (e.PropertyName == nameof(ItemWrapper.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
        private void Validate()
        {
            var validator = new QuantityValidator();
            var results = validator.Validate(this);
           
        }
        private Item CreateNewItem()
        {

            var item = new Item();
            _itemRepository.Add(item);
            return item;
        }

        public void ViewItemDetails(int itemId, string itemName, string CategoryName, int quantity, DateTime lastUpdate)
        {
            ItemId = itemId;
           ItemName=itemName;
            CategorName = CategoryName;
            Quantity = quantity;
            LastUpdate = lastUpdate;
        }

        private bool _haschanges;

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
            set
            {
                _quantity = value; 
                OnPropertyChanged();
                Validate();
            }
        }
        private DateTime _lastupdate;

        public DateTime LastUpdate
        {
            get { return _lastupdate; }
            set { _lastupdate = value; OnPropertyChanged(); }
        }

        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; OnPropertyChanged(); }
        }

        private EventState _eventstate;

        public EventState EventState
        {
            get { return _eventstate; }
            set { _eventstate = value; OnPropertyChanged(); }
        }

        public ItemWrapper ItemWrapper
        {
            get { return _itemWrapper; }
            set { _itemWrapper = value; OnPropertyChanged(); }
        }
        private string _categorname;

        public string CategorName
        {
            get { return _categorname; }
            set { _categorname = value; OnPropertyChanged(); }
        }

        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; OnPropertyChanged(); }
        }
        public ICommand SaveCommand { get; }
        public ICommand CloseCommand { get; }
        public ObservableCollection<CategoryDto> CategoriesCollection { get; }
    }
}
