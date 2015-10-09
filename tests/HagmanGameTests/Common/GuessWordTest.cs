using Hangman.Logic.Words;
using NUnit.Framework;

namespace HagmanGameTests.Common
{
    [TestFixture]
    public class GuessWordTest
    {
        private const string Word = "highqualitycode";
        private const string WordMasked = "_______________";
        private GuessWord guessWord;

        [SetUp]
        public void Init()
        {
            this.guessWord = new GuessWord(Word);
        }

        [TearDown]
        public void CleanUp()
        {
            this.guessWord = null;
        }

        [Test]
        public void TestContentValue()
        {
            Assert.AreEqual(Word, this.guessWord.Content, "Content of GuessWord should be equal");
        }

        [Test]
        public void TestMaskingOfWord()
        {
            Assert.AreEqual(WordMasked, string.Join(string.Empty, this.guessWord.Mask), "Masked word should be equal to GuessWord.Mask");
        }

        [TestCase(1, 'y')]
        [TestCase(0, 'z')]
        [TestCase(2, 'h')]
        [TestCase(1, 'e')]
        public void TestGetNumberOfOccurences(int found, char letter)
        {
            Assert.AreEqual(found, this.guessWord.GetNumberOfOccurences(letter), "Letter '" + letter + "' should be found only once");
        }

        [Test]
        public void TestRevealLetter()
        {
            Assert.AreEqual('h', this.guessWord.RevealLetter(), "Letters 'h' should be same");
        }
    }
}
