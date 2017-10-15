using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Morgan
{
    /// <summary>
    /// View Model associated with the <see cref="BaseFormPage"/>
    /// </summary>
    public class BaseFormPageViewModel : BaseViewModel
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
        public BaseFormPageViewModel()
        {
            // Initialize Commands
            AddLocationCommand = new ActionCommand(AddLocation);
            LoadFilesCommand = new ActionCommand(LoadFiles);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Adds a new location to the location list
        /// </summary>
        private void AddLocation()
        {
            var location = IoC.Get<IDirectoryService>().GetLocation();
            if (Directory.Exists(location))
                LocationsList.Add(location);

            // Notify the UI
            OnPropertyChanged(nameof(LocationCount));
        }

        /// <summary>
        /// Loads all the files from the specified directory
        /// </summary>
        private void LoadFiles()
        {
        }

        #endregion
    }
}
