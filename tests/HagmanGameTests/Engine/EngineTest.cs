using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;
using Hangman.WPF.UI;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Engine
{
    [TestFixture]
    public class EngineTest
    {
        private WpfEngine engine;
        private Mock<IPlayer> player;
        private Mock<IGuessWord> guessWord;
        private Mock<IWordGenerator> wordGenerator;
        private Mock<IInputProvider> inputProvider;

        [SetUp]
        public void Init()
        {
            this.player = new Mock<IPlayer>();
            this.guessWord = new Mock<IGuessWord>();
            this.wordGenerator = new Mock<IWordGenerator>();
            this.inputProvider = new Mock<IInputProvider>();
            this.engine = new WpfEngine(
                new Mock<IScoreBoardService>().Object,
                new Mock<IRenderer>().Object,
                this.player.Object,
                this.wordGenerator.Object,
                new Mock<ICommandFactory>().Object
            );
        }

        [TearDown]
        public void CleanUp()
        {
            this.engine = null;
            this.player = null;
            this.guessWord = null;
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

        [Test]
        public void CheckIfResetGameMethodCallsPlayersResetMethod()
        {
            this.inputProvider.Setup(t => t.ReadCommand()).Returns("a");
            this.wordGenerator.Setup(t => t.GetRandomWord()).Returns("Test");
            this.player.Verify(t => t.Reset(), Times.AtMostOnce());
            
            this.engine.ResetGame();
        }
    }
}