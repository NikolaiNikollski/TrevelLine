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
        public void IsIdentifier_My_1st_Имя_TrueReturned()
        {
            //Arrange
            string inStr = "My_1st_имя";

            //Act
            bool actual = inStr.IsIdentifier();

            //Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void IsIdentifier_1stName_TrueReturned()
        {
            //Arrange
            string InStr = "1st_Name";

            //Act
            bool actual = InStr.IsIdentifier();

            //Assert
            Assert.IsFalse(actual);
        }
    }
}