using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    /// <summary>
    /// Animation that can be attached to any framework element and the element will be slide in or out based on boolean flag!
    /// </summary>
    public class SlideFromTopProperty
    {
        #region Properties

        /// <summary>
        /// Flag indicating if this is the first time the animation is being played
        /// </summary>
        public static bool FirstLoad { get; set; } = true;

        #endregion

        #region Attached Property

        /// <summary>
        /// Property that is used to animate any framework element from bottom to where it is located by default
        /// </summary>
        public static readonly DependencyProperty SlideInOutFromTopProperty = DependencyProperty.RegisterAttached("SlideInOutFromTop", typeof(bool), typeof(SlideFromTopProperty),
            new PropertyMetadata(false,
                OnSlideInOutFromTopPropertyChanged,
                OnSlideInOutFromTopPropertyUpdated));

        #endregion

        #region Callbacks

        /// <summary>
        /// This method is fired each time the property that is attached to the element is changed, even if the updated value is the same
        /// </summary>
        /// <param name="d">Element</param>
        /// <param name="baseValue">Updated value</param>
        /// <returns></returns>
        private static object OnSlideInOutFromTopPropertyUpdated(DependencyObject d, object baseValue)
        {
            // Get the framework element
            if (!(d is FrameworkElement element))
                return baseValue;

            #region DesignerFix
            // Dont play the animation at design time
            if (DesignerProperties.GetIsInDesignMode(element))
                return baseValue;
            #endregion

            // Make sure the value has changed
            if (((bool)element.GetValue(SlideInOutFromTopProperty)) == ((bool)baseValue) && !FirstLoad)
                return baseValue;

            // If this is the first load, wait for the element to be loaded
            if (FirstLoad)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook the loaded event
                    element.Loaded -= onLoaded;
                    // Play the animation
                    PlayTheAnimation(element, (bool)baseValue);
                    // No longer in first load
                    FirstLoad = false;
                };

                // Attach the event handler
                element.Loaded += onLoaded;
            }
            else
            {
                // If this isn't the first time, play the animation right away
                PlayTheAnimation(element, (bool)baseValue);
            }

            // Return the value
            return baseValue;
        }

        #endregion

        #region Unused
        private static void OnSlideInOutFromTopPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        #endregion

        #region Helpers

        /// <summary>
        /// Play the slide animation
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="baseValue">value, indicating the slide direction</param>
        private static void PlayTheAnimation(FrameworkElement element, bool baseValue)
        {
            //if ((baseValue && Visible) || (!baseValue && !Visible))
            //{
            //    if (FirstLoad)
            //        goto JUMP;
            //    return;
            //}
            //JUMP:

            // Storyboard!
            var storyboard = new Storyboard();

            if (baseValue)
            {
                // SLIDE IN
                element.Visibility = Visibility.Visible;
                storyboard.AddSlideInAnimation(element.ActualHeight, SlideInFrom.Top, 0.3F, false);
            }
            else
            {
                // SLIDE OUT
                if (FirstLoad) element.Visibility = Visibility.Hidden;
                storyboard.AddSlideOutAnimation(element.ActualHeight, SlideOutTo.Top, 0.3F, false);
            }

            storyboard.Begin(element);
        }

        #endregion

        // GETTER
        public static bool GetSlideInOutFromTop(DependencyObject element)
            => (bool)element.GetValue(SlideInOutFromTopProperty);

        // SETTER
        public static void SetSlideInOutFromTop(DependencyObject element, bool value)
            => element.SetValue(SlideInOutFromTopProperty, value);
    }
}
