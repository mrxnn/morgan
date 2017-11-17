using System.Collections.ObjectModel;

namespace Morgan
{
    /// <summary>
    /// View Model for the state of the Entire Application
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of root music directories that the user has selected
        /// </summary>
        public ObservableCollection<string> LocationList { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Controls the currently visible root page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }

        /// <summary>
        /// Controls the currently selected sub page of the root <see cref="HomePage"/>
        /// </summary>
        public ApplicationSubHomePage ApplicationSubHomePage { get; set; }

        #endregion
    }
}
