using System.Text.RegularExpressions;
using System.Text;

namespace CatalogService
{
    public static class Slug
    {
        public static string Slugify(string phrase)
        {
            phrase = phrase.ToLowerInvariant();

            var bytes = Encoding.GetEncoding(0).GetBytes(phrase!);
            
            phrase = Encoding.ASCII.GetString(bytes);

            phrase = Regex.Replace(phrase, @"\-", "", RegexOptions.Compiled);

            phrase = Regex.Replace(phrase, @"\s", "-", RegexOptions.Compiled);

            phrase = Regex.Replace(phrase, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            phrase = phrase.Trim('-');

            phrase = Regex.Replace(phrase, @"([-]){2,}", "$1", RegexOptions.Compiled);

            return phrase;
        }
    }
}
