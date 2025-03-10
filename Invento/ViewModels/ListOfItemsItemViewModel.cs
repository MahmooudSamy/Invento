using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Invento.Events;
using Microsoft.IdentityModel.Tokens;
using Prism;

namespace Invento.ViewModels
{
    public class ListOfItemsItemViewModel:ViewModelBase 
    {
        private string? _itemName;
        private string? _categoryName;
        private int _quantity;
        private DateTime _lastUpdate;
        private IEventAggregator _eventAggregator;
        public ListOfItemsItemViewModel(int itemId,string itemName,string cantegoryName,
            int quantity,DateTime lastUpdate, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            ItemId = itemId;
            ItemName = itemName;
            CategoryName = cantegoryName;
            Quantity = quantity;
            LastUpdate = lastUpdate;
            EditCommand=new DelegateCommand(OnEditeExecute);
            ViewCommand = new DelegateCommand(OnViewCommand);
        }

        private void OnViewCommand()
        {
            _eventAggregator.GetEvent<SendItemDataForViewDetailsEvent>().Publish(new SendItemDataForViewDetailsEventArgs
            {
                ItemId=ItemId,
                CategoryName=CategoryName,
                ItemName=ItemName,
                Quantity=Quantity,
                LastUpdate=LastUpdate
            });
        }

        private void OnEditeExecute()
        {
            _eventAggregator.GetEvent<SendDataForEditeEvent>().Publish(new SendDataForEditeEventArgs
            {
                ItemID = ItemId,
                Quantity = Quantity,
                State = EventState.Edit
            });
        }

        public int ItemId { get; set; }

        public string ItemName
        {
			get { return _itemName; }
			set { _itemName = value; OnPropertyChanged(); }
		}

       
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; OnPropertyChanged(); }
        }
       

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

       

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; OnPropertyChanged(); }
        }
        public ICommand EditCommand { get; }
        public ICommand ViewCommand { get; }

    }
}
