using CustomControlsLibrary;
using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Pages
{
    public partial class RadioButtonGroupPage : Page
    {
        public RadioButtonGroupPage()
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
