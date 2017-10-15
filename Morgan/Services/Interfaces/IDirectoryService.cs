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
    }
}
