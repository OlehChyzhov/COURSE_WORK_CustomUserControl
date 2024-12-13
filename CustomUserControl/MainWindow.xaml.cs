using System.Windows;
using CustomControlsLibrary;

namespace CustomUserControl
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowInfo(object sender, RadioButtonGroupEventArgs e)
        {
            MessageBox.Show($"Selected button '{e.Button.Content}' of group '{((RadioButtonGroup)sender).Title}'");
        }
    }
}