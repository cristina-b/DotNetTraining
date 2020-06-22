using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet4
{
    public static class LINKex3
    {
        public static List<string> extractURLs(string phrase)
        {
            List<string> results = new List<string>();
            foreach (Match item in Regex.Matches(phrase, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
            {
                results.Add(item.Value);
            }
            return results;
        }

        public static List<string> extractHTTPS(string phrase)
        {
            List<string> results = new List<string>();
            foreach (Match item in Regex.Matches(phrase, @"(https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
            {
                results.Add(item.Value);
            }
            return results;
        }

        public static List<string> URLsEndingWithEDU(string phrase)
        {
            List<string> results = new List<string>();
            foreach (Match item in Regex.Matches(phrase, @"(https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?.edu"))
            {
                results.Add(item.Value);
            }
            return results;
        }
    }
}
