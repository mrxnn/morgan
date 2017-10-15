using System;
using System.IO;

namespace Morgan
{
    /// <summary>
    /// A View Model for each music file
    /// </summary>
    public class MusicFileViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Location of the music file
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Genre of this music file
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Artist of this music file
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Album that this music file belongs to
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Title of this music file, If the title cannot be inferred, 
        /// it will be replaced with the name of the file
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new music file
        /// </summary>
        /// <param name="location">Location of this music file</param>
        public MusicFileViewModel(string location)
        {
            Location = location;

            // Load all the metadata of this file
            LoadMetaData();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loads the required metadata such as genre, album for this file
        /// </summary>
        private void LoadMetaData()
        {
            // If the file is deleted at this moment after it's loaded,
            if (!File.Exists(Location))
                return;

            // Get all the metadata for this file
            var md = IoC.Get<IMetadataService>().GetMetaData(Location);

            // Initialize the properties with the metadata
            Genre = string.IsNullOrEmpty(md.genre) ? "Unknown Genre" : md.genre;
            Artist = string.IsNullOrEmpty(md.artist) ? "Unknown Artist" : md.artist;
            Album = string.IsNullOrEmpty(md.album) ? "Unknown Album" : md.album;
            Title = md.title;
        }

        #endregion
    }
}
