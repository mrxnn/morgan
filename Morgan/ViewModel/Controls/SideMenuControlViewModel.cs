using System;
using System.Windows.Input;

namespace Morgan
{
    /// <summary>
    /// View Model for the <see cref="SideMenuControl"/>
    /// </summary>
    public class SideMenuControlViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Flag indicating if the home tab is currently selected
        /// </summary>
        public bool HomeIsSelected { get; set; }

        /// <summary>
        /// Flag indicating if the home tab is currently selected
        /// </summary>
        public bool SettingsIsSelected { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to navigate to the Home Page
        /// </summary>
        public ICommand NavigateToHomeCommand { get; set; }

        /// <summary>
        /// Command to navigate to the settings Page
        /// </summary>
        public ICommand NavigateToSettingsCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuControlViewModel()
        {
            // Initialize Commands
            NavigateToHomeCommand = new ActionCommand(() => Navigate(ApplicationPage.HomePage));
            NavigateToSettingsCommand = new ActionCommand(() => Navigate(ApplicationPage.SettingsPage));

            // Set the default page
            NavigateToHomeCommand.Execute(null);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Navigates to a different page
        /// </summary>
        /// <param name="page">Page to navigate</param>
        private void Navigate(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.HomePage:
                    IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.HomePage;
                    UpdateCurrentTab(() => HomeIsSelected = true);
                    break;

                case ApplicationPage.SettingsPage:
                    IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.SettingsPage;
                    UpdateCurrentTab(() => SettingsIsSelected = true);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Reset all the tabs that are selected
        /// </summary>
        /// <param name="action">Expression to set the current tab</param>
        private void UpdateCurrentTab(Action action)
        {
            // Reset previous selection
            HomeIsSelected = false;
            SettingsIsSelected = false;

            // Highlight the current tab
            action();

            // Fire the property changed notifications to adapt the UI
            OnGroupOfPropertyChanged(nameof(HomeIsSelected),
                nameof(SettingsIsSelected));
        }

        #endregion
    }
}
