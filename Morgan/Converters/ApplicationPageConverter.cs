using Morgan.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Morgan
{
    /// <summary>
    /// Convertes an enum variable of type <see cref="ApplicationPage"/> into an actual WPF Page
    /// </summary>
    public class ApplicationPageConverter : BaseValueConverter<ApplicationPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.BaseHomePage:
                    return new BaseHomePage();

                case ApplicationPage.SettingsPage:
                    return new SettingsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
