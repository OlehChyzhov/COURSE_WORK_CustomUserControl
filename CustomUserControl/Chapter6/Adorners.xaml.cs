using CustomUserControl.Chapter5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomUserControl.Chapter6
{
    /// <summary>
    /// Interaction logic for Adorners.xaml
    /// </summary>
    public partial class Adorners : Page
    {
        public Adorners()
        {
            InitializeComponent();
        }

        private void Print(object sender, Chapter5.RadioButtonGroupEventArgs e)
        {
            MessageBox.Show($"Вибрано '{e.Button.Content}' у групі '{((RBtnGroupChapter6)sender).Title}'");
        }
    }
}
