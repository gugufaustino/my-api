using System.Text.RegularExpressions;

namespace Business.Util
{
    public static class StringExtensions
    {
        public static string RemoverMascara(this string str)
        {
            return str != null ? Regex.Replace(str, @"[^\d]", string.Empty) : str;
        }
    }
}
