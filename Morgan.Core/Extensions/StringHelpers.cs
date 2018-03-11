using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Morgan.Core
{
    /// <summary>
    /// Helper classes that extends the <see cref="System.String"/> class.
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Removes all the invalid charactors contained within a string file path.
        /// </summary>
        /// <param name="fileName">the path</param>
        /// <returns></returns>
        public static string NormalizeString(this string fileName)
        {
            return Regex.Replace(fileName, @"[\\/\*:?<>|]", "");
        }

        /// <summary>
        /// Removes some invalid characters for file names in Windows.
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns></returns>
        public static string NormalizeFileName(this string fileName)
        {
            // Trim the path
            fileName = fileName.Trim();

            // Remove any dots at the start or end
            BEGINLABEL:
            if (fileName.EndsWith("."))
            {
                fileName = fileName.Remove(fileName.Length - 1);
                goto BEGINLABEL;
            }
            if (fileName.StartsWith("."))
            {
                fileName = fileName.Remove(0, 1);
                goto BEGINLABEL;
            }

            // Remove any other invalid characters
            return string.Join("", fileName.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Updates the file path in a way that the directory seperator adapts to the OS.
        /// </summary>
        /// <param name="path">Path to update</param>
        /// <returns></returns>
        public static string MakePlatformIndependentPath(this string path)
        {
            // On Windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = path.Replace("/", "\\");
            // On Linux, Mac
            else
                path = path.Replace("\\", "/");

            return path;
        }
    }
}
