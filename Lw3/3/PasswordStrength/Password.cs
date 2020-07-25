using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using passwordStrength;

namespace getPasswordStrength
{
    public static class StringExtension
    {
        public static int GetPasswordStrength(this string inStr)
        {
            int passwordValidity = new Сriterion("^[a-zA-Z0-9]+$").GetCount(inStr);
            if (passwordValidity == 0)
                return -1;

            int digitCount = new Сriterion(@"\d").GetCount(inStr);
            int upperCaseSymbolCount = new Сriterion("[A-Z]").GetCount(inStr);
            int lowerCaseSymbolCount = new Сriterion("[a-z]").GetCount(inStr);

            int inStrStrength = 0; //1
            inStrStrength += 4* inStr.Length; //2
            inStrStrength += 4 * digitCount; //3
            inStrStrength += upperCaseSymbolCount != 0 ? (inStr.Length - upperCaseSymbolCount) * 2 : 0; //4
            inStrStrength += lowerCaseSymbolCount != 0 ? (inStr.Length - lowerCaseSymbolCount) * 2 : 0; //5
            inStrStrength -= digitCount == 0 ? inStr.Length : 0; //6
            inStrStrength -= digitCount == inStr.Length ? inStr.Length : 0; //7
            inStrStrength -= inStr.GetRepeatedCharNumber(); //8

            return inStrStrength;
        }
        public static int GetRepeatedCharNumber(this string inStr)
        {
            int inStrStrength = 0;
            char[] array = inStr.ToCharArray();
            var result = array.GroupBy(x => x)
                          .Where(x => x.Count() > 1)
                          .Select(x => new { Frequency = x.Count() });
            foreach (var item in result)
            {
                inStrStrength += item.Frequency;
            }
            return inStrStrength;
        }
    }
}
