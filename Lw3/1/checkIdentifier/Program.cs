using System;
using System.Text.RegularExpressions;

namespace checkIdentifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                Console.WriteLine("Incorrect number of arguments!");
            else
            {
                Identifier iden = new Identifier();
                if (iden.IsIdentifier(args[0]))
                    Console.WriteLine("yes");
                else
                {
                    Console.WriteLine("No");
                    Console.WriteLine("An identifier must consist of alphabet characters, numbers and underscores");
                    Console.WriteLine("An identifier cannot start with a digit.");
                }
            }
        }
    }
}
