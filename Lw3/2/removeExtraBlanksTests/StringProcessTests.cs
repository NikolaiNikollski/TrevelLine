using Microsoft.VisualStudio.TestTools.UnitTesting;
using removeExtraBlanks;
using System;
using System.Collections.Generic;
using System.Text;

namespace removeExtraBlanks.Tests
{
    [TestClass()]
    public class StringProcessTests
    {
        [TestMethod()]
        public void RemoveExtraBlanks_Space_test()
        {
            // arrange
            string inStr = "   Hello   World   ";
            string expected = "Hello World";

            //act
            StringProcess SP = new StringProcess();
            string actual = SP.RemoveExtraBlanks(inStr);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveExtraBlanks_Tab_test()
        {
            // arrange
            string inStr = "\t\tHello\t\tWorld\t\t";
            string expected = "Hello\tWorld";

            //act
            StringProcess SP = new StringProcess();
            string actual = SP.RemoveExtraBlanks(inStr);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveExtraBlanks_TabAndSpace_test()
        {
            // arrange
            string inStr = " \t \t Hello \t  \t World \t \t";
            string expected = "Hello\tWorld";

            //act
            StringProcess SP = new StringProcess();
            string actual = SP.RemoveExtraBlanks(inStr);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}