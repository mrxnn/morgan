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
        /// Command to navigate to the root page of the Home, and the current sub page will be shown
        /// </summary>
        public ICommand NavigateToBaseHomeCommand { get; set; }

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
            NavigateToBaseHomeCommand = new ActionCommand(() => Navigate(ApplicationPage.BaseHomePage));
            NavigateToSettingsCommand = new ActionCommand(() => Navigate(ApplicationPage.SettingsPage));

            // Set the default page
            NavigateToBaseHomeCommand.Execute(null);
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
                case ApplicationPage.BaseHomePage:
                    IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.BaseHomePage;
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
        }

        #endregion
    }
}
