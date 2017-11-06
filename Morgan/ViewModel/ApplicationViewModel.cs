using System.Collections.Generic;
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
        /// Backing field for the application page
        /// </summary>
        ApplicationPage _applicationPage = ApplicationPage.None;

        /// <summary>
        /// Controls the currently visible root page of the application
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

        /// <summary>
        /// Backing field for the application sub page
        /// </summary>
        ApplicationSubHomePage _applicationSubHomePage = ApplicationSubHomePage.HomePage;

        /// <summary>
        /// Controls the currently selected sub page of the root <see cref="HomePage"/>
        /// </summary>
        public ApplicationSubHomePage ApplicationSubHomePage
        {
            get => _applicationSubHomePage;
            set
            {
                if (value == _applicationSubHomePage)
                    return;
                _applicationSubHomePage = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
