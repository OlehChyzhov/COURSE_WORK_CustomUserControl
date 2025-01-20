using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter5
{
    public partial class RadioButtonGroupPageChapter5 : Page
    {
        public RadioButtonGroupPageChapter5()
        {
            InitializeComponent();
        }

        private void Print(object sender, RadioButtonGroupEventArgs e)
        {
            MessageBox.Show($"Вибрано '{e.Button.Content}' у групі '{((RBtnGroupChapter5)sender).Title}'");
        }
    }
}
