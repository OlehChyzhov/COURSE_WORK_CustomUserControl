using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CustomControlsLibrary.Converters
{
    class ColumnToHorizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int columns) return columns == 1 ? HorizontalAlignment.Center : HorizontalAlignment.Stretch;
            return HorizontalAlignment.Stretch;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
