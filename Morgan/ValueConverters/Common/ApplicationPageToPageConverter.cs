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
                case ApplicationPage.BaseFormPage:
                    return new BaseFormPage();

                case ApplicationPage.FileStructurePage:
                    return new FileStructurePage();

                default: return null;
            }
        }
    }
}
