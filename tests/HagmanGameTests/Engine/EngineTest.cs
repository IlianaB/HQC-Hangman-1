using System.Collections.Generic;
using Hangman.Logic.Commands;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;
using Hangman.WPF.UI;
using Moq;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

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
                new Mock<ICommandFactory>().Object);
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

        [Test]
        public void CheckIfResetGameMethodCallsStartGameMethod()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.StartGame()).DoInstead(context =>
            {
                calls++;
            });

            this.engine.ResetGame();

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfStartGameMethodCallsRenderersShowMessageMethod()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.WordGenerator.GetRandomWord()).DoInstead(context =>
            {
                return "Called";
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
                calls++;
            });

            Isolate.WhenCalled(() => this.engine.Play()).DoInstead(context =>
            {
            });

            this.engine.StartGame();

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfStartGameMethodCallsPlayMethod()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.WordGenerator.GetRandomWord()).DoInstead(context =>
            {
                return "Called";
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Play()).DoInstead(context =>
            {
                calls++;
            });

            this.engine.StartGame();

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfExecuteLetterGuessMethodCallsRenderersShowMessageMethodIfTheLetterIsUsed()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Player.CheckIfLetterIsUsed('a')).DoInstead(context =>
            {
                return true;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
                calls++;
            });

            Isolate.WhenCalled(() => this.engine.WordToGuess.Mask).DoInstead(context =>
            {
                return new char[5];
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowCurrentProgress(null)).DoInstead(context =>
            {
            });

            this.engine.ExecuteLetterGuess('a');

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfExecuteLetterGuessMethodCallsProcessGuessedLetterMethodIfTheLetterIsNotUsed()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Player.CheckIfLetterIsUsed('a')).DoInstead(context =>
            {
                return false;
            });

            Isolate.WhenCalled(() => this.engine.ProcessGuessedLetter('a')).DoInstead(context =>
            {
                calls++;
            });

            Isolate.WhenCalled(() => this.engine.WordToGuess.Mask).DoInstead(context =>
            {
                return new char[5];
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowCurrentProgress(null)).DoInstead(context =>
            {
            });

            this.engine.ExecuteLetterGuess('a');

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIProcessGuessLetterMethodCallsPlayersIncreaseMistakesMethodIfThereAreZeroOcurrencesOfLetter()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.WordToGuess.GetNumberOfOccurences('a')).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.DrawHangman(0)).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.AddNewUsedLetter('a')).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.IncreaseMistakes()).DoInstead(context =>
            {
                calls++;
            });

            this.engine.ProcessGuessedLetter('a');

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIProcessGuessLetterMethodCallsRenderersDrawHangmanMethodIfThereAreZeroOcurrencesOfLetter()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.WordToGuess.GetNumberOfOccurences('a')).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.DrawHangman(0)).DoInstead(context =>
            {
                calls++;
            });

            Isolate.WhenCalled(() => this.engine.Player.AddNewUsedLetter('a')).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.IncreaseMistakes()).DoInstead(context =>
            {
            });

            this.engine.ProcessGuessedLetter('a');

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIProcessGuessLetterMethodCallsRenderersShowMessageWithExactParameterIfThereAreZeroOcurrencesOfLetter()
        {
            string message = "Sorry! There are no unrevealed letters “a”";

            Isolate.WhenCalled(() => this.engine.WordToGuess.GetNumberOfOccurences('a')).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.DrawHangman(0)).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.AddNewUsedLetter('a')).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Player.IncreaseMistakes()).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            this.engine.ProcessGuessedLetter('a');

            Isolate.Verify.WasCalledWithExactArguments(() => this.engine.Renderer.ShowMessage(message));
        }

        [Test]
        public void CheckIProcessGuessLetterMethodCallsRenderersShowMessageWithExactParameterIfThereAreMoreThanZeroOcurrencesOfLetter()
        {
            string message = "Good job! You revealed 1 letter(s).";

            Isolate.WhenCalled(() => this.engine.WordToGuess.GetNumberOfOccurences('a')).DoInstead(context =>
            {
                return 1;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.DrawHangman(0)).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.AddNewUsedLetter('a')).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.Player.IncreaseMistakes()).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            this.engine.ProcessGuessedLetter('a');

            Isolate.Verify.WasCalledWithExactArguments(() => this.engine.Renderer.ShowMessage(message));
        }

        [Test]
        public void CheckIfEndWonGameMethodCallsRenderersShowMessageIfPlayerHasUsedHelp()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Player.HasUsedHelp).DoInstead(context =>
            {
                return true;
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.ResetGame()).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
                calls++;
            });

            this.engine.EndWonGame();

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfEndWonGameMethodCallsRenderersShowMessageWithExactMessage()
        {
            string message = "You won with 3 mistake(s) but you have cheated. You are not allowed to enter into the scoreboard.";

            Isolate.WhenCalled(() => this.engine.Player.HasUsedHelp).DoInstead(context =>
            {
                return true;
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 3;
            });

            Isolate.WhenCalled(() => this.engine.ResetGame()).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            this.engine.EndWonGame();

            Isolate.Verify.WasCalledWithExactArguments(() => this.engine.Renderer.ShowMessage(message));
        }

        [Test]
        public void CheckIfEndWonGameMethodCallsProcessPlayerResultWithExactParameeterIfPlayerHasNotUsedHelp()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Player.HasUsedHelp).DoInstead(context =>
            {
                return false;
            });

            Isolate.WhenCalled(() => this.engine.ScoreBoardService.CheckIfPlayerCanEnterHighScores(null, 10)).DoInstead(context =>
            {
                return true;
            });

            Isolate.WhenCalled(() => this.engine.ProcessCurrentPlayerResult(true)).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.ResetGame()).DoInstead(context =>
            {
            });

            this.engine.EndWonGame();

            Isolate.Verify.WasCalledWithExactArguments(() => this.engine.ProcessCurrentPlayerResult(true));
        }

        [Test]
        public void CheckIfEndLostGameMethodCallsResetGameMethod()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.ResetGame()).DoInstead(context =>
            {
                calls++;
            });

            this.engine.EndLostGame();

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfExecuteMethodCallsCommandsExecuteMethod()
        {
            int calls = 0;

            Mock<StartCommand> command = new Mock<StartCommand>(this.engine);
            command.Setup(t => t.Execute()).Callback(() => { calls++; });

            this.engine.ExecuteCommand(command.Object);

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfReactToPlayerActionMethodCallsExecuteLetterGuessMethodIfCommandLengthIsOne()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.ExecuteLetterGuess('a')).DoInstead(context =>
            {
                calls++;
            });

            this.engine.ReactToPlayerAction("a");

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfReactToPlayerActionMethodCallsExecuteCommandMethodIfCommandLengthIsMoreThanOne()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.ExecuteCommand(null)).DoInstead(context =>
            {
            });

            Isolate.WhenCalled(() => this.engine.CommandFactory.GetGommand(this.engine, "start")).DoInstead(context =>
            {
                calls++;

                return null;
            });

            this.engine.ReactToPlayerAction("start");

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfProcessCurrentPlayerResultMethodCallsSaveResultMethodIfPlayerCanEnterHighScores()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.Player.Name).DoInstead(context =>
            {
                return "Test Player";
            });

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 0;
            });

            Isolate.WhenCalled(() => this.engine.ScoreBoardService.IsEmpty()).DoInstead(context =>
            {
                return false;
            });

            Isolate.WhenCalled(() => this.engine.ScoreBoardService.GetTopScores(10)).DoInstead(context =>
            {
                return new List<IPersonalScore>();
            });

            Isolate.WhenCalled(() => this.engine.SaveResult(null)).DoInstead(context =>
            {
                calls++;
            });

            this.engine.ProcessCurrentPlayerResult(true);

            Assert.AreEqual(1, calls);
        }

        [Test]
        public void CheckIfProcessCurrentPlayerResultMethodCallsRenderersShowMessageWithExactMessageIfPlayerCannotEnterHighScores()
        {
            string message = "You won with 2 mistake(s) but your score did not enter in the scoreboard";

            Isolate.WhenCalled(() => this.engine.Player.Mistakes).DoInstead(context =>
            {
                return 2;
            });

            Isolate.WhenCalled(() => this.engine.Renderer.ShowMessage("Message")).DoInstead(context =>
            {
            });

            this.engine.ProcessCurrentPlayerResult(false);

            Isolate.Verify.WasCalledWithExactArguments(() => this.engine.Renderer.ShowMessage(message));
        }

        [Test]
        public void CheckIfSaveResultMethodCallsScoreBoardServicesAddNewScoreMethod()
        {
            int calls = 0;

            Isolate.WhenCalled(() => this.engine.ScoreBoardService.AddNewScore(null)).DoInstead(context =>
            {
                calls++;
            });

            Isolate.WhenCalled(() => DataFileManager.SingletonInstance.SaveResult(null, Constants.DatabaseFile)).DoInstead(context =>
            {
            });

            this.engine.SaveResult(null);

            Assert.AreEqual(1, calls);
        }
    }
}