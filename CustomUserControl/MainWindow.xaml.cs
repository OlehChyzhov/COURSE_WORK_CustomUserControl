using CustomControlsLibrary;
using CustomUserControl.Pages;
using System.Windows;

namespace CustomUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButtonGroup(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RadioButtonGroupPage());
        }
        private void CheckBoxGroup(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CheckBoxGroupPage());
        }
        private void StagedProgressBar(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StagedProgressBar());
        }
        private void StagedProgressBarTemplates(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StagedProgressBarTemplates());
        }
    }
}
