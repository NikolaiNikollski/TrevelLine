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
        [TestCase("1�", false)] 
        [TestCase("snake_case", true)]
        [TestCase("1stName", false)]
        [TestCase("Self-development", false)]
        public void IsIdentifierTest(string inStr, bool expected) 
        {
            //Act
            bool actual = inStr.IsIdentifier();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}