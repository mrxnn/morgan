using System;
using System.Globalization;
using System.Windows;

namespace Morgan
{
    /// <summary>
    /// Returns an inverted <see cref="Visibility"/>based on a boolean property
    /// </summary>
    public class BoolToVisibilityInvertConverter : BaseValueConverter<BoolToVisibilityInvertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
