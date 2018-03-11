using System.IO;

namespace Morgan.Core
{
    /// <summary>
    /// A View Model for each music file
    /// </summary>
    public class MusicFileViewModel : BaseViewModel
    {
        #region Public Property

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

        /// <summary>
        /// The file extension
        /// </summary>
        public string Extension => Path.GetExtension(Location);

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

        #region Methods

        /// <summary>
        /// Loads the required metadata such as genre, album for this file
        /// </summary>
        private void LoadMetaData()
        {
            if (!File.Exists(Location))
                return;

            // Get all the metadata for this file
            var (genre, artist, album, title) = IoC.Get<IMetadataService>().GetMetaData(Location);

            // Initialize the properties with the metadata
            Genre = (string.IsNullOrEmpty(genre) ? "Unknown Genre" : genre);
            Artist = (string.IsNullOrEmpty(artist) ? "Unknown Artist" : artist);
            Album = (string.IsNullOrEmpty(album) ? "Unknown Album" : album);
            Title = title;
        }

        /// <summary>
        /// Returns the metadata for a specific tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string Get(TagType? tag)
        {
            switch (tag)
            {
                case TagType.GENRE:
                    return Genre;
                case TagType.ARTIST:
                    return Artist;
                case TagType.ALBUM:
                    return Album;
                case TagType.TITLE:
                    return Title;
                case TagType.NONE:
                    return string.Empty;
            }

            return string.Empty;
        }

        #endregion
    }
}
