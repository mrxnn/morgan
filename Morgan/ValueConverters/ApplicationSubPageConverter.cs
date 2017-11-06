using System;
using System.Diagnostics;
using System.Globalization;

namespace Morgan
{
    /// <summary>
    /// Converts a <see cref="ApplicationSubHomePage"/> into an actual WPF Page
    /// </summary>
    public class ApplicationSubHomePageConverter : BaseValueConverter<ApplicationSubHomePageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationSubHomePage)value)
            {
                case ApplicationSubHomePage.HomePage:
                    return new HomePage();

                case ApplicationSubHomePage.ViewFilePage:
                    return new ViewFilePage();

                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
