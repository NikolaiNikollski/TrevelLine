using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace removeExtraBlanks
{
    class Program
    {
        public const int ArgsNum = 2;
        public const string ArgsNumError = "Incorrect number of arguments!",
                            InputFileError = "Input file was not found!",
                            OutputFileError = "Output file was not found!",
                            SuccessResponse = "Processing was successful!";
        static void Main(string[] args)
        {
            if (args.Length != ArgsNum)
            {
                Console.WriteLine(ArgsNumError);
                return;
            }

            string inputFile = args[0];
            if (!File.Exists(inputFile))
            {
                Console.WriteLine(InputFileError);
                return;
            }

            string outputFile = args[1];
            if (!File.Exists(outputFile))
            {
                Console.WriteLine(OutputFileError);
                return;
            }
            string[] file = File.ReadAllLines(inputFile);
            StringProcess stringProcess = new StringProcess();
            for (int i = 0; i < file.Length; i++)
                file[i] = stringProcess.RemoveExtraBlanks(file[i]);
            File.WriteAllLines(outputFile, file);
            Console.WriteLine(SuccessResponse);       
        }
    }
}
