using NUnit.Framework;
using removeExtraBlanks;

namespace removeExtraBlanksTests
{
    public class StringExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("   Hello   World   ", "Hello World")]
        [TestCase("\t\tHello\t\tWorld\t\t", "Hello\tWorld")]
        [TestCase(" \t \t Hello \t  \t World \t \t", "Hello\tWorld")]
        public void RemoveExtraBlanksTest(string inStr, string expected)
        {
            //Act
            string actual = inStr.RemoveExtraBlanks();

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}