using Microsoft.VisualStudio.TestTools.UnitTesting;
using removeExtraBlanks;
using System;
using System.Collections.Generic;
using System.Text;

namespace removeExtraBlanks.Tests
{
    [TestClass()]
    public class RemoveExtraBlanksTests
    {
        [TestMethod()]
        public void RemoveExtraBlanks_ExtraSpace_DeleteExtraSpace()
        {
            // arrange
            string inStr = "   Hello   World   ";
            string expected = "Hello World";

            //act
            string actual = inStr.RemoveExtraBlanks();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveExtraBlanks_ExtraTabs_DeleteExtraTabs()
        {
            // arrange
            string inStr = "\t\tHello\t\tWorld\t\t";
            string expected = "Hello\tWorld";

            //act
            string actual = inStr.RemoveExtraBlanks();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveExtraBlanks_ExtraTabAndSpace_DeleteExtraTabAndSpace()
        {
            // arrange
            string inStr = " \t \t Hello \t  \t World \t \t";
            string expected = "Hello\tWorld";

            //act
            string actual = inStr.RemoveExtraBlanks();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}