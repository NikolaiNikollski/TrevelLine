using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace checkIdentifier
{
    public class Identifier
    {
        public bool IsIdentifier(string InStr)
        {
            Regex regix = new Regex(@"^[^\W\d]{1}\w*$"); //[^\W\d] is alphabet symbol
            return regix.IsMatch(InStr);
        }
    }
}

