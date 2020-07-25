using System;
using System.Text.RegularExpressions;

namespace checkIdentifier
{
    public class Program
    {
        public const string ArgsNumError = "Incorrect number of arguments!",
                            PosResponse = "yes",
                            NegResponse = "No\n" +
                                          "An identifier must consist of alphabet characters, numbers and underscores\n" +
                                          "An identifier cannot start with a digit.";
        static void Main(string[] args)
        {
            if (args.Length != 1)
                Console.WriteLine(ArgsNumError);
            else
            {
                Console.WriteLine(new Identifier().IsIdentifier(args[0]) ? PosResponse : NegResponse);
              /*  if (new Identifier().IsIdentifier(args[0]))
                    Console.WriteLine(PosResponse);
                else
                    Console.WriteLine(NegResponse);*/
            }
        }
    }
}
