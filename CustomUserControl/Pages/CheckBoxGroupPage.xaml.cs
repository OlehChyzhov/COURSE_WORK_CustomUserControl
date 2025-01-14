using CustomControlsLibrary;
using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Pages
{
    public partial class CheckBoxGroupPage : Page
    {
        public CheckBoxGroupPage()
        {
            InitializeComponent();
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
