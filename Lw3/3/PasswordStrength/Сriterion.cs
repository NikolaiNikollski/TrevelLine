using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PasswordStrength
{
    class Сriterion
    {
        private string pattern;

        public Сriterion(string p) { pattern = p; }
        public int GetCount(string password)
        {
            Regex regix = new Regex(pattern);
            MatchCollection match = regix.Matches(password);
            return match.Count;
        }


    }
}
