using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Morgan.Core
{
    /// <summary>
    /// An Implementation for the <see cref="IDirectoryService"/>. This class uses the built-in dialogs in 
    /// Windows platform. As a result, this implementation should remain in WPF project!
    /// </summary>
    public class MSWindowsDirectoryService : IDirectoryService
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
            // Create a bottom level IO bound operation using tcs
            var tcs = new TaskCompletionSource<List<string>>();
            try
            {
                // Get a list of files in the directory
                var list = Directory.GetFiles(location, "*.mp3", SearchOption.AllDirectories).ToList();

                // Set the task's result
                tcs.SetResult(list);
            }
            catch (Exception e)
            {
                // Set the exception if any is thrown
                tcs.SetException(e);
            }

            // Return the task
            return tcs.Task;
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

                    /**
                     * NOTE: 
                     * 
                     * Eventhough here we call a method that runs on the UI thread, framework can automatically handle
                     * any possible deadlock scenario. If the called method is transitioned into something else later, 
                     * its better to review this method call.
                     */

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
