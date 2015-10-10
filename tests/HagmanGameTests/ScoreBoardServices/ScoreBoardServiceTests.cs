using System.Linq;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

using NUnit.Framework;

namespace HagmanGameTests.ScoreBoardServices
{
    [TestFixture]
    public class ScoreBoardServiceTests
    {
        private IScoreBoard scoreBoard;
        private ScoreBoardService scoreBoardService;

        [SetUp]
        public void Init()
        {
            this.scoreBoard = new ScoreBoard();
            this.scoreBoardService = new ScoreBoardService(this.scoreBoard);
        }

        [TearDown]
        public void CleanUp()
        {
            this.scoreBoard = null;
            this.scoreBoardService = null;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(50)]
        public void TestIfAddNewScoreMethodAddsTheNumberOfScoresProvided(int count)
        {
            for (var i = 0; i < count; i++)
            {
                IPersonalScore score = new PersonalScore("ivan" + i, 2 + i);
                this.scoreBoardService.AddNewScore(score);
            }

            Assert.AreEqual(count, this.scoreBoard.Records.Count);
        }

        [TestCase(10, 10)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(1, 1)]
        public void TestWhetherRemoveLastScoresMethodRemovesAllRecordsAfterTheProvidedLimit(int recordsToAdd, int maxNumberOfRecords)
        {
            for (var i = 0; i < recordsToAdd; i++)
            {
                IPersonalScore score = new PersonalScore("ivan" + i, 2 + i);
                this.scoreBoardService.AddNewScore(score);
            }

            this.scoreBoardService.RemoveLastScores(maxNumberOfRecords);

            Assert.AreEqual(maxNumberOfRecords - 1, this.scoreBoard.Records.Count);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        public void TestWhetherRemoveLastScoresMethodDoesNotGoUnderZeroWhenZeroRecordsInScoreBoard(
            int maxNumberOfRecords)
        {
            this.scoreBoardService.RemoveLastScores(maxNumberOfRecords);
            Assert.AreEqual(0, this.scoreBoard.Records.Count);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-100)]
        public void TestWhetherRemoveLastScoresMethodDoesNotGoUnderZeroWhenNegativeLimitIsProvided(
            int maxNumberOfRecords)
        {
            this.scoreBoardService.RemoveLastScores(maxNumberOfRecords);
            Assert.AreEqual(0, this.scoreBoard.Records.Count);
        }

        [Test]
        public void TestWhetherSortScoreBoardMethodProperlySortsScores()
        {
            IPersonalScore score = new PersonalScore("Ivan", 2);
            IPersonalScore secondScore = new PersonalScore("Georgi", 5);
            IPersonalScore thirdScore = new PersonalScore("Pesho", 3);
            this.scoreBoardService.AddNewScore(score);
            this.scoreBoardService.AddNewScore(secondScore);
            this.scoreBoardService.AddNewScore(thirdScore);
            this.scoreBoardService.SortScoreBoard();
            Assert.AreEqual(5, this.scoreBoard.Records.Last().Score);
        }

        [Test]
        public void TestWhetherGetWorstScoreMethodProvidesLastResultWhenBelowMaxNumberOfScores()
        {
            IPersonalScore score = new PersonalScore("Ivan", 2);
            IPersonalScore secondScore = new PersonalScore("Georgi", 5);
            IPersonalScore thirdScore = new PersonalScore("Pesho", 3);
            this.scoreBoardService.AddNewScore(score);
            this.scoreBoardService.AddNewScore(secondScore);
            this.scoreBoardService.AddNewScore(thirdScore);
            this.scoreBoardService.SortScoreBoard();
            var worstScore = this.scoreBoardService.GetWorstScore(5);
            Assert.AreEqual(5, worstScore);
        }

        [Test]
        public void TestWhetherGetWorstScoreMethodProvidesLastResultWhenAboveMaxNumberOfScores()
        {
            IPersonalScore score = new PersonalScore("Ivan", 2);
            IPersonalScore secondScore = new PersonalScore("Georgi", 5);
            IPersonalScore thirdScore = new PersonalScore("Pesho", 3);
            this.scoreBoardService.AddNewScore(score);
            this.scoreBoardService.AddNewScore(secondScore);
            this.scoreBoardService.AddNewScore(thirdScore);
            this.scoreBoardService.SortScoreBoard();
            var worstScore = this.scoreBoardService.GetWorstScore(2);
            Assert.AreEqual(3, worstScore);
        }
    }
}