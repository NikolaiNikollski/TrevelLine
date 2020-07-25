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
        public void IsIdentifier_My_1st_Имя_true_returned()
        {
            //arrange
            string InStr = "My_1st_имя";

            //act
            Identifier iden = new Identifier();
            bool actual = iden.IsIdentifier(InStr);

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void IsIdentifier_1stName_true_returned()
        {
            //arrange
            string InStr = "1st_Name";

            //act
            Identifier iden = new Identifier();
            bool actual = iden.IsIdentifier(InStr);

            //assert
            Assert.IsFalse(actual);
        }
    }
}