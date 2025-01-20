using CustomUserControl.Chapter6;
using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter7
{
    public partial class DesignTimeAdornerPage : Page
    {
        public DesignTimeAdornerPage()
        {
            InitializeComponent();
        }
        private void Print(object sender, Chapter5.RadioButtonGroupEventArgs e)
        {
            MessageBox.Show($"Вибрано '{e.Button.Content}' у групі '{((RBtnGroupChapter6)sender).Title}'");
        }
    }
}
