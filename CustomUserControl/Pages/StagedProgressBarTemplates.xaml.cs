using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Pages
{
    public partial class StagedProgressBarTemplates : Page
    {
        public StagedProgressBarTemplates()
        {
            InitializeComponent();
        }

        private void MainSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int Val = (int)Math.Ceiling(e.NewValue);
            string Stage = "NoStage";
            if (Val >= 0 && Val <= 20) Stage = "Stage1";
            else if (Val > 20 && Val <= 40) Stage = "Stage2";
            else if (Val > 40 && Val <= 60) Stage = "Stage3";
            else if (Val > 60 && Val <= 80) Stage = "Stage4";
            else if (Val > 80 && Val <= 100) Stage = "Stage5";

            Helper.SetStage(StagedProgressBar, Stage);
        }
    }
}
