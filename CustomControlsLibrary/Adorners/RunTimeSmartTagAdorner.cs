using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;

namespace CustomControlsLibrary.Adorners
{
    public class RunTimeSmartTagAdorner : Adorner
    {
        public RunTimeSmartTagAdorner(UIElement uiElement) : base(uiElement)  
        {
            PreviewMouseDown += SmartTagClicked;
        }

        private void SmartTagClicked(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Runtime Adorner Responce", "Test", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            //if (DesignerProperties.GetIsInDesignMode(AdornedElement) == false) return;
            double buttonWidth = 20;
            double buttonHeight = 15;

            double x = this.ActualWidth - buttonWidth - 5;
            double y = 5;

            Rect buttonRect = new Rect(x, y, buttonWidth, buttonHeight);
            drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.Transparent, 0), new Rect(x, y, buttonWidth, buttonHeight));

            FormattedText formattedText = new FormattedText("...", System.Globalization.CultureInfo.InvariantCulture, FlowDirection.LeftToRight, 
                new Typeface("Segoe UI"), 12, Brushes.Black);
            
            drawingContext.DrawText(formattedText, new Point(x + (buttonWidth - formattedText.Width) / 2, y + (buttonHeight - formattedText.Height) / 2));
        }
    }
}
