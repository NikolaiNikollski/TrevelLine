using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace СheckIdentifier
{
    public static class StringExtension
    {
        public static bool IsIdentifier(this string str)
        {
            Regex regix = new Regex(@"^[^\W\d]{1}\w*$"); //[^\W\d] is alphabet symbol
            return regix.IsMatch(str);
        }
    }
}

