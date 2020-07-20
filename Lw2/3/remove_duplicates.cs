using System;
using System.Collections.Generic;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
            }
            else
            {
                string InStr = args[0];
                HashSet<char> InSet = new HashSet<char>();
                for (int i = 0; i < InStr.Length; i++)
                {
                    InSet.Add(InStr[i]);
                }
                foreach (char ch in InSet)
                { 
                    Console.Write(ch);
                }
            }
        }
    }
}
