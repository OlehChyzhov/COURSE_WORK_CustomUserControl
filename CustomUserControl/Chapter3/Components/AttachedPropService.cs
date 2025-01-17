using System.Windows;
using System.Windows.Controls;

namespace CustomUserControl.Chapter3.Components
{
    public static class AttachedPropService
    {
        public static readonly DependencyProperty ShowTooltipProperty =
            DependencyProperty.RegisterAttached("ShowTooltip", typeof(bool), typeof(AttachedPropService), new PropertyMetadata(false, OnShowTooltipChanged));

        public static bool GetShowTooltip(UIElement element)
        {
            return (bool)element.GetValue(ShowTooltipProperty);
        }
        public static void SetShowTooltip(UIElement element, bool value)
        {
            element.SetValue(ShowTooltipProperty, value);
        }

        private static void OnShowTooltipChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                bool shouldShow = (bool)e.NewValue;
                MessageBox.Show($"ToolTip setting changed for element {element.ToString()}");

                if (shouldShow)
                {
                    ToolTip tooltip = new ToolTip() { Content = "Attached Property Example" };
                    ToolTipService.SetToolTip(element, tooltip);
                }
                else
                {
                    ToolTipService.SetToolTip(element, null);
                }
            }
        }
    }
}
