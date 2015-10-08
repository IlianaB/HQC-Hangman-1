using System.Collections.Generic;
using Hangman.Logic.Common;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Common
{
    [TestFixture]
    public class WordGeneratorTest
    {
        private WordGenerator wordGenerator;

        [SetUp]
        public void Init()
        {
            var mockedWordProvider = new Mock<IWordProvider>();
            mockedWordProvider.Setup(r => r.ProvideWords()).Returns(new List<string> { "unittesting" });
            this.wordGenerator = new WordGenerator(mockedWordProvider.Object);
        }

        [TearDown]
        public void CleanUp()
        {
            this.wordGenerator = null;
        }

        [Test]
        public void TestWordGenerationReturnString()
        {
            Assert.IsInstanceOf(typeof(string), this.wordGenerator.GetRandomWord(), "WordGenerator returns string");
        }

        [Test]
        public void TestWordGenerationReturnWord()
        {
            var word = this.wordGenerator.GetRandomWord();
            Assert.AreEqual("unittesting", word, "Returned word is correct");
        }
    }
}