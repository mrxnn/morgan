using System.Windows;
using System.Windows.Controls;

namespace Morgan
{
    /// <summary>
    /// Attached properties that can be applied to a <see cref="TextBox"/>
    /// </summary>
    public class TextBoxAttachedProperties
    {
        /// <summary>
        /// An attached property that attachs an event handler to any control to set the keyboard focus when the control is loaded
        /// </summary>
        public static readonly DependencyProperty FocusControlOnLoadProperty=
            DependencyProperty.RegisterAttached("FocusControlOnLoad", typeof(bool), typeof(TextBoxAttachedProperties), 
                new PropertyMetadata(false, OnFocusControlPropertyChanged));

        /// <summary>
        /// Fired when the value of <see cref="FocusControlOnLoadProperty"/> is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnFocusControlPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Make sure the control is valid and user wants to attach the event
            if (!(d is Control control) || !(bool)e.NewValue)
                return;

            // Attach an event handler to focus the control when its loaded
            control.Loaded += (ss, ee) => control.Focus();
        }

        /// <summary>
        /// Getter of the <see cref="FocusControlOnLoadProperty"/>
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool GetFocusControlOnLoad(DependencyObject d)
        {
            return (bool)d.GetValue(FocusControlOnLoadProperty);
        }

        /// <summary>
        /// Setter for the <see cref="FocusControlOnLoadProperty"/>
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetFocusControlOnLoad(DependencyObject d, bool value)
        {
            d.SetValue(FocusControlOnLoadProperty, value);
        }
    }
}
