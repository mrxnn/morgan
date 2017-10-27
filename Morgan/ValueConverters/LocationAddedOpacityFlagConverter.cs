using System;
using System.Globalization;

namespace Morgan
{
    /// <summary>
    /// Converter used in BaseFormPage's location added indicator button;
    /// 
    /// This converter is used for changing the opacity of icons depending on weather any location (to search for
    /// music files) is added to the locations list or not. If at least one location is added to the location list,
    /// the converter returns 1 for opacity, and returns .2f otherwise...
    /// </summary>
    public class LocationAddedOpacityFlagConverter : BaseValueConverter<LocationAddedOpacityFlagConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1f : .2f;
        }
    }
}
