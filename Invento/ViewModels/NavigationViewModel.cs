using Invento.DataAccess.Data.Lookups;
using Invento.Events;
using Invento.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Invento.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IItemsLookupDataService _itemDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IItemsLookupDataService itemDataService,IEventAggregator eventAggregator)
        {
            _itemDataService = itemDataService;
            ItemsCollection = new ObservableCollection<Item>();
            ItemCommand = new DelegateCommand(OnOpenPageExecute);
            _eventAggregator = eventAggregator;
        }

        private void OnOpenPageExecute()
        {
            _eventAggregator.GetEvent<OpenListPageEvent>().Publish(true);  
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
        public ICommand ItemCommand { get; }

       

        public ObservableCollection<Item> ItemsCollection { get; set; }

    }
}
