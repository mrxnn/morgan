using System.Text.RegularExpressions;

namespace Morgan
{
    /// <summary>
    /// Helper classes that extends the <see cref="System.String"/> class
    /// </summary>
    public static class StringHelpers
    {
        public static string NormalizeString(this string fileName)
        {
            return Regex.Replace(fileName, @"[\\/\*:?<>|]", "");
        }
    }
}
