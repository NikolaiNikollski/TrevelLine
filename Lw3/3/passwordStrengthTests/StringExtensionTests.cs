using getPasswordStrength;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using passwordStrength;
using System;
using System.Collections.Generic;
using System.Text;

namespace getPasswordStrength.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void GetPasswordStrength_InvalidSymbol_Minus1return()
        {
            // arrange
            string inStr = "*"; //points 1 check
            int expected = -1;

            //act
            int actual = inStr.GetPasswordStrength();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPasswordStrength_EmptyString_Minus1return()
        {
            // arrange
            string inStr = ""; //points 1 check
            int expected = -1;

            //act
            int actual = inStr.GetPasswordStrength();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPasswordStrength_12345_35return()
        {
            // arrange
            string inStr = "12345"; //points 2, 3, 7 check
            int expected = 35;

            //act
            int actual = inStr.GetPasswordStrength();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPasswordStrength_abcDEF_30return() //points 2, 4, 5, 6 check
        {
            // arrange
            string inStr = "abcDEF";
            int expected = 30;

            //act
            int actual = inStr.GetPasswordStrength();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPasswordStrength_1111_30return() //points 2, 3, 7, 8 check
        {
            // arrange
            string inStr = "1111";
            int expected = 24;

            //act
            int actual = inStr.GetPasswordStrength();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetRepeatedCharNumber_HiThere_4return()
        {
            // arrange
            string inStr = "HiTHere";
            int expected = 4;

            //act
            int actual = inStr.GetRepeatedCharNumber();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
