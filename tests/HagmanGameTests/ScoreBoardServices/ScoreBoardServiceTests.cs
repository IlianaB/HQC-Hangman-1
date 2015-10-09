using System.Linq;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

using NUnit.Framework;

namespace HagmanGameTests.ScoreBoardServices
{
    [TestFixture]
    public class ScoreBoardServiceTests
    {
        [SetUp]
        public void Init()
        {
            scoreBoard = new ScoreBoard();
            scoreBoardService = new ScoreBoardService(scoreBoard);
        }

        [TearDown]
        public void CleanUp()
        {
            scoreBoard = null;
            scoreBoardService = null;
        }

        private IScoreBoard scoreBoard;
        private ScoreBoardService scoreBoardService;

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
                scoreBoardService.AddNewScore(score);
            }

            Assert.AreEqual(count, scoreBoard.Records.Count);
        }

        [TestCase(10, 10)]
        [TestCase(10, 5)]
        [TestCase(50, 1)]
        [TestCase(1, 1)]
        public void TestWhetherRemoveLastScoresMethodRemovesAllRecordsAfterTheProvidedLimit(int recordsToAdd,
            int maxNumberOfRecords)
        {
            for (var i = 0; i < recordsToAdd; i++)
            {
                IPersonalScore score = new PersonalScore("ivan" + i, 2 + i);
                scoreBoardService.AddNewScore(score);
            }

            scoreBoardService.RemoveLastScores(maxNumberOfRecords);

            Assert.AreEqual(maxNumberOfRecords - 1, scoreBoard.Records.Count);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        public void TestWhetherRemoveLastScoresMethodDoesNotGoUnderZeroWhenZeroRecordsInScoreBoard(
            int maxNumberOfRecords)
        {
            scoreBoardService.RemoveLastScores(maxNumberOfRecords);
            Assert.AreEqual(0, scoreBoard.Records.Count);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-100)]
        public void TestWhetherRemoveLastScoresMethodDoesNotGoUnderZeroWhenNegativeLimitIsProvided(
            int maxNumberOfRecords)
        {
            scoreBoardService.RemoveLastScores(maxNumberOfRecords);
            Assert.AreEqual(0, scoreBoard.Records.Count);
        }
        [Test]
        public void TestWhetherSortScoreBoardMethodProperlySortsScores()
        {
            IPersonalScore score = new PersonalScore("Ivan", 2);
            IPersonalScore secondScore = new PersonalScore("Georgi", 5);
            IPersonalScore thirdScore = new PersonalScore("Pesho", 3);
            scoreBoardService.AddNewScore(score);
            scoreBoardService.AddNewScore(secondScore);
            scoreBoardService.AddNewScore(thirdScore);
            scoreBoardService.SortScoreBoard();
            Assert.AreEqual(5, scoreBoard.Records.Last().Score);
        }

        [Test]
        public void TestWhetherGetAllScoresMethodProvidesProperlyProvidesAllScores()
        {
            IPersonalScore score = new PersonalScore("Ivan", 2);
            IPersonalScore secondScore = new PersonalScore("Georgi", 5);
            IPersonalScore thirdScore = new PersonalScore("Pesho", 3);
            scoreBoardService.AddNewScore(score);
            scoreBoardService.AddNewScore(secondScore);
            scoreBoardService.AddNewScore(thirdScore);
            var allRecords = scoreBoardService.GetAllScores();
            Assert.AreEqual(allRecords.Count, scoreBoard.Records.Count);
        }
    }
}