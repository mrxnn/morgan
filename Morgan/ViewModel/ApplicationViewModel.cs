using System.Collections.Generic;

namespace Morgan
{
    /// <summary>
    /// View Model for the state of the Entire Application
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Backing field for the Music Folder Location
        /// </summary>
        IList<string> _locationsList = new List<string>();

        /// <summary>
        /// List of root music directories that the user has selected
        /// </summary>
        public IList<string> LocationsList
        {
            get => _locationsList;
            set
            {
                if (value == _locationsList)
                    return;
                _locationsList = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Backing field for the application page
        /// </summary>
        ApplicationPage _applicationPage = ApplicationPage.HomePage;

        /// <summary>
        /// Controls the currently visible page of the application
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => _applicationPage;
            set
            {
                if (value == _applicationPage)
                    return;
                _applicationPage = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
