using System.Windows;

namespace CustomUserControl.Chapter1.Components
{
    public static class Helper
    {
        public static readonly DependencyProperty StageProperty = DependencyProperty.RegisterAttached("Stage", typeof(string),
        typeof(Helper), new PropertyMetadata("Stage1"));

        public static void SetStage(DependencyObject element, string value)
        {
            element.SetValue(StageProperty, value);
        }

        public static string GetStage(DependencyObject element)
        {
            return (string)element.GetValue(StageProperty);
        }
    }
}
