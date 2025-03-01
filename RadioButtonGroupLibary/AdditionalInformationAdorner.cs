using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Input;
using RadioButtonGroupLibary;

namespace RadioButtonGroupLibrary
{
    public class AdditionalInformationAdorner : Adorner
    {
        private string information;
        private RadioButtonGroup RadioButtonGroup;
        public AdditionalInformationAdorner(UIElement element, string info) : base(element)
        {
            information = info;
            RadioButtonGroup = (RadioButtonGroup)element;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {            
            Brush backgroundBrush = new SolidColorBrush(Colors.DarkGray);
            
            FormattedText formattedText = new FormattedText(information, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Segoe UI"), 12, Brushes.White, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            Size textSize = new Size(formattedText.Width + 10, formattedText.Height + 6);
            Rect TextBoxDisplayPlace = new Rect(Mouse.GetPosition(this.AdornedElement), textSize);

            drawingContext.DrawRectangle(backgroundBrush, null, TextBoxDisplayPlace);
            drawingContext.DrawText(formattedText, TextBoxDisplayPlace.TopLeft + new Vector(5, 3));
        }
    }
}
