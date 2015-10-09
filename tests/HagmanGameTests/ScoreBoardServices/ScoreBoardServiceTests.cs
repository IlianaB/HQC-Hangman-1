using System;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;
using NUnit.Framework;
using Moq;
using Moq.Language.Flow;

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
            for (int i = 0; i < count; i++)
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
        public void TestWhetherRemoveLastRecordsMethodRemovesAllRecordsAfterTheProvidedLimit(int recordsToAdd, int maxNumberOfRecords)
        {
            for (int i = 0; i < recordsToAdd; i++)
            {
                IPersonalScore score = new PersonalScore("ivan" + i, 2 + i);
                this.scoreBoardService.AddNewScore(score);
            }

            this.scoreBoardService.RemoveLastRecords(maxNumberOfRecords);

            Assert.AreEqual(maxNumberOfRecords-1, this.scoreBoard.Records.Count);
        }
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        public void TestWhetherRemoveLastRecordsMethodDoesNotGoUnderZeroWhenZeroRecordsInScoreBoard(int maxNumberOfRecords)
        {
            this.scoreBoardService.RemoveLastRecords(maxNumberOfRecords);
            Assert.AreEqual(0, this.scoreBoard.Records.Count);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-100)]
        public void TestWhetherRemoveLastRecordsMethodDoesNotGoUnderZeroWhenNegativeLimitIsProvided(int maxNumberOfRecords)
        {
            this.scoreBoardService.RemoveLastRecords(maxNumberOfRecords);
            Assert.AreEqual(0, this.scoreBoard.Records.Count);
        }
    }
}
