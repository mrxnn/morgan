using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace Morgan
{
    public class ButtonPanelSlideFromBottomProperty : BaseAnimationProperty<ButtonPanelSlideFromBottomProperty>
    {
        protected override void Play(FrameworkElement element, bool value, bool firstLoad = false)
        {
            // Don't play the animation at design time
            if (DesignerProperties.GetIsInDesignMode(element))
                return;

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
