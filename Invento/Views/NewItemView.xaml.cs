using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Invento.Views
{
    /// <summary>
    /// Interaction logic for NewItemView.xaml
    /// </summary>
    public partial class NewItemView : UserControl
    {
        public NewItemView()
        {
            InitializeComponent();
        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(ComboCategory.SelectedValue.ToString());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
