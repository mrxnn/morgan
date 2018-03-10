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
    }
}
