using System.Windows;

namespace CustomUserControl.Chapter3.Components
{
    public class CustomControl : FrameworkElement
    {
        public static readonly DependencyProperty MyCustomProperty = DependencyProperty.Register(nameof(MyCustom), typeof(string), 
            typeof(CustomControl), new PropertyMetadata("Default Title", OnTitleChanged));

        public string MyCustom
        {
            get => (string)GetValue(MyCustomProperty);
            set => SetValue(MyCustomProperty, value);
        }

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomControl control = (CustomControl)d;
            string oldValue = (string)e.OldValue;
            string newValue = (string)e.NewValue;
            MessageBox.Show($"Влстивість 'Title' змінилась з '{oldValue}' на '{newValue}'");
        }
    }
}
