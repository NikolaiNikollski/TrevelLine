using System;
using System.Collections.Generic;

namespace removeDuplicates
{
    class Program
    {

        static void Main(string[] args)
        {
            int NumberOfArguments = args.Length;
            switch (NumberOfArguments)
            {
                case 0:
                    Console.WriteLine("No parameters were specified!");
                    break;
                case 1:
                    RemoveDuplicates(args[0]);
                    break;
                default:
                    Console.WriteLine("Incorrect number of arguments!");
                    Console.WriteLine("Usage remove_duplicates.exe <input string>");
                    break;
            }
        }
        static void RemoveDuplicates(string InStr)
        {
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
