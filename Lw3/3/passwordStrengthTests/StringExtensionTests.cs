using GetPasswordStrength;
using NUnit.Framework;

namespace PasswordStrengthTests
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("*", -1)]
        [TestCase("", -1)] 
        [TestCase("abcDEF", 30)] 
        [TestCase("12345", 35)]
        [TestCase("1111", 24)] 
        public void GetPasswordStrengthTests(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetPasswordStrength();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("a", 4)]
        [TestCase("aa", 8)]
        [TestCase("Hello World", 44)]
        public void GetStrenchForPassLengthTests(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetStrenchForPassLength();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("a", 0)]
        [TestCase("1", 4)]
        [TestCase("12", 8)]
        [TestCase("1_2_3", 12)]
        public void GetStrenchForDigits(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetStrenchForDigits();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("a", 0)]
        [TestCase("A", 0)]
        [TestCase("AB", 0)]
        [TestCase("Ab", 2)]
        [TestCase("A_B_c_d", 10)]
        public void GetStrenchForUpperLetters(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetStrenchForUpperLetters();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("A", 0)]
        [TestCase("a", 0)]
        [TestCase("ab", 0)]
        [TestCase("Ab", 2)]
        [TestCase("A_B_c_d", 10)]
        public void GetStrenchForLowLetters(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetStrenchForLowLetters();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("1", 0)]
        [TestCase("A1", 0)]
        [TestCase("A", -1)]
        [TestCase("ab", -2)]
        public void TakeStrenchForDigitsAbsence(string inStr, int expected)
        {
            //Act
            int actual = inStr.TakeStrenchForDigitsAbsence();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)]
        [TestCase("a", 0)]
        [TestCase("A", 0)]
        [TestCase("1C", 0)]
        [TestCase("1", -1)]
        [TestCase("12", -2)]
        public void TakeStrenchForLettersAbsence(string inStr, int expected)
        {
            //Act
            int actual = inStr.TakeStrenchForLettersAbsence();

            //Assert
            Assert.AreEqual(expected, actual);
        }














        [TestCase("", 0)]
        [TestCase("a", 0)]
        [TestCase("ab", 0)]
        [TestCase("aa", -2)]
        [TestCase("aaab", -3)]
        [TestCase("aaabb", -5)]
        [TestCase("Hello World", -5)]
        public void TakeRepeatedCharNumberTests(string inStr, int expected)
        {
            //Act
            int actual = inStr.TakeStrenchForRepeatedChar();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}