using CustomControlsLibrary;
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
            MessageBox.Show($"Selected button: '{e.Button.Content}'. Collection: '{((RadioButtonGroup)sender).Title}'. " +
                $"Index of the selected button {((RadioButtonGroup)sender).SelectedRadiobuttonIndex}");
        }
    }
}
