using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace checkIdentifier.Tests
{
    [TestClass()]
    public class IdentifierTests
    {
        [TestMethod()]
        public void IsIdentifier_My_1st_Имя_TrueReturned()
        {
            //arrange
            string inStr = "My_1st_имя";

            //act
            bool actual = inStr.IsIdentifier();

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void IsIdentifier_1stName_TrueReturned()
        {
            //arrange
            string InStr = "1st_Name";

            //act
            bool actual = InStr.IsIdentifier();

            //assert
            Assert.IsFalse(actual);
        }
    }
}