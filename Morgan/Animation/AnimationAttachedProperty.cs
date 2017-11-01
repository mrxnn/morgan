using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    public class AnimationAttachedProperty
    {
        #region AnimateInFromRightProperty

        /// <summary>
        /// The property that is used to animate the side menu when the application is first loaded
        /// </summary>
        public static readonly DependencyProperty AnimateInFromRightProperty =
            DependencyProperty.RegisterAttached(
                "AnimateInFromRight", typeof(bool), typeof(AnimationAttachedProperty),
                new PropertyMetadata(false,
                    OnAnimateInFromRightPropertyChanged));

        /// <summary>
        /// Callback that is fired whenever the <see cref="AnimateInFromRightProperty"/> is changed
        /// </summary>
        /// <param name="d">The WPF element that this property is attached to</param>
        /// <param name="e">Args describing the event</param>
        private static void OnAnimateInFromRightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Make sure the element is valid
            if (!(d is FrameworkElement element))
                return;

            // If the value we set to is True...
            if ((bool)e.NewValue)
            {
                // Attach an event handler to the loaded event to play the animation
                element.Loaded += (ss, ee) => SlideInFromRight(element);
            }
        }

        // SETTER
        public static void SetAnimateInFromRight(DependencyObject element, bool value)
            => element.SetValue(AnimateInFromRightProperty, value);

        // GETTER
        public static bool GetAnimateInFromRight(DependencyObject element)
            => (bool)element.GetValue(AnimateInFromRightProperty);

        #endregion

        #region Helper Methods

        /// <summary>
        /// Plays an animation on any framework element, moving the element from right to left (to where the element is located by default)
        /// </summary>
        /// <param name="element">The element to animate</param>
        private static void SlideInFromRight(FrameworkElement element)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Create the animation
            var animation = new ThicknessAnimation
            {
                From = new Thickness(-element.ActualWidth, 0, 0, 0),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(.5)),
                DecelerationRatio = .9F,
                EasingFunction = new PowerEase { Power = 10, EasingMode = EasingMode.EaseIn }
            };

            // Set the property to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            sb.Children.Add(animation);

            // Play the animation
            sb.Begin(element);
        }

        #endregion
    }
}
