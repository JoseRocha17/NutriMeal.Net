using System;
using System.Text.RegularExpressions;

namespace Nutrimeal.Common
{
    public static class StringExtentions
    {
        public static string CapitalizeSentence(this string source)
        {
            if (string.IsNullOrEmpty(source)) return source;
            var rx = new Regex(@"(?<=\w)\w");
            return rx.Replace(source, m => m.Value.ToLowerInvariant()).Trim();
        }

        public static string RemoveDangerousTags(this string source)
        {
            var n = source;
            return Regex.Replace(n, "<.*?>.*?</.*?>", string.Empty);
        }

        /// <summary>
        /// date parsing
        /// </summary>
        /// <param name="data">dd/MM/yyyy</param>
        /// <returns></returns>
        public static DateTime ToDate(this string data)
        {
            var dayStart = data.Split('/')[0];
            var monthStart = data.Split('/')[1];
            var yearStart = data.Split('/')[2];
            return new DateTime(int.Parse(yearStart), int.Parse(monthStart), int.Parse(dayStart));
        }
    }
}