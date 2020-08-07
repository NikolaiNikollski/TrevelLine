using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Translator.Data.Models;

namespace Translator.Tests
{
    [TestFixture()]
    public class StringExtensionTests
    {
        [TestCase("привет_hello", "привет", "hello")]
        [TestCase("Слово_Word", "Слово", "Word")]
        public void ReadPairTest(string str, string expRusTrans, string expEngTrans)
        {
            //Arrange
            List<Word> wordList = new List<Word>();
            str.ReadPair(wordList);

            //Assert
            Assert.AreEqual(expRusTrans, wordList[0].RusTrans);
            Assert.AreEqual(expEngTrans, wordList[0].EngTrans);
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("_")]
        [TestCase("приевет_")]
        [TestCase("_hello")]
        [TestCase("hello_привет")]
        public void ReadPairSkipTest(string str)
        {
            //Arrange
            List<Word> wordList = new List<Word>();
            str.ReadPair(wordList);

            //Assert
            Assert.AreEqual(0, wordList.Capacity);
        }
    }
}