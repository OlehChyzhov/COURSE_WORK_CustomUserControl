using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HelperLibrary
{
    public partial class StagedProgressBar : UserControl
    {
        public StagedProgressBar()
        {
            InitializeComponent();
        }

        public static DependencyProperty ProgressProperty = DependencyProperty.Register(nameof(Progress), typeof(double),
            typeof(StagedProgressBar), new PropertyMetadata(0.0, ProgressChanged));

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        public static void ProgressChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            StagedProgressBar bar = (StagedProgressBar)sender;
            ImageBrush Completed = (ImageBrush)Application.Current.Resources["Completed"];
            ImageBrush NotCompleted = (ImageBrush)Application.Current.Resources["NotCompleted"];

            if (bar.Progress >= 0 && bar.Progress <= 20)
            {
                bar.Stage1Rect.Fill = Completed;
                bar.Stage2Rect.Fill = NotCompleted;
                bar.Stage3Rect.Fill = NotCompleted;
                bar.Stage4Rect.Fill = NotCompleted;
                bar.Stage5Rect.Fill = NotCompleted;
            }
            else if (bar.Progress > 20 && bar.Progress <= 40)
            {
                bar.Stage1Rect.Fill = Completed;
                bar.Stage2Rect.Fill = Completed;
                bar.Stage3Rect.Fill = NotCompleted;
                bar.Stage4Rect.Fill = NotCompleted;
                bar.Stage5Rect.Fill = NotCompleted;
            }            
            else if (bar.Progress > 40 && bar.Progress <= 60)
            {
                bar.Stage1Rect.Fill = Completed;
                bar.Stage2Rect.Fill = Completed;
                bar.Stage3Rect.Fill = Completed;
                bar.Stage4Rect.Fill = NotCompleted;
                bar.Stage5Rect.Fill = NotCompleted;
            }
            else if (bar.Progress > 60 && bar.Progress <= 80)
            {
                bar.Stage1Rect.Fill = Completed;
                bar.Stage2Rect.Fill = Completed;
                bar.Stage3Rect.Fill = Completed;
                bar.Stage4Rect.Fill = Completed;
                bar.Stage5Rect.Fill = NotCompleted;
            }
            else if (bar.Progress > 80 && bar.Progress <= 100)
            {
                bar.Stage1Rect.Fill = Completed;
                bar.Stage2Rect.Fill = Completed;
                bar.Stage3Rect.Fill = Completed;
                bar.Stage4Rect.Fill = Completed;
                bar.Stage5Rect.Fill = Completed;
            }
        }
    }
}
