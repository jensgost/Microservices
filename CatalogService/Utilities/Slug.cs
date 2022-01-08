using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CatalogService.Utilities
{
        public static class Slug
        {
        public static string RemoveAccents(this string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                    return text;

                text = text.Normalize(NormalizationForm.FormD);
                char[] chars = text
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
                    != UnicodeCategory.NonSpacingMark).ToArray();

                return new string(chars).Normalize(NormalizationForm.FormC);
            }
            public static string Slugify(this string phrase)
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