using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Translator.Data.Models;

namespace Translator
{
    public static class StringExtension
    {
        public static void ReadPair(this string str, List<Word> wordList)
        {
            string wordPairPattern = "([а-яА-Я]+)_([a-zA-Z]+)";

            Match match = Regex.Match((str), wordPairPattern);
            if (match.Groups[0].Value != "")
            {
                wordList.Add(new Word
                {
                    RusTrans = match.Groups[1].Value,
                    EngTrans = match.Groups[2].Value
                });
            }
        }
    }
}
