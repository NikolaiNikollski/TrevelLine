using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace removeExtraBlanks
{
    public static class StringExtension
    {
        public static string RemoveExtraBlanks(this string str)
        {
            Dictionary<string, string> ReplaceDictioary = new Dictionary<string, string>
            {
                {" +", " "},
                { "( ?\t+ ?)+", "\t"},
                { "(^ | $)", ""},
                { "(^\t|\t$)", ""}
            };

            foreach (var pair in ReplaceDictioary)
            {
                 string pattern = pair.Key;
                 string target = pair.Value;
                 Regex regex = new Regex(pattern);
                 str = regex.Replace(str, target);
            }

            return str;
        }
    }
}
