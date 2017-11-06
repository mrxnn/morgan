using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Morgan
{
    /// <summary>
    /// View Model associated with the <see cref="HomePage"/>
    /// </summary>
    public class HomePageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of folder locations to scan for music files
        /// </summary>
        public ObservableCollection<string> LocationsList { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Number of file locations stored in the <see cref="LocationsList"/>
        /// </summary>
        public int LocationCount => LocationsList.Count;

        /// <summary>
        /// Flag indicating if there is at least one location in the list
        /// </summary>
        public bool HasLocation => LocationCount > 0;

        /// <summary>
        /// Flag indicating if the Folder Browser Dialog is being displayed
        /// </summary>
        public bool IsLoadingALocation { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to add a new location to the location list
        /// </summary>
        public ICommand AddLocationCommand { get; set; }

        /// <summary>
        /// Command to load music files from the specified location
        /// </summary>
        public ICommand LoadFilesCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public HomePageViewModel()
        {
            // Initialize Commands
            AddLocationCommand = new ActionCommand(AddLocation);
            LoadFilesCommand = new ActionCommand(LoadFiles);

            // Update the UI whenever a new item is added to the location list
            LocationsList.CollectionChanged += (ss, ee) => OnGroupOfPropertyChanged(nameof(LocationCount), nameof(HasLocation));
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Adds a new location to the location list
        /// </summary>
        private void AddLocation()
        {
            try
            {
                // Set the flag to indicate that the user is choosing a location
                IsLoadingALocation = true;

                var location = IoC.Get<IDirectoryService>().GetLocation();
                if (Directory.Exists(location))
                {
                    // TODO:
                    // Prevent adding drives

                    // Add the new location
                    if (!LocationsList.Contains(location))
                        LocationsList.Add(location);
                }
            }
            finally
            {
                // Set the flag to indicate that the user has closed the dialog
                IsLoadingALocation = false;
            }
        }

        /// <summary>
        /// Loads all the files from the specified directory
        /// </summary>
        private void LoadFiles()
        {
            // Set the root music directory location i a glabal scope
            IoC.Get<ApplicationViewModel>().LocationList = this.LocationsList;

            // Change the current page of the application
            IoC.Get<ApplicationViewModel>().ApplicationSubHomePage = ApplicationSubHomePage.ViewFilePage;
        }

        #endregion
    }
}
