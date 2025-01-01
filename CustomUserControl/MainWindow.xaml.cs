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

        private void CheckBoxPrint(object sender, CheckboxGroupEventArgs e)
        {
            MessageBox.Show($"Selected box: '{e.CheckBox.Content}'. Collection: '{((CheckBoxGroup)sender).Title}'. " +
                $"Index of the selected box {((CheckBoxGroup)sender).SelectedCheckboxIndex}");
        }

        private void UncheckBoxPrint(object sender, CheckboxGroupEventArgs e)
        {
            MessageBox.Show($"Unselected box: '{e.CheckBox.Content}'. Collection: '{((CheckBoxGroup)sender).Title}'. " +
                $"Index of the unselected box {((CheckBoxGroup)sender).SelectedCheckboxIndex}");
        }
    }
}
