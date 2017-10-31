using System;
using System.Globalization;

namespace Morgan
{
    /// <summary>
    /// Convertes an enum variable of type <see cref="ApplicationPage"/> into an actual WPF Page
    /// </summary>
    public class ApplicationPageToPageConverter : BaseValueConverter<ApplicationPageToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.HomePage:
                    return new HomePage();

                case ApplicationPage.ViewFilePage:
                    return new ViewFilePage();

                case ApplicationPage.SettingsPage:
                    return new SettingsPage();

                default: return null;
            }
        }
    }
}
