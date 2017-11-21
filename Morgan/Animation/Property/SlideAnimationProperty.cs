using System.Windows;

namespace Morgan
{
    /// <summary>
    /// Root class for any framework element animation to gain base animation functionality
    /// </summary>
    /// <typeparam name="T">Actual animation type</typeparam>
    public class BaseAnimationProperty<T> where T : BaseAnimationProperty<T>, new()
    {
        #region Public Properties
        
        /// <summary>
        /// Instance of the actual animation class
        /// </summary>
        public static T Instance { get; set; } = new T();

        /// <summary>
        /// Flag indicating if this is the first time the animation is being played
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

        #region Property

        /// <summary>
        /// Property that is ultimately attached to any framework element to get the desired animation
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(bool), typeof(BaseAnimationProperty<T>),
            new PropertyMetadata(false,
                OnValuePropertyChanged,
                OnValuePropertyUpdated));

        #endregion

        #region Accessors

        // GETTER
        public static bool GetValue(DependencyObject element) => (bool)element.GetValue(ValueProperty);

        // SETTER
        public static void SetValue(DependencyObject element, bool value) => element.SetValue(ValueProperty, value);

        #endregion

        #region Callbacks

        /// <summary>
        /// Called when the value of the property is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// Called when the value of the property is changed, even if the value is same
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object OnValuePropertyUpdated(DependencyObject d, object baseValue)
        {
            // Get the framework element
            if (!(d is FrameworkElement element))
                return baseValue;

            /**
             * If this is the first load, we wait for the element to be loaded completely, and plays animation right away;
             * Otherwise, we check if the new value is different from the current value, and if it is, we play the animation;
             * Return otherwise;
             */

            if (Instance.FirstLoad)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Play the animation
                    Instance.Play(element, (bool)baseValue);

                    // Unhook the event
                    element.Loaded -= onLoaded;

                    // No longer in the first load
                    Instance.FirstLoad = false;
                };
                // Hook the event
                element.Loaded += onLoaded;
            }
            else
            {
                // Not the first load, so run the animation if the new value is changed
                if ((bool)element.GetValue(ValueProperty) != (bool)baseValue)
                {
                    // Play the animation
                    Instance.Play(element, (bool)baseValue);
                }
            }

            // Return the original value
            return baseValue;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// This method should be overridden by actual animation classes
        /// </summary>
        /// <param name="element">Framework Element to animate</param>
        /// <param name="value">Value indicating the animation direction; Eg: Slide In or Slide Out</param>
        /// <param name="firstLoad">Flag indicating if this is the first time the animation is played</param>
        protected virtual void Play(FrameworkElement element, bool value, bool firstLoad = false) { }

        #endregion
    }
}
