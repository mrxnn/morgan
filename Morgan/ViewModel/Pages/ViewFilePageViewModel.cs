using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Morgan
{
    /// <summary>
    /// View Model for the <see cref="ViewFilePage"/>
    /// </summary>
    public class ViewFilePageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of all the music folder locations to scan for music files
        /// </summary>
        public IList<string> LocationsList { get; set; } = new List<string>();

        /// <summary>
        /// List of music files after each music file is mapped to <see cref="MusicFileViewModel"/> instances.
        /// So that each music file contains all the required metadata that is used to re-arrange files
        /// </summary>
        public ObservableCollection<MusicFileViewModel> MusicFileList { get; set; } = new ObservableCollection<MusicFileViewModel>();

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
        public ViewFilePageViewModel()
        {
            // Initialize the prerequesite properties
            LocationsList = IoC.Get<ApplicationViewModel>().LocationList;

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
            var list = await IoC.Get<IDirectoryService>().GetMusicFilesFromAMultipleLocationsAsync(LocationsList);

            // Map each music file into MusicFileViewModel objects
            MusicFileList = new ObservableCollection<MusicFileViewModel>(await MapFilesToModelsAsync(list));
        }

        /// <summary>
        /// Accepts a plain file list and returns a collection that each file is mapped to <see cref="MusicFileViewModel"/>
        /// </summary>
        /// <param name="list">List of plain music files</param>
        /// <returns></returns>
        private Task<List<MusicFileViewModel>> MapFilesToModelsAsync(List<string> list)
        {
            return Task.Run(() =>
            {
                return list.Select(f => new MusicFileViewModel(f)).ToList();
            });
        }

        #endregion
    }
}
