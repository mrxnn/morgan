using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Morgan.Core
{
    /// <summary>
    /// The default implementation for the <see cref="IFileStructureService"/>
    /// </summary>
    public class DefaultFileStructureService : IFileStructureService
    {
        /// <summary>
        /// Makes a structure of music files and organizes them in directory level
        /// </summary>
        /// <param name="destination">Output directory to save the files in</param>
        /// <param name="source">List of music files to organize</param>
        /// <param name="order">Hierachy of the files to organize</param>
        /// <returns></returns>
        public Task OrganizeAsync(string destination, IList<MusicFileViewModel> source, FileHierachicalOrder order)
        {
            return Task.Run(() =>
            {
                int error_count = 0;
                source.ToList().ForEach(file =>
                {
                    try
                    {
                        // Generate the Folder and the File names for each file.
                        var values = GenerateFileDestination(file.Location, 
                            destination, 
                            file.Get(order.Level1), 
                            file.Get(order.Level2), 
                            file.Get(order.Level3), 
                            file.Get(order.FinalTag));

                        // Create the directory
                        if (!Directory.Exists(values.directory))
                            Directory.CreateDirectory(values.directory);

                        // Copy the file to the directory
                        if (!File.Exists(values.file))
                            File.Copy(file.Location, values.file);
                    }
                    catch (Exception e)
                    {
                        // Log the exception
                        error_count++;
                    }
                });

                // Display a message to the user notifying the state of the operation.
                DI.PopupMenuViewModel.ShowMenu($"File organization is complete | Errors = {error_count}",
                    "Rate Morgan, like, share and tell us whats to improve!");
            });
        }

        /// <summary>
        /// Returns a tuple containing the final directory and the path to the final file, to where the file should be stored!
        /// </summary>
        /// <param name="location">Original file location</param>
        /// <param name="destination">Root directory for the organized files</param>
        /// <param name="tag1">1st tag</param>
        /// <param name="tag2">2nd tag</param>
        /// <param name="tag3">3rd tag</param>
        /// <param name="title">the title tag</param>
        /// <returns></returns>
        public static (string directory, string file) GenerateFileDestination(string location, string destination, string tag1, string tag2, string tag3, string title)
        {
            // Make sure the title is valid.
            // Title tag is always at the end of the path.
            if (string.IsNullOrEmpty(title))
                title = Path.GetFileNameWithoutExtension(location);

            // Get the file extension
            var extension = Path.GetExtension(location);

            // Normalized values for files
            tag1.NormalizeFileName();
            tag2.NormalizeFileName();
            tag3.NormalizeFileName();
            title.NormalizeFileName();

            // Generate the new location for the directory
            string newDirectoryPath = Path.Combine(destination, tag1, tag2, tag3);
            string newFileName = title + extension;
            string newFilePath = Path.Combine(newDirectoryPath, newFileName);

            // Make the path platform independent
            newDirectoryPath.MakePlatformIndependentPath();
            newFilePath.MakePlatformIndependentPath();

            // Return the information back!
            var values = (newDirectoryPath, newFilePath);
            return values;
        }
    }
}
