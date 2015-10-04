using HangmanGame.HangmanGame.Common;
using NUnit.Framework;

namespace HagmanGameTests
{
    [TestFixture]
    public class TestWordGenerator
    {
        private WordGenerator wordGenerator;

        [SetUp]
        public void Init()
        {
            this.wordGenerator = new WordGenerator();
        }

        [TearDown]
        public void CleanUp()
        {
            this.wordGenerator = null;
        }

        [Test]
        public void TestWordGenerationReturnWord()
        {
            Assert.IsInstanceOf(typeof(string), this.wordGenerator.GetRandomWord(), "WordGenerator returns string");
        }
    }
}