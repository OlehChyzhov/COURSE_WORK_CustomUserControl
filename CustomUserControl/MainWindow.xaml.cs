using CustomControlsLibrary;
using System;
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

        private void Print(object sender, RadioButtonGroupEventArgs e)
        {
            MessageBox.Show($"Selected the button '{e.Button.Content}' in the collection '{((RadioButtonGroup)sender).Title}'. " +
                $"Index of the selected button {((RadioButtonGroup)sender).SelectedRadiobuttonIndex}");
        }
    }
}
