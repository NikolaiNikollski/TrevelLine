using checkIdentifier;
using NUnit.Framework;

namespace checkIdentifierTests
{
    public class StringExtensionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsIdentifier_snake_case_TrueReturned()
        {
            //Arrange
            string inStr = "snake_case";

            //Act
            bool actual = inStr.IsIdentifier();

            //Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsIdentifier_1stName_TrueReturned()
        {
            //Arrange
            string InStr = "1stName";

            //Act
            bool actual = InStr.IsIdentifier();

            //Assert
            Assert.IsFalse(actual);
        }
    }
}