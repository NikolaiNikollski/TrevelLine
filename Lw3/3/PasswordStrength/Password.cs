using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using PasswordStrength;

namespace GetPasswordStrength
{
    public static class StringExtension
    {
        public static int GetPasswordStrength(this string inStr)
        {
            if (!inStr.IsCorrectPass())
                return -1;
  
            int inStrStrength = 0; //1
            inStrStrength += inStr.GetStrenchForPassLength(); //2
            inStrStrength += inStr.GetStrenchForDigits(); //3
            inStrStrength += inStr.GetStrenchForUpperLetters(); //4
            inStrStrength += inStr.GetStrenchForLowLetters(); //5
            inStrStrength += inStr.TakeStrenchForDigitsAbsence(); //6
            inStrStrength += inStr.TakeStrenchForLettersAbsence(); //7
            inStrStrength += inStr.TakeStrenchForRepeatedChar(); //8
            return inStrStrength;
        }

        public static bool IsCorrectPass(this string inStr)
        {
            int passwordValidity = new Сriterion("^[a-zA-Z0-9]+$").GetCount(inStr);
            return passwordValidity == 0 ? false : true;
        }
        public static int GetStrenchForPassLength(this string inStr)
        {
            return 4 * inStr.Length;
        }
        public static int GetStrenchForDigits(this string inStr)
        {
            int digitCount = new Сriterion(@"\d").GetCount(inStr);
            return 4 * digitCount;
        }
        public static int GetStrenchForUpperLetters(this string inStr)
        {
            int upperCaseSymbolCount = new Сriterion("[A-Z]").GetCount(inStr);
            return upperCaseSymbolCount != 0 ? (inStr.Length - upperCaseSymbolCount) * 2 : 0;
        }
        public static int GetStrenchForLowLetters(this string inStr)
        {
            int lowerCaseSymbolCount = new Сriterion("[a-z]").GetCount(inStr);
            return lowerCaseSymbolCount != 0 ? (inStr.Length - lowerCaseSymbolCount) * 2 : 0;
        }
        public static int TakeStrenchForDigitsAbsence(this string inStr)
        {
            int digitCount = new Сriterion(@"\d").GetCount(inStr);
            return digitCount == 0 ? -inStr.Length : 0;
        }
        public static int TakeStrenchForLettersAbsence(this string inStr)
        {
            int LettertCount = new Сriterion(@"[a-zA-Z]").GetCount(inStr);
            return LettertCount == 0 ? -inStr.Length : 0;
        }
        public static int TakeStrenchForRepeatedChar(this string inStr)
        {
            int StrenchForRepeatedChar = 0;
            char[] array = inStr.ToCharArray();
            var result = array.GroupBy(x => x)
                          .Where(x => x.Count() > 1)
                          .Select(x => new { Frequency = x.Count() });
            foreach (var item in result)
            {
                StrenchForRepeatedChar += item.Frequency;
            }
            return -StrenchForRepeatedChar;
        }
    }
}

