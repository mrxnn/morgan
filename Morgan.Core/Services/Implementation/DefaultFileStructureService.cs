using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                source.ToList().ForEach(file =>
                {
                    // Generate new file path!
                    var newDirectoryPath = $"{destination}/{file.Get(order.Level1)}/{file.Get(order.Level2)}/{file.Get(order.Level3)}";
                    var newFilePath = $"{destination}/{file.Get(order.Level1)}/{file.Get(order.Level2)}/{file.Get(order.Level3)}/{file.Get(order.Level4)}{file.Extension}";

                    // TODO
                    // Copy the file into the directory that is created
                    // Log the state of the operation that is performed
                });
            });
        }
    }
}
