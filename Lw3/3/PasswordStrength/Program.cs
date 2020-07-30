using System;
using GetPasswordStrength;

namespace PasswordStrength
{
    class Program
    {

        public const int ArgsNum = 1;
        public const string ArgsNumError = "Incorrect number of arguments!",
                            PasswordValidityError = "Invalid password\n" +
                                                    "Only English alphabet and numbers are available";
        static void Main(string[] args)
        {
            if (args.Length != ArgsNum)
            {
                Console.WriteLine(ArgsNumError);
                return;
            }
            int passwordStrength = args[0].GetPasswordStrength();
            Console.WriteLine(passwordStrength == -1 ? PasswordValidityError : passwordStrength.ToString());
        }
    }
}
