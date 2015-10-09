using Hangman.Logic.Common;
using Hangman.Logic.Engines;
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
            this.engine = mockEngine.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.engine = null;
        }

        [Test]
        public void TestGuessWordReturnsWord()
        {
            var wordToGuess = this.engine.WordToGuess;
        }
    }
}
