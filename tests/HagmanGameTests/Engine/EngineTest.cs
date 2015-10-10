using System.Linq;
using Hangman.Console.UI;
using Hangman.Console.UI.Engines;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words;
using Hangman.Logic.Words.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Engine
{
    [TestFixture]
    public class EngineTest
    {
        private const string FakeWord = "guessme";
        private ConsoleEngine engine;
        private Mock<IPlayer> player;
        private Mock<IGuessWord> guessWord;

        [SetUp]
        public void Init()
        {
            this.player = new Mock<IPlayer>();
            this.guessWord = new Mock<IGuessWord>();
            this.engine = new ConsoleEngine(
                new Mock<IScoreBoardService>().Object,
                new Mock<IRenderer>().Object,
                this.player.Object,
                new Mock<IWordGenerator>().Object,
                new Mock<ICommandFactory>().Object,
                new Mock<IInputProvider>().Object
            );
        }

        [TearDown]
        public void CleanUp()
        {
            this.engine = null;
        }

        [Test]
        public void CheckGameOverConditionMustReturnTrueIfPlayerMistakesAreHigherThanMaxConstant()
        {
            this.player.Setup(t => t.Mistakes).Returns(Constants.MaxNumberOfPlayerMistakes + 1);
            bool result = this.engine.CheckGameOverCondition();

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckGameOverConditionMustReturnFalseIfPlayerMistakesAreEqualToMaxConstant()
        {
            this.player.Setup(t => t.Mistakes).Returns(Constants.MaxNumberOfPlayerMistakes);
            bool result = this.engine.CheckGameOverCondition();

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckGameOverConditionMustReturnFalseIfPlayerMistakesAreLowerThanMaxConstant()
        {
            this.player.Setup(t => t.Mistakes).Returns(Constants.MaxNumberOfPlayerMistakes - 1);
            bool result = this.engine.CheckGameOverCondition();

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckWinningConditionMustReturnTrueIfAllLettersAreGuessed()
        {
            char[] testMask = { 'a', 'b', 'c' };
            this.guessWord.Setup(t => t.Mask).Returns(testMask);
            this.engine.WordToGuess = this.guessWord.Object;

            bool result = this.engine.CheckWinningCondition();

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckWinningConditionMustReturnFalseIfAnyLetterIsNotGuessed()
        {
            char[] testMask = { 'a', '_', 'c' };
            this.guessWord.Setup(t => t.Mask).Returns(testMask);
            this.engine.WordToGuess = this.guessWord.Object;

            bool result = this.engine.CheckWinningCondition();

            Assert.IsFalse(result);
        }

    }
}