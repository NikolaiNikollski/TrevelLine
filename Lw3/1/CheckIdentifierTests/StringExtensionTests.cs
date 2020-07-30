using NUnit.Framework;
using CheckIdentifier;

namespace CheckIdentifierTests
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("snake_case", true)]
        [TestCase("1stName", false)]
        [TestCase("", false)]
        [TestCase("Self-development", false)]
        public void IsIdentifier_snake_case_TrueReturned(string inStr, bool expected) 
        {
            //Act
            bool actual = inStr.IsIdentifier();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}