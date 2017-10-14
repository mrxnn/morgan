namespace Morgan
{
    /// <summary>
    /// View Model for the state of the Entire Application
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Controls the currently visible page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.WelcomePage;

        #endregion
    }
}
