using System;
using System.Globalization;
using System.Windows;

namespace Morgan
{
    /// <summary>
    /// Returns a <see cref="Visibility"/> based on a boolean property
    /// </summary>
    public class BoolToVisibilityConverter : BaseValueConverter<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
