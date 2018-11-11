using System.Text.RegularExpressions;

namespace jwtokencore.Api.Infrastructure.Helpers
{
    public static class Strings
    {
        public static string RemoveAllNonPrintableCharacters(string target)
        {
            return Regex.Replace(target, @"\p{C}+", string.Empty);
        }
    }
}
