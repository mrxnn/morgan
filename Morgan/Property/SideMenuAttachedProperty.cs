using System.Windows;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Threading.Tasks;

namespace Morgan
{
    /// <summary>
    /// Attached Properties used for <see cref="SideMenuControl"/>
    /// </summary>
    public class SideMenuAttachedProperty
    {
        #region AnimateInFromLeftProperty

        /// <summary>
        /// The property that is used to animate the side menu when the application is first loaded
        /// </summary>
        public static readonly DependencyProperty AnimateInFromLeftProperty =
            DependencyProperty.RegisterAttached(
                "AnimateInFromLeft", typeof(bool), typeof(SideMenuAttachedProperty),
                new PropertyMetadata(false,
                    OnAnimateInFromLeftPropertyChanged));

        /// <summary>
        /// Callback that is fired whenever the <see cref="AnimateInFromLeftProperty"/> is changed
        /// </summary>
        /// <param name="d">The WPF element that this property is attached to</param>
        /// <param name="e">Args describing the event</param>
        private static void OnAnimateInFromLeftPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Make sure the element is valid
            if (!(d is FrameworkElement element))
                return;

            // Prevent the animation being played at design time
            if (DesignerProperties.GetIsInDesignMode(element))
                return;

            // If the value we set to is True...
            if ((bool)e.NewValue)
            {
                // Attach an event handler to the loaded event to play the animation
                element.Loaded += (ss, ee) => SlideInFromLeft(element);
            }
        }

        // SETTER
        public static void SetAnimateInFromLeft(DependencyObject element, bool value)
            => element.SetValue(AnimateInFromLeftProperty, value);

        // GETTER
        public static bool GetAnimateInFromLeft(DependencyObject element)
            => (bool)element.GetValue(AnimateInFromLeftProperty);

        #endregion

        #region Helper Methods

        /// <summary>
        /// Plays an animation on any framework element, moving the element from left to right (to where the element is located by default)
        /// </summary>
        /// <param name="element">The element to animate</param>
        private async static void SlideInFromLeft(FrameworkElement element)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add the animation
            sb.AddSlideInAnimation(element.ActualWidth, SlideInFrom.Left, .5F, true);

            // Play the animation
            sb.Begin(element);

            await Task.Delay(500);
        }

        #endregion
    }
}
