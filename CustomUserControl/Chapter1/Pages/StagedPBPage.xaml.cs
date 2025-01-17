using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter1.Pages
{
    public partial class StagedPBPage : Page
    {
        public StagedPBPage()
        {
            InitializeComponent();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            StagedPB.Progress = e.NewValue;
        }
    }
}
