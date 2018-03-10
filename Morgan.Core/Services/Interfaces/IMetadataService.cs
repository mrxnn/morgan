using System.Threading.Tasks;

namespace Morgan.Core
{
    /// <summary>
    /// A service used to fetch metadata associated with a music file
    /// </summary>
    public interface IMetadataService
    {
        /// <summary>
        /// Returns a tuple containing all the metadata required for a music file
        /// </summary>
        /// <param name="file">The physical file location on the disk</param>
        /// <returns></returns>
        (string genre, string artist, string album, string title) GetMetaData(string file);

        /// <summary>
        /// Asynchronous version of the <see cref="GetMetaData(string)"/> method
        /// </summary>
        /// <param name="file">The physical file location on the disk</param>
        /// <returns></returns>
        Task<(string genre, string artist, string album, string title)> GetMetaDataAsync(string file);
    }
}
