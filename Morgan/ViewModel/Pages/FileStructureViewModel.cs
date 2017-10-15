using System.Collections.Generic;

namespace Morgan
{
    /// <summary>
    /// View Model for the <see cref="FileStructurePage"/>
    /// </summary>
    public class FileStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of all the music folder locations to scan for music files
        /// </summary>
        public IList<string> LocationsList { get; set; } = new List<string>();

        /// <summary>
        /// List of all the music files scanned from the specified locations
        /// </summary>
        public IList<string> MusicFileList { get; set; } = new List<string>();

        /// <summary>
        /// Number of locations stored in the Location list
        /// </summary>
        public int LocationCount => LocationsList.Count;

        /// <summary>
        /// Number of music files stored in the Music File list
        /// </summary>
        public int MusicFileCount => MusicFileList.Count;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileStructureViewModel()
        {
            // Initialize the prerequesite properties
            LocationsList = IoC.Get<ApplicationViewModel>().LocationsList;

            // Update the UI
            OnPropertyChanged(nameof(LocationCount));

            // Load the music files
            LoadMusicFiles();
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Loads all the music files in the specified locations
        /// </summary>
        private async void LoadMusicFiles()
        {
            // Get all the music files in the different locations
            MusicFileList = await IoC.Get<IDirectoryService>().GetMusicFilesFromAMultipleLocationsAsync(LocationsList);
            OnPropertyChanged(nameof(MusicFileCount));
        }

        #endregion
    }
}
