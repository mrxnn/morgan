using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    public class PopupMenuSlideFromTopProperty : BaseAnimationProperty<PopupMenuSlideFromTopProperty>
    {
        protected override void Play(FrameworkElement element, bool value, bool firstLoad = false)
        {
            // Storyboard!
            var storyboard = new Storyboard();
            if (value)
            {
                element.Visibility = Visibility.Visible;
                storyboard.AddSlideInAnimation(element.ActualHeight, SlideInFrom.Top, 0.3F, false);
            }
            else
            {
                if (FirstLoad) element.Visibility = Visibility.Hidden;
                storyboard.AddSlideOutAnimation(element.ActualHeight, SlideOutTo.Top, 0.3F, false);
            }

            storyboard.Begin(element);
        }
    }
}
