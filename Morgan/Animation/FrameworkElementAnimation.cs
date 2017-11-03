using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    /// <summary>
    /// Extensions and a collection of helper methods to make it easier to make new animations!
    /// </summary>
    public static class FrameworkElementAnimation
    {
        #region Slide In Animation

        /// <summary>
        /// Adds a SLIDE IN animation to a storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="offset">Offset to start animating from</param>
        /// <param name="from">Slide direction</param>
        /// <param name="duration">Time that it takes to complete the animation</param>
        /// <param name="adjustLayout">Flag indicating if the layout adjustments should be visible or not</param>
        /// <param name="decelerationRatio">Deceleration ratio</param>
        /// <param name="easing">Easing Mode that is used for the easing function</param>
        public static void AddSlideInAnimation(this Storyboard storyboard, double offset, SlideInFrom from, float duration = .8f, bool adjustLayout = true, float decelerationRatio = .9f, EasingMode easing = EasingMode.EaseIn)
        {
            // DETERMINE where to start the animation from based on the slide direction
            Thickness? _initialThickness = null;
            switch (from)
            {
                case SlideInFrom.Left:
                    _initialThickness = new Thickness(-offset, 0, adjustLayout ? 0 : offset, 0);
                    break;
                case SlideInFrom.Top:
                    _initialThickness = new Thickness(0, -offset, 0, adjustLayout ? 0 : offset);
                    break;
                case SlideInFrom.Right:
                    _initialThickness = new Thickness(adjustLayout ? 0 : offset, 0, -offset, 0);
                    break;
                case SlideInFrom.Bottom:
                    _initialThickness = new Thickness(0, adjustLayout ? 0 : offset, 0, -offset);
                    break;
                default:
                    break;
            }

            // Init the animation to play
            var animation = new ThicknessAnimation
            {
                From = _initialThickness,
                To= new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                EasingFunction = new PowerEase { EasingMode = easing, Power=10 }
            };

            // Set the target property
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion

        #region SLide Out Animation

        /// <summary>
        /// Adds a SLIDE OUT animation to a storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="offset">Offset to start animating from</param>
        /// <param name="to">Slide direction</param>
        /// <param name="duration">Time that it takes to complete the animation</param>
        /// <param name="adjustLayout">Flag indicating if the layout adjustments should be visible or not</param>
        /// <param name="decelerationRatio">Deceleration ratio</param>
        /// <param name="easing">Easing Mode that is used for the easing function</param>
        public static void AddSlideOutAnimation(this Storyboard storyboard, double offset, SlideOutTo to, float duration = .8f, bool adjustLayout = true, float decelerationRatio = .9f, EasingMode easing = EasingMode.EaseIn)
        {
            // DETERMINE where to end the animation from based on the slide out direction
            Thickness? _expectedThickness = null;
            switch (to)
            {
                case SlideOutTo.Left:
                    _expectedThickness = new Thickness(-offset, 0, adjustLayout ? 0 : offset, 0);
                    break;
                case SlideOutTo.Top:
                    _expectedThickness = new Thickness(0, -offset, 0, adjustLayout ? 0 : offset);
                    break;
                case SlideOutTo.Right:
                    _expectedThickness = new Thickness(adjustLayout ? 0 : offset, 0, -offset, 0);
                    break;
                case SlideOutTo.Bottom:
                    _expectedThickness = new Thickness(0, adjustLayout ? 0 : offset, 0, -offset);
                    break;
                default:
                    break;
            }

            // Init the animation to play
            var animation = new ThicknessAnimation
            {
                To = _expectedThickness,
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                DecelerationRatio = decelerationRatio,
                EasingFunction = new PowerEase { EasingMode = easing, Power = 10 }
            };

            // Set the target property
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion
    }
}
