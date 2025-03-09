using Invento.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invento.Pages
{
    /// <summary>
    /// Interaction logic for AddEditItem.xaml
    /// </summary>
    public partial class AddEditItem : Page
    {
        private MainViewModel _viewModel;

        public AddEditItem(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            DataContext = _viewModel;
        }
    }
}
