using System.Windows.Input;

namespace Morgan
{
    /// <summary>
    /// View model for the <see cref="SettingsFormControl"/>
    /// </summary>
    public class SettingsFormViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Controls if the control should be shown
        /// </summary>
        public bool SettingsFormVisible { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to hide or show the settings form control
        /// </summary>
        public ICommand ToggleFormVisibilityCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsFormViewModel()
        {
            ToggleFormVisibilityCommand = new ActionCommand(ToggleVisibility);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Hides or Show the <see cref="SettingsFormControl"/>
        /// </summary>
        private void ToggleVisibility()
        {
            SettingsFormVisible ^= true;
        }

        #endregion
    }
}
