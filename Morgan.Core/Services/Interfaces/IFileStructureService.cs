using System.Collections.Generic;
using System.Threading.Tasks;

namespace Morgan.Core
{
    /// <summary>
    /// Interactive logic for a service that organizes music files
    /// </summary>
    public interface IFileStructureService
    {
        /// <summary>
        /// Makes a structure of music files and organizes them in directory level
        /// </summary>
        /// <param name="source">List of music files to organize</param>
        /// <param name="order">Hierachy of the files to organize</param>
        /// <returns></returns>
        Task OrganizeAsync(string destination, IList<MusicFileViewModel> source, FileHierachicalOrder order);
    }
}
