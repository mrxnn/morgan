using System;
using System.IO;
using System.Threading.Tasks;

namespace Morgan
{
    /// <summary>
    /// An Implementation for the <see cref="IMetadataService"/> using TagLib Sharp Library
    /// </summary>
    public class MetadataService : IMetadataService
    {
        /// <summary>
        /// Returns a tuple containing all the metadata required for a music file
        /// </summary>
        /// <param name="file">The physical file location on the disk</param>
        /// <returns></returns>
        public (string genre, string artist, string album, string title) GetMetaData(string file)
        {
            try
            {
                using (var tagLibFile = TagLib.File.Create(file))
                {
                    var _genre = tagLibFile.Tag.FirstGenre;
                    var _artist = tagLibFile.Tag.FirstAlbumArtist;
                    var _album = tagLibFile.Tag.Album;
                    var _title = tagLibFile.Tag.Title;
                    if (string.IsNullOrWhiteSpace(_title))
                        _title = Path.GetFileNameWithoutExtension(file);

                    return (_genre, _artist, _album, _title);
                }
            }
            catch (Exception)
            {
                // Log the exception
            }

            // If any error occurred while trying to infer the tags, return default values
            return (genre: "Unknown Genre", artist: "Unknown Artist", album: "Unknown Album", title: Path.GetFileNameWithoutExtension(file));
        }

        /// <summary>
        /// Asynchronous version of the <see cref="GetMetaData(string)"/> method
        /// </summary>
        /// <param name="file">The physical file location on the disk</param>
        /// <returns></returns>
        public Task<(string genre, string artist, string album, string title)> GetMetaDataAsync(string file)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var tagLibFile = TagLib.File.Create(file))
                    {

                        var _genre = tagLibFile.Tag.FirstGenre;
                        var _artist = tagLibFile.Tag.FirstAlbumArtist;
                        var _album = tagLibFile.Tag.Album;
                        var _title = tagLibFile.Tag.Title;
                        if (string.IsNullOrWhiteSpace(_title))
                            _title = Path.GetFileNameWithoutExtension(file);

                        return (_genre, _artist, _album, _title);
                    }
                }
                catch (Exception)
                {
                    // Log the exception
                }

                // If any error occurred while trying to infer the tags, return default values
                return ("Unknown Genre","Unknown Artist", "Unknown Album", Path.GetFileNameWithoutExtension(file));
            });
        }
    }
}
