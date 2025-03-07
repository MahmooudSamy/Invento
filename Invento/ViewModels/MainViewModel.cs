using Invento.DataAccess.Data.Lookups;
using Invento.Model;
using Invento.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Invento.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private Page _pagetonavigate;


        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
            
        }

        //public async Task LoadAsync()
        //{
        //    UserAccountViewModel = null;
        //    LogInViewModel = _loginViewModelCreator();
        //    await NavigationViewModel.LoadAsync();
        //}

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
            PageToNavigate = new ListItemsPage(this);
        }

        public Page PageToNavigate
        {
            get { return _pagetonavigate; }
            set { _pagetonavigate = value; OnPropertyChanged(); }
        }

       
        public INavigationViewModel NavigationViewModel { get; set; }
    }
}
