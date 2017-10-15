using System.Collections.Generic;
using System.Threading.Tasks;

namespace Morgan
{
    /// <summary>
    /// Abstraction of a service that interacts with file system
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Returns a location that points to a logical file in the file system
        /// </summary>
        /// <returns></returns>
        string GetLocation();

        /// <summary>
        /// Returns a list of all the music files in a specified location
        /// </summary>
        /// <param name="location">Location to get music files from</param>
        /// <returns></returns>
        Task<List<string>> GetMusicFilesFromASingleLocationAsync(string location);

        /// <summary>
        /// Returns a list of music files from multiple locations
        /// </summary>
        /// <param name="locations">list of locations to get music files from</param>
        /// <returns></returns>
        Task<List<string>> GetMusicFilesFromAMultipleLocationsAsync(IList<string> locations);
    }
}
