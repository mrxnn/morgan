using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Morgan
{
    /// <summary>
    /// An Implementation for the <see cref="IDirectoryService"/>
    /// </summary>
    public class DirectoryService : IDirectoryService
    {
        /// <summary>
        /// Displays a propmt to the user to select a location in the file system
        /// </summary>
        /// <returns></returns>
        public string GetLocation()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                // If the user selected a location
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var result = dialog.SelectedPath;
                    if (!string.IsNullOrEmpty(result))
                    {
                        // Return the selected location
                        return result;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all the music files in a specified location
        /// </summary>
        /// <param name="location">Location to get music files from</param>
        /// <returns></returns>
        public Task<List<string>> GetMusicFilesFromASingleLocationAsync(string location)
        {
            /**
             * NOTE:
             * Although it's kind of I/O Bound, we have to run it from a pooled thread, since there is still
             * no asynchronous equalant that uses TaskCompletionSource in the bottom level to get all the files
             * in a directory. And since there is no multiple threads altogether trying to access the file
             * system concurrenlty in this application, it's rather ok to use this approach for now...
             */

            return Task.Run(() =>
            {
                return Directory.GetFiles(location, "*.mp3", SearchOption.AllDirectories).ToList();
            });
        }

        /// <summary>
        /// Returns a list of music files from multiple locations
        /// </summary>
        /// <param name="locations">list of locations to get music files from</param>
        /// <returns></returns>

        public Task<List<string>> GetMusicFilesFromAMultipleLocationsAsync(IList<string> locations)
        {
            return Task.Run(async () =>
            {
                // A list to hold all the music files
                var list = new List<string>();

                foreach (var item in locations)
                {
                    // Get the files from a single location
                    var musicFiles = await GetMusicFilesFromASingleLocationAsync(item);

                    // Add the files to the list
                    list.AddRange(musicFiles);
                }

                // Return the list containing all the music files
                return list;
            });
        }

    }
}
