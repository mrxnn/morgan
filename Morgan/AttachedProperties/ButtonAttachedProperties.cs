using System.Windows;

namespace Morgan
{
    /// <summary>
    /// Attached Properties for <see cref="Button"/>
    /// </summary>
    public class ButtonAttachedProperties
    {
        #region IsBusy Attached Property
        
        /// <summary>
        /// Property to hold a value indicating if the button is busy (Eg: Button is clicked and the action is not already finished)
        /// </summary>
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(ButtonAttachedProperties));

        public static void SetIsBusy(DependencyObject button, bool value)
        {
            button.SetValue(IsBusyProperty, value);
        }

        public static bool GetIsBusy(DependencyObject button)
        {
            return (bool)(button.GetValue(IsBusyProperty));
        } 

        #endregion
    }
}
