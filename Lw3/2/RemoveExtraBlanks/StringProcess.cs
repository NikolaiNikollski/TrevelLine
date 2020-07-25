using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace removeExtraBlanks
{
    public class StringProcess
    {
        public string RemoveExtraBlanks(string inStr)
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
                 inStr = regex.Replace(inStr, target);
            }

            return inStr;
        }
    }
}
