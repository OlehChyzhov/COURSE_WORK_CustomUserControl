using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomControlsLibrary.RunTimeAdorners
{
    public class HoverButtonsAdorner : Adorner
    {
        private RadioButtonGroup Group;
        private bool DidMouseLeaveAdorner = true;
        public HoverButtonsAdorner(UIElement comp): base(comp) 
        {
            Group = comp as RadioButtonGroup;
            Group.MouseEnter += MouseEnterGroup;
        }
        // Не впевнений, чи деструктор потрібен, але оскільки збирач сміття не може позбутись підписаних методів,
        // то вирішив написати.
        ~HoverButtonsAdorner()
        {
            Group.MouseEnter -= MouseEnterGroup;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            DidMouseLeaveAdorner = true;
            InvalidateVisual();
        }
        private void MouseEnterGroup(object sender, MouseEventArgs e)
        {
            DidMouseLeaveAdorner = false;
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (DesignerProperties.GetIsInDesignMode(Group) == true) return;
            if (DidMouseLeaveAdorner) return;

            SolidColorBrush grayBrush = new SolidColorBrush(Colors.LightGray);

            double startX = 3;
            double startY = ActualHeight - 2;
            double width = ActualWidth - 5;
            double height = ActualHeight - ActualHeight / 2;

            Rect renderRectangle = new Rect(0, 0, ActualWidth, ActualHeight);
            Rect panel = new Rect(startX, startY, width, height);
            drawingContext.DrawRectangle(grayBrush, null, panel);

            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(1, 1, ActualWidth, 15));
            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(0, 0, 15, ActualHeight));
            drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(ActualWidth - 6, 1, 15, ActualHeight));
        }
    }
}
