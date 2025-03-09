using Invento.DataAccess.Data.Lookups;
using Invento.DataAccess.Data.Repositories;
using Invento.Events;
using Invento.Model;
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
            CategoriesCollection = new ObservableCollection<CategoryDto>();
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
            try
            {
                await _itemRepository.SaveAsync();
                HasChanges = _itemRepository.HasChanges();
                _eventAggregator.GetEvent<SendIdEvent>().Publish(ItemWrapper.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        public async Task AddEditInventoryItem(int? itemId)
        {
            var item = itemId.HasValue
                ? await _itemRepository.GetAsyncById(itemId.Value)
                : CreateNewItem();
            InitilaizeItem(item);
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

        private Item CreateNewItem()
        {

            var item = new Item();
            _itemRepository.Add(item);
            return item;
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

        public ItemWrapper ItemWrapper
        {
            get { return _itemWrapper; }
            set { _itemWrapper = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ObservableCollection<CategoryDto> CategoriesCollection { get; }
    }
}
