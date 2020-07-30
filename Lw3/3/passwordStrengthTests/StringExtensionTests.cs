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

        [TestCase("*", -1)] //point 1 check
        [TestCase("", -1)] //point 1 check
        [TestCase("abcDEF", 30)] //points 2, 4, 5, 6 check
        [TestCase("12345", 35)] //points 2, 3, 7 check
        [TestCase("1111", 24)] //points 2, 3, 7, 8 check
        public void GetPasswordStrengthTests(string inStr, int expected)
        {
            //Act
            int actual = inStr.GetPasswordStrength();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetRepeatedCharNumber_HiThere_4return()
        {
            // Arrange
            string inStr = "HiTHere";
            int expected = 4;

            //Act
            int actual = inStr.GetRepeatedCharNumber();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}