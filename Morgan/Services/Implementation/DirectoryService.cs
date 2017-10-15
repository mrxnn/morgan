using System.Windows.Forms;

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
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var result = dialog.SelectedPath;
                    if (!string.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                }
                return null;
            }
        }
    }
}
