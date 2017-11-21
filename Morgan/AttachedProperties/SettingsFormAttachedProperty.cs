using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    /// <summary>
    /// Animation to play when the <see cref="SettingsFormControl"/> is on show or hide; Just a simple slide animation
    /// </summary>
    public class SettingsSlideInFromBottomProperty : BaseAnimationProperty<SettingsSlideInFromBottomProperty>
    {
        protected override void Play(FrameworkElement element, bool value, bool firstLoad = false)
        {
            // Storyboard!
            var storyboard = new Storyboard();
            if (value)
            {
                element.Visibility = Visibility.Visible;
                storyboard.AddSlideInAnimation(element.ActualHeight, SlideInFrom.Bottom, 0.3F, false);
            }
            else
            {
                if (FirstLoad) element.Visibility = Visibility.Hidden;
                storyboard.AddSlideOutAnimation(element.ActualHeight, SlideOutTo.Bottom, 0.3F, false);
            }

            storyboard.Begin(element);
        }
    }
}
