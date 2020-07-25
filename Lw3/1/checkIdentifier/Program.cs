using System;
using System.Text.RegularExpressions;

namespace checkIdentifier
{
    public class Program
    {
        public const int ArgsNum = 1;
        public const string ArgsNumError = "Incorrect number of arguments!",
                            PosResponse = "yes",
                            NegResponse = "No\n" +
                                          "An identifier must consist of alphabet characters, numbers and underscores\n" +
                                          "An identifier cannot start with a digit.";
        static void Main(string[] args)
        {
            if (args.Length != ArgsNum)
                Console.WriteLine(ArgsNumError);
            else
                Console.WriteLine(args[0].IsIdentifier() ? PosResponse : NegResponse);
        }
    }
}
