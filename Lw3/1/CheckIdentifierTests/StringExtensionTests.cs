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

        [TestCase("A", true)]
        [TestCase("_", true)]
        [TestCase("", false)]
        [TestCase("1", false)]
        [TestCase("*", false)]
        [TestCase("AB", true)]
        [TestCase("A4", true)]
        [TestCase("1Ñ", false)]
        [TestCase("snake_case", true)]
        [TestCase("1stName", false)]
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