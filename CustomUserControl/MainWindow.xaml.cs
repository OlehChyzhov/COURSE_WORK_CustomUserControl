using System.Windows;
using CustomUserControl.Chapter1.Pages;
using CustomUserControl.Chapter3.Pages;
using CustomUserControl.Chapter4;
using CustomUserControl.Chapter5;
using CustomUserControl.Final;

namespace CustomUserControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StagedPB(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StagedPBPage());
        }
        private void StagedPBTemplate(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StagedPBTemplatePage());
        }
        private void RadioButtonGroup(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RadioButtonGroupPage());
        }
        private void CheckBoxGroup(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CheckBoxGroupPage());
        }
        private void DependencyPropPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DependencyPropExamplePage());
        }
        private void AttachedPropPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AttachedPropExamplePage());
        }
        private void Chapter4Design(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RadioButtonGroupPageChapter4());
        }

        private void Chapter5Functionality(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RadioButtonGroupPageChapter5());
        }
    }
}
