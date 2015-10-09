using Hangman.Logic.Engines;
using Hangman.Logic.Words;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Engine
{
    [TestFixture]
    public class EngineTest
    {
        private const string FakeWord = "guessme";
        private GameEngine engine;

        [SetUp]
        public void Init()
        {
            var mockEngine = new Mock<GameEngine>();
            var word = new GuessWord(FakeWord);
            mockEngine.Setup(r => r.WordToGuess).Returns(word);
            
            this.engine = mockEngine.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.engine = null;
        }
    }
}
