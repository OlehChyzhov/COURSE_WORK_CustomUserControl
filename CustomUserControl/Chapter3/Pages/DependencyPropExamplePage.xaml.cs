using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter3.Pages
{
    public partial class DependencyPropExamplePage : Page
    {
        public DependencyPropExamplePage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ctrl.MyCustom = TextB.Text.ToString();
        }
    }
}
