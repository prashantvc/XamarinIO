using System.Text.RegularExpressions;

namespace XamarinIO
{
    public class ParserUtils
    {
        public static string BLOCK_TYPE_SESSION = "session";
        public static string BLOCK_TYPE_CODE_LAB = "codelab";

        private static readonly Regex SanitisePattern = new Regex("[^a-z0-9-_]");

        public static string SanitizeId(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

           return SanitisePattern.Replace(input, string.Empty);
        }
    }
}