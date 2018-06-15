using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Morgan
{
    /// <summary>
    /// Base class for all the value converters to get the base functionality such as direct XAML usage.
    /// In order to use the base class, child converters should override the <see cref="Convert(object, Type, object, CultureInfo)"/>
    /// or/and <see cref="ConvertBack(object, Type, object, CultureInfo)"/> methods as needed.
    /// </summary>
    /// <typeparam name="T">Actual value converter class type</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : new()
    {
        #region Markup Extension

        /// <summary>
        /// Provides an instance of the actual value converter to be consumed from XAML
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new T();
        }

        #endregion

        #region Value Converter Methods

        /**
         * Required method(s) should be overridden by actual value converter classes
         */

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture) => null;

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null; 

        #endregion
    }
}
