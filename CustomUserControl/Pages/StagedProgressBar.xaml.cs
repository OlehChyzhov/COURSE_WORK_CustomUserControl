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

namespace CustomUserControl.Pages
{
    /// <summary>
    /// Interaction logic for StagedProgressBar.xaml
    /// </summary>
    public partial class StagedProgressBar : Page
    {
        public StagedProgressBar()
        {
            InitializeComponent();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            StagedPBar.Progress = e.NewValue;
        }
    }
}
