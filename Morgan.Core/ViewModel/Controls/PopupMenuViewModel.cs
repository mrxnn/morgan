using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Morgan.Core
{
    /// <summary>
    /// View model associated with the <see cref="PopupMenuControl"/>
    /// </summary>
    public class PopupMenuViewModel : BaseViewModel
    {
        #region Public Property

        /// <summary>
        /// Main message to display
        /// </summary>
        public string PrimaryMessage { get; set; }

        /// <summary>
        /// Secondary message to display in grayed color
        /// </summary>
        public string SecondaryMessage { get; set; }

        /// <summary>
        /// Text to show in the menu button
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// Controls if the menu should be shown
        /// </summary>
        public bool MenuVisible { get; private set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to execute when the popup menu button is clicked
        /// </summary>
        public ICommand ButtonClickCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PopupMenuViewModel()
        {
        }

        #endregion

        /// <summary>
        /// Displays the PopupMenu for a period of time
        /// </summary>
        /// <param name="primaryMessage">Main message to display</param>
        /// <param name="secondaryMessage">Secondary message</param>
        /// <param name="buttonText">Text to display on the menu button</param>
        /// <param name="buttonAction">Action to run when the button is clicked</param>
        /// <param name="duration">Duration to keep the menu visible for</param>
        public void ShowMenu(string primaryMessage, string secondaryMessage = null, string buttonText = "Hide", Action buttonAction = null, int duration = 10000)
        {
            // Set the messages
            PrimaryMessage = primaryMessage;
            SecondaryMessage = secondaryMessage;
            ButtonText = buttonText;

            // Add a default button action if nothing specified
            if (buttonAction == null)
            {
                // This simply hides the PopupMenu
                buttonAction = () => MenuVisible = false;
            }

            // Add the button click command
            ButtonClickCommand = new ActionCommand(buttonAction);

            // Show the menu
            MenuVisible = true;

            // Hide the menu after the duration
            Task.Delay(duration).GetAwaiter().OnCompleted(() => MenuVisible = false);
        }
    }
}
