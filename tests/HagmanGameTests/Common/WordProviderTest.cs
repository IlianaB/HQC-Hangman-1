using System.Collections.Generic;
using Hangman.Logic.Words;
using NUnit.Framework;

namespace HagmanGameTests.Common
{
    [TestFixture]
    public class WordProviderTest
    {
        [Test]
        public void TestReturnsListOfStrings()
        {
            var wordProvider = new WordProvider();
            Assert.IsInstanceOf(typeof(List<string>), wordProvider.ProvideWords(), "Provided words are in correct data type");
        }
    }
}
